using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;

namespace Application.Queries.GetAllToDoList.ToDoListItem
{
    public class GetAllToDoListItemQueryById : IRequest<IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>>
    {
        public int Id { get; set; }
        public class GetAllToDoListByIdQueryHandler : IRequestHandler<GetAllToDoListItemQueryById, IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>>
        {
            private readonly IToDoListItemRepository _todoListItemRepo;
            private readonly IMapper _mapper;

            public GetAllToDoListByIdQueryHandler(IToDoListItemRepository todoListItemRepo, IMapper mapper)
            {
                _todoListItemRepo = todoListItemRepo;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<ZwartsJWTApi.Domain.Entities.ToDoListItems>> Handle(GetAllToDoListItemQueryById request, CancellationToken cancellationToken)
            {
                var toDoLists = await _todoListItemRepo.GetToDoListItemByID(request.Id);
                return  toDoLists;
            }

           
        }
    }
}