using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Application.Mappers;
using ZwartsJWTApi.Application.Mappers.ToDoListItem;
using ZwartsJWTApi.Application.Mappers.ToDoLists;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.ToDoListItem
{
    public class DeleteToDoListItemHandler : IRequestHandler<DeleteToDoListItemCommand, MessageResponse>
    {
        private readonly IToDoListItemRepository _todolistItemRepo;
        public DeleteToDoListItemHandler(IToDoListItemRepository todolistItemRepository)
        {
            _todolistItemRepo = todolistItemRepository;
        }
      
      

        public async Task<MessageResponse> Handle(DeleteToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var todolistEntity = ToDoListItemDeleteMapper.Mapper.Map<ToDoListItems>(request);
            if (todolistEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistItemRepo.DeleteToDoListItem(todolistEntity.ToDoListItemId);
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
