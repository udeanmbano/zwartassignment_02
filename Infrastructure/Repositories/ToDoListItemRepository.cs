using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Domain.Entities;
using ZwartsJWTApi.Infrastructure;
using ZwartsJWTApi.Infrastructure.Data;

namespace ZwartsJWTApi.Repositories
{
    public class ToDoListItemRepository:IToDoListItemRepository
    {
        ApplicationDbContext _appDbContext;
        public ToDoListItemRepository(ApplicationDbContext applicationDbContext)  {
            _appDbContext = applicationDbContext;
        }

        public async Task<int> DeleteToDoListItem(int toDoListId)
        {
            int change = 0;
            ToDoListItems toDoListItem = await _appDbContext.toDoListItems.FindAsync(toDoListId);
            _appDbContext.toDoListItems.Remove(toDoListItem);
            change=await _appDbContext.SaveChangesAsync();
            return change;
        }

        public async Task<IEnumerable<ToDoListItems>> GetToDoItemLists(int toDoListId)
        {
            return await _appDbContext.toDoListItems.Where(a => a.ToDoListId == toDoListId).ToListAsync();
        }

        public async Task<IEnumerable<ToDoListItems>> GetToDoListItemByID(int toDoListItemId)
        {
            return await _appDbContext.toDoListItems.Where(a => a.ToDoListItemId == toDoListItemId).ToListAsync();
        }

        public async Task <ToDoListItems> InsertToDoListItem(ToDoListItems toDoListItems)
        {
            await _appDbContext.AddAsync<ToDoListItems>(toDoListItems);
            await _appDbContext.SaveChangesAsync();
            return toDoListItems;
        }

        public async Task<ToDoListItems> MarkToDone(ToDoListItems toDoListItems)
        {
            toDoListItems.ItemDoneStatus = true;
            _appDbContext.Entry(toDoListItems).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return toDoListItems;
        }

     

        public async Task<bool> ToDoListItemExists(int toDoListItemId)
        {
            return await _appDbContext.toDoListItems.CountAsync(e => e.ToDoListItemId == toDoListItemId) > 0;
        }

        public async Task<ToDoListItems> UpdateToDoListItem(ToDoListItems toDoListItems)
        {
            _appDbContext.Entry(toDoListItems).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return toDoListItems;
        }


        }
}
