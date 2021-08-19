using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands;
using ZwartsJWTApi.Application.Responses;
using ZwartsJWTApi.Core.Entities;

namespace ZwartsJWTApi.Application.Mappers
{
   public class ToDoListMapperProfile:Profile
    {
        public ToDoListMapperProfile()
        {
            CreateMap<ToDoList,ToDoListResponse>().ReverseMap();
            CreateMap<ToDoList, CreateToDoListCommand>().ReverseMap();
        }
    }
}
