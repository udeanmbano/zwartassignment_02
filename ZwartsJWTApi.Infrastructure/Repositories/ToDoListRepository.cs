using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartsJWTApi.Core.Entities;
using ZwartsJWTApi.Core.Repositories;
using ZwartsJWTApi.Infrastructure;
using ZwartsJWTApi.Infrastructure.Repositories.Base;

namespace ZwartsJWTApi.Repositories
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        async Task<IEnumerable<ToDoList>> IToDoListRepository.GetToDoLists(string UserId)
        {
            return await _appDbContext.toDoLists.Where(a => a.UserId.Equals(UserId)).ToListAsync();
        }

        async Task<IEnumerable<ToDoList>> IToDoListRepository.GetToDoListByID(int toDoListId)
        {
            return await _appDbContext.toDoLists.Where(a => a.Id == toDoListId).ToListAsync();
        }

        async Task<bool> IToDoListRepository.ToDoListExists(int toDoListId)
        {
         return await _appDbContext.toDoLists.CountAsync(e => e.Id == toDoListId) > 0;
        }

       
    
        public async Task InsertToDoList(ToDoList toDoList)
        {
           
            await _appDbContext.AddAsync<ToDoList>(toDoList);
            await _appDbContext.SaveChangesAsync();
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
