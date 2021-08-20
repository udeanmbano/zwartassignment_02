using AutoMapper;
using ZwartsJWTApi.Application.Mappers;

namespace Application.Queries.GetAllToDoList
{
    public class GetAllToDoList : IMapFrom<GetAllToDoListResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetAllToDoListResponse, GetAllToDoList>();
        }
    }
}