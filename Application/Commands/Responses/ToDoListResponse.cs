using System;
using System.Collections.Generic;
using System.Text;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Application.Commands.Responses
{
   public  class ToDoListResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<ToDoListItems> toDoListItems { get; set; }
    }
}
