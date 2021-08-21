using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController :BaseController
    {
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponse>> CreateToDoList([FromBody] LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
