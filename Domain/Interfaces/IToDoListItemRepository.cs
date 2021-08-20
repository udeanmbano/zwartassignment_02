using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Domain.Entities;


namespace ZwartsJWTApi.Application.Repositories
{
    public interface IToDoListItemRepository
    {
        Task<IEnumerable<ToDoListItems>> GetToDoItemLists(int toDoListId);
        Task<IEnumerable<ToDoListItems>> GetToDoListItemByID(int toDoListId);
        Task<ToDoListItems> InsertToDoListItem(ToDoListItems toDoListItems);
        Task<int> DeleteToDoListItem(int toDoListId);
        Task<ToDoListItems> UpdateToDoListItem(ToDoListItems toDoListItems);
        Task<bool> ToDoListItemExists(int toDoListId);
        Task<ToDoListItems> MarkToDone(ToDoListItems toDoListItems);
      
    }
}
