using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Mappers.ToDoLists;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Handlers.ToDoLists
{
    public class CreateToDoListHandler : IRequestHandler<CreateToDoListCommand, ToDoListResponse>
    {
        private readonly IToDoListRepository _todolistRepo;
        public CreateToDoListHandler(IToDoListRepository todolistRepository)
        {
            _todolistRepo = todolistRepository;
        }
      
      

        public async Task<ToDoListResponse> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var todolistEntity = ToDoListMapper.Mapper.Map<ToDoList>(request);
            if (todolistEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistRepo.InsertToDoList(todolistEntity);
            var todolistResponse = ToDoListMapper.Mapper.Map<ToDoListResponse>(newToDoList);
            return todolistResponse;
        }
    }
}
