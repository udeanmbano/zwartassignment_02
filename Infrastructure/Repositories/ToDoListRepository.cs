﻿using Microsoft.EntityFrameworkCore;
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
    public class ToDoListRepository : IToDoListRepository
    {
        private ApplicationDbContext _appDbContext;
        public ToDoListRepository(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ToDoList>> GetToDoLists(int UserId)
        {

            return await _appDbContext.toDoLists.Where(a => a.UserId == UserId).ToListAsync();

        }

        public async Task<IEnumerable<ToDoList>> GetToDoListByID(int toDoListId)
        {
            return await _appDbContext.toDoLists.Where(a => a.Id == toDoListId).ToListAsync();
        }

        public async Task<bool> ToDoListExists(int toDoListId)
        {
            bool check =false;
            try
            {
                check = await _appDbContext.toDoLists.CountAsync(e => e.Id == toDoListId) > 0;
            }
            catch (Exception f)
            {

                
            }
            return check;
        }



        public async Task<ToDoList> InsertToDoList(ToDoList toDoList)
        {
            try
            {
                ToDoList toDoList_ = new ToDoList();
                toDoList_.Name = toDoList.Name;
                toDoList_.Description = toDoList.Description;
                toDoList_.UserId =toDoList.UserId;
              
                await _appDbContext.AddAsync<ToDoList>(toDoList);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

               
            }
            return toDoList;
        }
        public async Task<int> DeleteToDoList(int toDoListId)
        {
            int changes = 0;
            try
            {
                ToDoList toDoList = await _appDbContext.toDoLists.FindAsync(toDoListId);
                _appDbContext.Remove(toDoList);
                changes = await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {
                
               
            }
            return changes;
        }
        public async Task<ToDoList> UpdateToDoList(ToDoList toDoList)
        {
            try
            {
                ToDoList toDoList_ = await _appDbContext.toDoLists.FindAsync(toDoList.Id);
                toDoList_.Name = toDoList.Name;
                toDoList_.Description = toDoList.Description;
       
                _appDbContext.Update(toDoList_);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception f)
            {

             
            }
            return toDoList;
        }



    }
}
