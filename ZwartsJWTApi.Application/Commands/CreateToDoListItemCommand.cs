using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Responses;

namespace ZwartsJWTApi.Application.Commands
{
    class CreateToDoListItemCommand : IRequest<ToDoListItemResponse>
    {
    

        public int ToDoListItemId { get; set; }
        public string ToDoItem { get; set; }
        public bool ItemDoneStatus { get; set; }
        public int ToDoListId { get; set; }
    }
}
