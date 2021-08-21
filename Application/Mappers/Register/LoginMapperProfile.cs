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
   public class LoginMapperProfile:Profile
    {
        public LoginMapperProfile()
        {
            CreateMap<LoginModel, LoginResponse>().ReverseMap();
            CreateMap<LoginModel, LoginCommand>().ReverseMap();
            
        }
    }

   
}
