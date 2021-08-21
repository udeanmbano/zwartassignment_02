using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;
using ZwartsJWTApi.Infrastructure;
using ZwartsJWTApi.Infrastructure.Data;

namespace ZwartsJWTApi.Repositories
{
    public class ToLoginRepository : IToLogin
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        private ApplicationDbContext _appDbContext;
        public ToLoginRepository(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _appDbContext = applicationDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<TokenResponse> Login(LoginModel loginModel)
        {
            var tokenResponse = new TokenResponse();
            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var loggedUser = _appDbContext.UserLists.Where(a => a.UserIdentity.Equals(user.Id)).FirstOrDefault();
                tokenResponse.Status = "Success";
                tokenResponse.Message = "Success";
                tokenResponse.token = new JwtSecurityTokenHandler().WriteToken(token);
                tokenResponse.expiration = token.ValidTo.ToString();
                    tokenResponse.userId =loggedUser.UserId;

            }
            else
            {
                tokenResponse.Status = "401";
                tokenResponse.Message = "Unauthorized";
                tokenResponse.token = "";
                tokenResponse.expiration ="";
                tokenResponse.userId = 0;

            }

           return tokenResponse;
        }
    }
}
