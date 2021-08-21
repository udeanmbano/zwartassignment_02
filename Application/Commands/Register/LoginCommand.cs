using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands.Responses;

namespace ZwartsJWTApi.Application.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {

        public string Username { get; set; }
        public string Password { get; set; }

    }

}

