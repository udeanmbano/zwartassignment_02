using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Application.Mappers.ToDoListItem;
using ZwartsJWTApi.Application.Mappers.ToDoLists;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.Register
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IToLogin _loginRepo;
        public LoginHandler(IToLogin loginRepo)
        {
            _loginRepo = loginRepo;
        }
          

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginEntityItem = LoginMapper.Mapper.Map<LoginModel>(request);
            if (loginEntityItem is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var loginList =await _loginRepo.Login(loginEntityItem);
            var loginResponses = new LoginResponse();
            loginResponses.expiration = loginList.expiration;
            loginResponses.Message = loginList.Message;
            loginResponses.token = loginList.token;
            loginResponses.Status = loginList.Status;
            loginResponses.userId = loginList.userId;
            var loginResponse = LoginMapper.Mapper.Map<LoginResponse>(loginResponses);
            return loginResponse;
        }
    }
}
