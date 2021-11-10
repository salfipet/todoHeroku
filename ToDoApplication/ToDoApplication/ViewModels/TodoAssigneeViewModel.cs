using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.ViewModels
{
    public class TodoAssigneeViewModel
    {
        public Todo Todo { get; set; }
        public List<Todo> AllTodos { get; set; }
        public Assignee Assignee { get; set; }
        public List<Assignee> AllAssignees { get; set; }

    }
}
