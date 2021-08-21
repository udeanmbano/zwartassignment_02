using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Domain.Entities;


namespace ZwartsJWTApi.Application.Repositories
{
   public interface IToRegister
    {
        Task<Response> RegisterUser(RegisterModel register);
       
    }
}
