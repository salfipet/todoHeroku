using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Database;
using ToDoApplication.ViewModels;
using ToDoApplication.Services;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.Controllers
{
    [Route("todo")]
    public class TodoController : Controller
    {
        private TodoService TodoService { get; }
        private AssigneeService AssigneeService { get; }

        public TodoController(TodoService todoService, AssigneeService assigneeService)
        {
            TodoService = todoService;
            AssigneeService = assigneeService;
        }

        /*nebo [HttpGet("")]
         * [HttpGet("list")]*/

        [Route("")]
        [Route("list")]
        [HttpGet]
        public string List2()
        {
            return "This is my first todo";
        }

        [HttpGet("view")]
        public IActionResult List()
        {
            List<string> todos = new List<string>() { "html" };
            return View(todos);
        }

        [HttpGet("model")]
        public IActionResult Index([FromQuery] string isActive)
        {
            if(isActive is null)
            {
                var viewModel = new IndexViewModel() { AllTodos = TodoService.FindAll() };
                return View(viewModel);
            }
            if (isActive == "true")
            {
                var viewModel = new IndexViewModel() { AllTodos = TodoService.FindActive() };
                return View(viewModel);
            }
            else
            {
                var viewModel = new IndexViewModel() { AllTodos = TodoService.FindDeactive() };
                return View(viewModel);
            }
            
            
        }
        [HttpGet("add")]
        public IActionResult Adding()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult AddTodo([FromForm] Todo todo)
        {
            var savedTodo = TodoService.Add(todo);
            return RedirectToAction("Index");
        }

        [HttpPost("delete/{id:long}")]
        public IActionResult Delete([FromRoute] long id)
        {
            TodoService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id:long}")]
        public IActionResult Editing([FromRoute] long id)
        {
            return View(new TodoAssigneeViewModel() { Todo = TodoService.FindById(id) , AllAssignees = AssigneeService.FindAssignees()});
        }

        [HttpPost("edit/{id:long}")]
        public IActionResult Edit([FromForm] Todo todo, [FromRoute] long id, long assId)
        {
            TodoService.Edit(todo,id,assId);
            return RedirectToAction("Index");
        }

        [HttpPost("search")]
        public IActionResult Search(string searchingWord)
        {
           var viewModel = new IndexViewModel() { AllTodos = TodoService.Search(searchingWord) };
            return View("Index",viewModel);
        }

        [HttpPost("searching")]
        public IActionResult SearchDate(DateTime searchingDate)
        {
            var viewModel = new IndexViewModel() { AllTodos = TodoService.SearchDate(searchingDate) };
            return View("Index", viewModel);
        }

        [HttpGet("seetodos/{id:long}")]
        public IActionResult AssigneesTodos([FromRoute] long id)
        {
            return View(new TodoAssigneeViewModel() { AllTodos = TodoService.FindTaskByAssignee(id)});
        }

        [HttpGet("seetassignee/{id:long}")]
        public IActionResult TodosAssignee([FromRoute] long id)
        {
            return View(new TodoAssigneeViewModel() { Assignee = TodoService.FindAssigneByTask(id) });
        }
    }
}
