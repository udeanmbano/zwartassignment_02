﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using ZwartsJWTApi.Core.Entities;

namespace ZwartsJWTApi.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ToDoList> toDoList { get; set; }
    }
}
