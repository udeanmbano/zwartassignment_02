﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZwartsJWTApi.Domain.Entities;

namespace ZwartsJWTApi.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //added user to do list and items to application db context
        public DbSet<User> UserLists { get; set; }
        public DbSet<ToDoList> toDoLists { get; set; }
        public DbSet<ToDoListItems> toDoListItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoListItems>(table =>
            {
                table.HasKey(x => x.ToDoListItemId);

                table.HasOne(x => x.toDoList)
                .WithMany(x => x.toDoListItems)
                .HasForeignKey(x => x.ToDoListId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            });

          builder.Entity<ToDoList>(table =>
            {
                table.HasKey(x => x.Id);

                table.HasOne(x => x.User)
                .WithMany(x => x.toDoList)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(builder);
        }

    }
}
