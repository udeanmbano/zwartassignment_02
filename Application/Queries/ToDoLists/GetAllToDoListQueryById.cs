using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace Application.Queries.GetAllToDoList.ToDoListItems
{
    public class GetAllToDoListQueryById : IRequest<IEnumerable<ToDoList>>
    {
        public int Id { get; set; }
        public class GetAllToDoListByIdQueryHandler : IRequestHandler<GetAllToDoListQueryById, IEnumerable<ToDoList>>
        {
            private readonly IToDoListRepository _todoListRepo;
            private readonly IMapper _mapper;

            public GetAllToDoListByIdQueryHandler(IToDoListRepository todoListRepo, IMapper mapper)
            {
                _todoListRepo = todoListRepo;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<ToDoList>> Handle(GetAllToDoListQueryById request, CancellationToken cancellationToken)
            {
                var toDoLists = await _todoListRepo.GetToDoListByID(request.Id);
                return  toDoLists;
            }

           
        }
    }
}