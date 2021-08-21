using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.GetAllToDoList;
using Application.Queries.GetAllToDoList.ToDoListItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Domain.Entities;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListItemController : BaseController
    {
       
        [HttpGet]
        [Route("ToDoListItems/{id}")]
        public async Task<ActionResult<IEnumerable<ToDoListItems>>> GetAllToLists(int id)
        {
            var request = new GetAllToDoListItemQuery();
            request.Id =id;
            var response = await Mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        [Route("GetToDoListItem/{id}")]
        public async Task<ActionResult<IEnumerable<ToDoListItems>>> GetAllToListItems(int id)
        {
            var request = new GetAllToDoListItemQueryById();
            request.Id = id;
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("PostToDoListItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoListItems>> CreateToDoListITems([FromBody] CreateToDoListItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("PutToDoListItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> UpdateToDoListItem([FromBody] UpdateToDoListItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("MarkToDoListItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoListItems>> MarkToDoListItem([FromBody] MarkToDoListItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteToDolistItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MessageResponse>> DeleteToDoListItem([FromBody] DeleteToDoListItemCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}