using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Mappers;
using ZwartsJWTApi.Application.Mappers.ToDoLists;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.ToDoLists
{
    public class DeleteToDoListHandler : IRequestHandler<DeleteToDoListCommand, MessageResponse>
    {
        private readonly IToDoListRepository _todolistRepo;
        public DeleteToDoListHandler(IToDoListRepository todolistRepository)
        {
            _todolistRepo = todolistRepository;
        }
      
      

        public async Task<MessageResponse> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            var todolistEntity = ToDoListDeleteMapper.Mapper.Map<ToDoList>(request);
            if (todolistEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistRepo.DeleteToDoList(todolistEntity.Id);
            var messageResponse = new Commands.Responses.MessageResponse();
            if (newToDoList>0)
            {
                messageResponse.Message="Deleted Successfully";
                messageResponse.ResponseCode = 200;
                messageResponse.StatusCode = 0;
            }
            else
            {
                messageResponse.Message = "Deleted failed";
                messageResponse.ResponseCode = 200;
                messageResponse.StatusCode = 0;
            }
            var todolistResponse = ToDoListDeleteMapper.Mapper.Map<MessageResponse>(messageResponse);
            return todolistResponse;
        }
    }
}
