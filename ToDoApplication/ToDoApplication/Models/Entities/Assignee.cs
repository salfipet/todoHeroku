using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Models.Entities
{
    public class Assignee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Todo> TodoTasks { get; set; }
        
    }
}
