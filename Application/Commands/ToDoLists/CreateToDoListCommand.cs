using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands.Responses;

namespace ZwartsJWTApi.Application.Commands
{
    public class CreateToDoListCommand : IRequest<ToDoListResponse>
    {
    
   
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
       
    }

    }

