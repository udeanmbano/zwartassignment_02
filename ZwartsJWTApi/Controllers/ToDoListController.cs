using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Queries;
using ZwartsJWTApi.Application.Responses;
using ZwartsJWTApi.Core.Entities;

namespace ZwartsJWTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ToDoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ToDoList>> Get()
        {
            return await _mediator.Send(new GetToDoListQuery());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoListResponse>> CreateToDoList([FromBody] CreateToDoListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
