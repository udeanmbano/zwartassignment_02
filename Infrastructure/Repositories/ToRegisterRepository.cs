using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;
using ZwartsJWTApi.Infrastructure;
using ZwartsJWTApi.Infrastructure.Data;

namespace ZwartsJWTApi.Repositories
{
    public class ToRegisterRepository : IToRegister
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
     
        private ApplicationDbContext _appDbContext;
        public ToRegisterRepository(ApplicationDbContext applicationDbContext,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = applicationDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
    
        }

        public async Task<Response> RegisterUser(RegisterModel register)
        {
            var registerResponse = new Response();
            try
            {

                User createdUser = new User();
                var userExists = await userManager.FindByEmailAsync(register.Email);
                if (userExists != null)
                {
                    registerResponse.Status = "200";
                    registerResponse.Message = "Successfully not successful";
                    return registerResponse;
                }
                ApplicationUser user = new ApplicationUser()
                {
                    Email = register.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = register.Username
                };
                var result = await userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    registerResponse.Status = "200";
                    registerResponse.Message = "Successfully not successful";
                    return registerResponse;
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await userManager.AddToRoleAsync(user, UserRoles.User);

                    //add user to User Table
                    createdUser.UserIdentity = user.Id;
                    _appDbContext.UserLists.Add(createdUser);
                    await _appDbContext.SaveChangesAsync();
                }
                if (createdUser != null)
                {
                    registerResponse.Status = "200";
                    registerResponse.Message = "Successfully registered";
                }
                else
                {
                    registerResponse.Status = "200";
                    registerResponse.Message = "Successfully not successful";

                }
            }
            catch (Exception e)
            {

            }
            return registerResponse;
        }
    }
}
