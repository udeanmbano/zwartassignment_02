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
    public class UpdateToDoListHandler : IRequestHandler<UpdateToDoListCommand, ToDoListResponse>
    {
        private readonly IToDoListRepository _todolistRepo;
        public UpdateToDoListHandler(IToDoListRepository todolistRepository)
        {
            _todolistRepo = todolistRepository;
        }
      
      

        public async Task<ToDoListResponse> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            var todolistEntity = ToDoListUpdateMapper.Mapper.Map<ToDoList>(request);
            if (todolistEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newToDoList =await _todolistRepo.UpdateToDoList(todolistEntity);
            var todolistResponse = ToDoListUpdateMapper.Mapper.Map<ToDoListResponse>(newToDoList);
            return todolistResponse;

        }
    }
}
