using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Commands.Responses;
using ZwartsJWTApi.Application.Commands.ToDoListItem;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Mappers.ToDoLists
{
   public class ToDoListMapperProfile:Profile
    {
        public ToDoListMapperProfile()
        {
            CreateMap<ToDoList, ToDoListResponse>().ReverseMap();
            CreateMap<ToDoList, CreateToDoListCommand>().ReverseMap();
            
        }
    }

    public class ToDoListUpdateMapperProfile : Profile
    {
        public ToDoListUpdateMapperProfile()
        {
            CreateMap<ToDoList, ToDoListItemResponse>().ReverseMap();
            CreateMap<ToDoList, UpdateToDoListItemCommand>().ReverseMap();

        }
    }

    public class ToDoListDeleteMapperProfile : Profile
    {
        public ToDoListDeleteMapperProfile()
        {
            CreateMap<ToDoList, MessageResponse>().ReverseMap();
            CreateMap<ToDoList, DeleteToDoListItemCommand>().ReverseMap();

        }
    }
}
