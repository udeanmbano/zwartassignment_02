using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Commands.Responses
{
   public  class ToDoListItemResponse
    {

        public int ToDoListItemId { get; set; }
       public string ToDoItem { get; set; }
        public bool ItemDoneStatus { get; set; }
        public int ToDoListId { get; set; }
        public virtual ToDoList toDoList { get; set; }

    }
}
