using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.GetAllToDoList;
using Application.Queries.GetAllToDoList.ToDoListItem;
using Application.Queries.GetAllToDoList.ToDoListItems;
using Application.Queries.GetAllToDoList.ToDoLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : BaseController
    {
       
        [HttpGet]
        [Route("ToDoLists/{userId}")]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllToLists(int userId)
        {
            try
            {
                var request = new GetAllToDoListQuery();
                request.UserID = userId;
                var response = await Mediator.Send(request);

                return Ok(response);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("GetToDoLists/{id}")]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoLists(int id)
        {
            try
            {
                var request = new GetAllToDoListQueryById();
                request.Id = id;
                var response = await Mediator.Send(request);

                return Ok(response);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("PostToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> CreateToDoList([FromBody] CreateToDoListCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("PutToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoList>> UpdateToDoList([FromBody] UpdateToDoListCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteToDolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MessageResponse>> DeleteToDoList([FromBody] DeleteToDoListCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

    }
}