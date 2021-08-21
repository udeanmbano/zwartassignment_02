using System.Collections.Generic;
using ZwartsJWTApi.Domain.Entities;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserIdentity { get; set; }
        public virtual ICollection<ToDoList> toDoList { get; set; }
    }
}