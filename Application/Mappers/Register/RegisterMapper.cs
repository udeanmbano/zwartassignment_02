using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Mappers.ToDoListItem;

namespace ZwartsJWTApi.Application.Mappers.ToDoLists
{
   public class RegisterMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<RegisterMapperProfile>();
               
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
  
}
