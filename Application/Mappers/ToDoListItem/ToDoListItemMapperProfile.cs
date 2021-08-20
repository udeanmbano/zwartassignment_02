using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Mappers.ToDoListItem
{
   public class ToDoListItemMapperProfile:Profile
    {
        public ToDoListItemMapperProfile()
        {
            CreateMap<ToDoListItems, ToDoListItemResponse>().ReverseMap();
            CreateMap<ToDoListItems, CreateToDoListItemCommand>().ReverseMap();
            
        }
    }

    public class ToDoListItemUpdateMapperProfile : Profile
    {
        public ToDoListItemUpdateMapperProfile()
        {
            CreateMap<ToDoListItems, ToDoListItemResponse>().ReverseMap();
            CreateMap<ToDoListItems, UpdateToDoListItemCommand>().ReverseMap();

        }
    }
    public class ToDoListItemMarkMapperProfile : Profile
    {
        public ToDoListItemMarkMapperProfile()
        {
            CreateMap<ToDoListItems, ToDoListItemResponse>().ReverseMap();
            CreateMap<ToDoListItems, MarkToDoListItemCommand>().ReverseMap();

        }
    }
    public class ToDoListItemDeleteMapperProfile : Profile
    {
        public ToDoListItemDeleteMapperProfile()
        {
            CreateMap<ToDoListItems, MessageResponse>().ReverseMap();
            CreateMap<ToDoListItems, DeleteToDoListItemCommand>().ReverseMap();

        }
    }
}
