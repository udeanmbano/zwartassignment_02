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

        public async Task DeleteToDoListItem(int toDoListId)
        {
            ToDoListItems toDoListItem = await _appDbContext.toDoListItems.FindAsync(toDoListId);
            _appDbContext.toDoListItems.Remove(toDoListItem);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoListItems>> GetToDoItemLists(int toDoListId)
        {
            return await _appDbContext.toDoListItems.Where(a => a.ToDoListId == toDoListId).ToListAsync();
        }

        public async Task<IEnumerable<ToDoListItems>> GetToDoListItemByID(int toDoListItemId)
        {
            return await _appDbContext.toDoListItems.Where(a => a.ToDoListItemId == toDoListItemId).ToListAsync();
        }

        public async Task InsertToDoListItem(ToDoListItems toDoListItems)
        {
            await _appDbContext.AddAsync<ToDoListItems>(toDoListItems);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task MarkToDone(ToDoListItems toDoListItems)
        {
            _appDbContext.Entry(toDoListItems).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

     

        public async Task<bool> ToDoListItemExists(int toDoListItemId)
        {
            return await _appDbContext.toDoLists.CountAsync(e => e.Id == toDoListItemId) > 0;
        }

        public async Task UpdateToDoListItem(ToDoListItems toDoListItems)
        {
            _appDbContext.Entry(toDoListItems).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }


        }
}
