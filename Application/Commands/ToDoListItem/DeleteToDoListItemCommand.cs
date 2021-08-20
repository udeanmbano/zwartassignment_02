using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Application.Commands.Responses;

namespace ZwartsJWTApi.Application.Commands.ToDoListItem
{
    public class DeleteToDoListItemCommand : IRequest<MessageResponse>
    {

        public int ToDoListItemId { get; set; }
        public string ToDoItem { get; set; }
        public bool ItemDoneStatus { get; set; }
        public int ToDoListId { get; set; }
     
    }

}

