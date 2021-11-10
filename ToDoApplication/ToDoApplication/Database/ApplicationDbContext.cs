using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; } //s tim service bude pracovat, bude mit tutot structuru
        public DbSet<Assignee> Assignees { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignee>()
                .HasMany<Todo>(t => t.TodoTasks)
                .WithOne(a => a.Assignee)
                .HasForeignKey(a => a.AssigneeId)
                .IsRequired(false);
              
        }
    }
}
