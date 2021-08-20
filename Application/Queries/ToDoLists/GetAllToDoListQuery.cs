using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.GetAllToDoList.ToDoListItem;
using AutoMapper;
using MediatR;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace Application.Queries.GetAllToDoList.ToDoLists
{
    public class GetAllToDoListQuery : IRequest<IEnumerable<ToDoList>>
    {
        public string UserID { get; set; }
        public class GetAllToDoListQueryHandler : IRequestHandler<GetAllToDoListQuery, IEnumerable<ToDoList>>
        {
            private readonly IToDoListRepository _todoListRepo;
            private readonly IMapper _mapper;

            public GetAllToDoListQueryHandler(IToDoListRepository todoListRepo, IMapper mapper)
            {
                _todoListRepo = todoListRepo;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<ToDoList>> Handle(GetAllToDoListQuery request, CancellationToken cancellationToken)
            {
                var toDoLists = await _todoListRepo.GetToDoLists(request.UserID);
                return  toDoLists;
            }

           
        }
    }
}