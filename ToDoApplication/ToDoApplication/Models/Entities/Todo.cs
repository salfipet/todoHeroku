using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Models.Entities
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }

        public string Description { get; set; }

        public Assignee Assignee { get; set; }

        public long? AssigneeId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime DueAt { get; set; }
        public Todo()
        {
            IsUrgent = false;
            IsDone = false;
            
        }
    }
}
