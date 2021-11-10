using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Services;
using ToDoApplication.ViewModels;
using ToDoApplication.Models.Entities;

namespace ToDoApplication.Controllers
{
    [Route("assignee")]
    public class AssigneeController : Controller
    {
        public AssigneeService AssigneeService { get; }

        public AssigneeController(AssigneeService service)
        {
            AssigneeService = service;
        }

        [HttpGet]
        public IActionResult Assignees()
        {
            var viewModel = new AssigneViewModel() { AllAssignees = AssigneeService.FindAssignees() };
            return View(viewModel);
        }

        [HttpGet("addnew")]
        public IActionResult AdditingAssigne()
        {
            return View();
        }

        [HttpPost("addnew")]
        public IActionResult AddAssigne([FromForm] Assignee assignee)
        {
            var savedAssignee = AssigneeService.Add(assignee);
            return RedirectToAction("Assignees");
        }

        [HttpPost("delete/{id:long}")]
        public IActionResult Delete([FromRoute] long id)
        {
            AssigneeService.Delete(id);
            return RedirectToAction("Assignees");
        }

        [HttpGet("edit/{id:long}")]
        public IActionResult EditingAssignee([FromRoute] long id)
        {
            return View(new AssigneViewModel() { Assignee = AssigneeService.FindById(id) });
        }

        [HttpPost("edit/{id:long}")]
        public IActionResult Edit([FromForm] Assignee assignee, [FromRoute] long id)
        {
            
            AssigneeService.Edit(assignee, id);
            return RedirectToAction("Assignees");
        }

       
    }
}
