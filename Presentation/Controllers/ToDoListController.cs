using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.GetAllToDoList;
using Application.Queries.GetAllToDoList.ToDoListItem;
using Application.Queries.GetAllToDoList.ToDoListItems;
using Application.Queries.GetAllToDoList.ToDoLists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Domain.Entities;

namespace Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : BaseController
    {
       
        [HttpGet]
        [Route("ToDoLists/{userId}")]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllToLists(string userId)
        {
            var request = new GetAllToDoListQuery();
            request.UserID =userId;
            var response = await Mediator.Send(request);

            return Ok(response);
        }
        [HttpGet]
        [Route("GetToDoLists/{id}")]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllToLists(int id)
        {
            var request = new GetAllToDoListQueryById();
            request.Id = id;
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("PostToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> CreateToDoList([FromBody] CreateToDoListCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("PutToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> UpdateToDoList([FromBody] UpdateToDoListCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MessageResponse>> DeleteToDoList([FromBody] DeleteToDoListCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}