using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.GetAllToDoList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Domain.Entities;

namespace Presentation.Controllers
{
    public class ToDoListController : BaseController
    {
        /*[HttpGet]
         public async Task<ActionResult<IEnumerable<GetAllPostsDto>>> GetAllPosts()
         {
             var response = await Mediator.Send(new GetAllPostsQuery());

             return Ok(response);
         }*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllPosts(string userId)
        {
            var request = new GetAllToDoListQuery();
            request.UserID =userId;
            var response = await Mediator.Send(request);

            return Ok(response);
        }
        /*[HttpPost]
        public async Task<ActionResult<CreateToDoListDto>> CreatePost(CreatePostCommand command)
        {
            var response = await Mediator.Send(command);

            return CreatedAtAction(nameof(CreatePost), response);
        }*/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> CreateToDoList([FromBody] CreateToDoListCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}