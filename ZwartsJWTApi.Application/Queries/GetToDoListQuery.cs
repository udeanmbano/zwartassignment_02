using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Core.Entities;

namespace ZwartsJWTApi.Application.Queries
{
   public class GetToDoListQuery: IRequest<List<ToDoList>>
    {

    }
}
