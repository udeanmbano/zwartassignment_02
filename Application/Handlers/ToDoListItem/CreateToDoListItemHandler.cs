using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Application.Mappers.ToDoListItem;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.ToDoListItem
{
    public class CreateToDoListItemHandler : IRequestHandler<CreateToDoListItemCommand, ToDoListItemResponse>
    {
        private readonly IToDoListItemRepository _todolistItemRepo;
        public CreateToDoListItemHandler(IToDoListItemRepository todolistItemRepository)
        {
            _todolistItemRepo = todolistItemRepository;
        }
      
      

        public async Task<ToDoListItemResponse> Handle(CreateToDoListItemCommand request, CancellationToken cancellationToken)
        {
            var todolistEntityItem = ToDoListItemMapper.Mapper.Map<ToDoListItems>(request);
            if (todolistEntityItem is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistItemRepo.InsertToDoListItem(todolistEntityItem);
            var todolistResponse = ToDoListItemMapper.Mapper.Map<ToDoListItemResponse>(newToDoList);
            return todolistResponse;
        }
    }
}
