using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Mappers;
using ZwartsJWTApi.Application.Responses;
using ZwartsJWTApi.Core.Entities;
using ZwartsJWTApi.Core.Repositories;

namespace ZwartsJWTApi.Application.Handlers
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
            var newToDoList = await _todolistRepo.AddAsync(todolistEntity);
            var todolistResponse = ToDoListMapper.Mapper.Map<ToDoListResponse>(newToDoList);
            return todolistResponse;
        }
    }
}
