using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Models.Entities;
using ToDoApplication.Database;
using ToDoApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ToDoApplication.Services
{
    public class TodoService
    {
        private ApplicationDbContext DbContext { get; }

        
        public TodoService(ApplicationDbContext dbContext)
        {

            DbContext = dbContext;

        }

        public List<Todo> FindAll()
        {
            return DbContext.Todos.ToList();
        }

        public List<Todo> FindActive()
        {
           return DbContext.Todos.Where(todos => todos.IsDone == false).ToList();
        }
        public List<Todo> FindDeactive()
        {
            return DbContext.Todos.Where(todos => todos.IsDone == true).ToList();
        }

        public Todo Add(Todo todo)
        {
            var savedTodo = DbContext.Todos.Add(todo).Entity;
            savedTodo.CreatedAt = DateTime.Now;
            DbContext.SaveChanges();
            return savedTodo;
        }

        public void Delete(long id)
        {
            var deletedTodo = DbContext.Todos.Find(id);
            DbContext.Todos.Remove(deletedTodo);
            DbContext.SaveChanges();
        }

        public void Edit(Todo todo, long id, long assId)
        {
            var editedTodo = DbContext.Todos.Find(id);
            editedTodo.Title = todo.Title;
            editedTodo.IsDone = todo.IsDone;
            editedTodo.IsUrgent = todo.IsUrgent;
            editedTodo.CreatedAt = todo.CreatedAt;
            editedTodo.DueAt = todo.DueAt;
            editedTodo.Assignee = FindAssigneeById(assId);
            DbContext.SaveChanges();
        }

        public Assignee FindAssigneeById(long id)
        {
           return DbContext.Assignees.Find(id);
        }

        public List<Todo> Search(string searchingWord)
        {
           return DbContext.Todos.Include(t=>t.Assignee).Where(t => t.Title.ToLower().Contains(searchingWord.ToLower()) || t.Description.ToLower().
           Contains(searchingWord.ToLower()) || t.Assignee.Name.ToLower().Contains(searchingWord.ToLower())).ToList();
            
        }

        public List<Todo> SearchDate(DateTime searchingDate)
        {
            return DbContext.Todos.Include(t => t.Assignee).Where(t => t.DueAt.Equals(searchingDate) || t.CreatedAt.Equals(searchingDate)).ToList();

        }

        public Todo FindById(long id)
        {
            return DbContext.Todos.FirstOrDefault(user => user.Id.Equals(id));
        }

        public List<Todo> FindTaskByAssignee(long id)
        {
           return DbContext.Todos.Where(x => x.AssigneeId == id).ToList();
          
        }

        public Assignee FindAssigneByTask(long id)
        {
            var todo = DbContext.Todos.Find(id);
             var idAssignee = todo.AssigneeId;
             return DbContext.Assignees.FirstOrDefault(x => x.Id == idAssignee);
           
         

        }
    }
}
