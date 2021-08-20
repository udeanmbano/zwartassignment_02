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
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.ToDoListItem
{
    public class UpdateToDoListItemHandler : IRequestHandler<UpdateToDoListItemCommand, ToDoListItemResponse>
    {
        private readonly IToDoListItemRepository _todolistItemRepo;
        public UpdateToDoListItemHandler(IToDoListItemRepository todolistItemRepository)
        {
            _todolistItemRepo = todolistItemRepository;
        }
      
      

        public async Task<ToDoListItemResponse> Handle(UpdateToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var todolistEntity = ToDoListItemUpdateMapper.Mapper.Map<ToDoListItems>(request);
            if (todolistEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistItemRepo.UpdateToDoListItem(todolistEntity);
            var todolistResponse = ToDoListItemUpdateMapper.Mapper.Map<ToDoListItemResponse>(newToDoList);
            return todolistResponse;

        }
    }
}
