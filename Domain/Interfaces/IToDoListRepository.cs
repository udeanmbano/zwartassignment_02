﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Domain.Entities;


namespace ZwartsJWTApi.Application.Repositories
{
   public interface IToDoListRepository 
    {
        Task<IEnumerable<ToDoList>> GetToDoLists(String UserId);
        Task<IEnumerable<ToDoList>> GetToDoListByID(int toDoListId);
        Task<ToDoList>InsertToDoList(ToDoList toDoList);
        Task DeleteToDoList(int toDoListId);
        Task UpdateToDoList(ToDoList toDoList);
        Task<bool> ToDoListExists(int toDoListId);
      
    }
}