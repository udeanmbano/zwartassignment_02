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
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IToRegister _registerRepo;
        public RegisterHandler(IToRegister registerRepo)
        {
            _registerRepo = registerRepo;
        }
      
      

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerItem = RegisterMapper.Mapper.Map<RegisterModel>(request);
            if (registerItem is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var registerList =await _registerRepo.RegisterUser(registerItem);

            var registers = new RegisterResponse();
            registers.Message = registerList.Message;
            registers.Status = registerList.Status;

            var registersResponse = RegisterMapper.Mapper.Map<RegisterResponse>(registers);
            return registersResponse;
        }
    }
}
