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
    public class ToDoListRepository :IToDoListRepository
    {
        private ApplicationDbContext _appDbContext;
        public ToDoListRepository(ApplicationDbContext applicationDbContext)  {
            _appDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ToDoList>> GetToDoLists(string UserId)
        {
        
            return await _appDbContext.toDoLists.Where(a => a.UserId == UserId).ToListAsync();
            
        }

        public async Task<IEnumerable<ToDoList>> GetToDoListByID(int toDoListId)
        {
            return await _appDbContext.toDoLists.Where(a => a.Id == toDoListId).ToListAsync();
        }

        public async Task<bool> ToDoListExists(int toDoListId)
        {
         return await _appDbContext.toDoLists.CountAsync(e => e.Id == toDoListId) > 0;
        }

       
    
        public async Task<ToDoList> InsertToDoList(ToDoList toDoList)
        {
           
            await _appDbContext.AddAsync<ToDoList>(toDoList);
            await _appDbContext.SaveChangesAsync();
            return toDoList;
        }
        public async Task DeleteToDoList(int toDoListId)
        {
            ToDoList toDoList = await _appDbContext.toDoLists.FindAsync(toDoListId);
            _appDbContext.toDoLists.Remove(toDoList);
            await _appDbContext.SaveChangesAsync();
        }
      public async Task UpdateToDoList(ToDoList toDoList)
        {
            _appDbContext.Entry(toDoList).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
      
   
       
    }
}
