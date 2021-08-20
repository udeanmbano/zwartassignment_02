using AutoMapper;
using ZwartsJWTApi.Application.Mappers;
using ZwartsJWTApi.Domain.Entities;

namespace Application.Queries.GetAllToDoList.ToDoListItem
{
    public class GetAllToDoItemList : IMapFrom<GetAllToDoListItemResponse>
    {
        public int ToDoListItemId { get; set; }
       public string ToDoItem { get; set; }
        public bool ItemDoneStatus { get; set; }
        public int ToDoListId { get; set; }
        public virtual ZwartsJWTApi.Domain.Entities.ToDoList toDoList { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAllToDoListItemResponse, GetAllToDoItemList>();
        }
    }
}