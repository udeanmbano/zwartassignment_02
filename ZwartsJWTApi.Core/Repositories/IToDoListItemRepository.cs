using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Core.Entities;
using ZwartsJWTApi.Core.Repositories.Base;

namespace ZwartsJWTApi.Core.Repositories
{
    public interface IToDoListItemRepository : IRepository<ZwartsJWTApi.Core.Entities.ToDoListItems>
    {
        Task<IEnumerable<ToDoListItems>> GetToDoItemLists(int toDoListId);
        Task<IEnumerable<ToDoListItems>> GetToDoListItemByID(int toDoListId);
        Task InsertToDoListItem(ToDoListItems toDoListItems);
        Task DeleteToDoListItem(int toDoListId);
        Task UpdateToDoListItem(ToDoListItems toDoListItems);
        Task<bool> ToDoListItemExists(int toDoListId);
        Task MarkToDone(ToDoListItems toDoListItems);
      
    }
}
