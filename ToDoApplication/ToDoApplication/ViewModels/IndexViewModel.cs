using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.ViewModels
{
    public class IndexViewModel
    {
        public Todo Todo { get; set; }
        public List<Todo> AllTodos { get; set; }
    }
}
