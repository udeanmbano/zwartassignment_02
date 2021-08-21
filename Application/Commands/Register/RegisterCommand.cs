using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands.Responses;

namespace ZwartsJWTApi.Application.Commands
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

}

