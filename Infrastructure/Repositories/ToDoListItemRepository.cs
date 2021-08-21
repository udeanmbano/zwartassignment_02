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
            try
            {
                ToDoListItems toDoListItem = await _appDbContext.toDoListItems.FindAsync(toDoListId);
                _appDbContext.Remove(toDoListItem);
                change = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

               
            }
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
            try
            {
                await _appDbContext.AddAsync<ToDoListItems>(toDoListItems);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

            }
            return toDoListItems;
        }

        public async Task<ToDoListItems> MarkToDone(ToDoListItems toDoListItems)
        {
            try
            {
                ToDoListItems toDoListItemss = await _appDbContext.toDoListItems.FindAsync(toDoListItems.ToDoListItemId);
                toDoListItemss.ItemDoneStatus = true;
                _appDbContext.Update(toDoListItemss);

               await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

               
            }
            return toDoListItems;
        }

     

        public async Task<bool> ToDoListItemExists(int toDoListItemId)
        {
            bool change = false;
            try
            {
                change = await _appDbContext.toDoListItems.CountAsync(e => e.ToDoListItemId == toDoListItemId) > 0;
            }
            catch (Exception f)
            {

                
            }

            return change;
        }

        public async Task<ToDoListItems> UpdateToDoListItem(ToDoListItems toDoListItems)
        {
            try
            {
                ToDoListItems toDoListItemss = await _appDbContext.toDoListItems.FindAsync(toDoListItems.ToDoListItemId);
                toDoListItemss.ItemDoneStatus = toDoListItems.ItemDoneStatus;
                toDoListItemss.ToDoItem=toDoListItems.ToDoItem;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

            }
            return toDoListItems;
        }


        }
}
