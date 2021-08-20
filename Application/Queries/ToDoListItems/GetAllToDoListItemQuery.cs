using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace Application.Queries.GetAllToDoList.ToDoListItem
{
    public class GetAllToDoListItemQuery : IRequest<IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>>
    {
        public int Id { get; set; }
        public class GetAllToDoListItemQueryHandler : IRequestHandler<GetAllToDoListItemQuery, IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>>
        {
            private readonly IToDoListItemRepository _todoListItemRepo;
            private readonly IMapper _mapper;

            public GetAllToDoListItemQueryHandler(IToDoListItemRepository todoListItemRepo, IMapper mapper)
            {
                _todoListItemRepo = todoListItemRepo;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>> Handle(GetAllToDoListItemQuery request, CancellationToken cancellationToken)
            {
                var toDoLists = await _todoListItemRepo.GetToDoItemLists(request.Id);
                return  toDoLists;
            }

           
        }
    }
}