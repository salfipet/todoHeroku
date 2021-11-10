using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Database;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.Services
{
    public class AssigneeService
    {
        private ApplicationDbContext DbContext { get; }

        public AssigneeService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Assignee> FindAssignees()
        {
            return DbContext.Assignees.ToList();

        }

        public Assignee Add(Assignee assignee)
        {
            var savedAssignee = DbContext.Assignees.Add(assignee).Entity;
            DbContext.SaveChanges();
            return savedAssignee;
        }

        public void Delete(long id)
        {
            var deletedAssignee = DbContext.Assignees.Find(id);
            DbContext.Assignees.Remove(deletedAssignee);
            DbContext.SaveChanges();
        }

        public void Edit(Assignee assignee, long id)
        {
            var editedAssignee = DbContext.Assignees.Find(id);
            editedAssignee.Name = assignee.Name;
            editedAssignee.Email = assignee.Email;
          
            DbContext.SaveChanges();
        }

        public Assignee FindById(long id)
        {
            return DbContext.Assignees.FirstOrDefault(user => user.Id.Equals(id));
        }

       
    }
}
