using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Core.Entities;
using ZwartsJWTApi.Core.Repositories.Base;

namespace ZwartsJWTApi.Core.Repositories
{
   public interface IToDoListRepository : IRepository<ZwartsJWTApi.Core.Entities.ToDoList>
    {
        Task<IEnumerable<ToDoList>> GetToDoLists(String UserId);
        Task<IEnumerable<ToDoList>> GetToDoListByID(int toDoListId);
        Task InsertToDoList(ToDoList toDoList);
        Task DeleteToDoList(int toDoListId);
        Task UpdateToDoList(ToDoList toDoList);
        Task<bool> ToDoListExists(int toDoListId);
      
    }
}
