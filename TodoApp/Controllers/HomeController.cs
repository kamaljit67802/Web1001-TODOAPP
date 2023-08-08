using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // A sample list of TodoItems (for demo purposes; typically fetched from a database)
        private static List<TodoItem> todoItems = new List<TodoItem>
        {
            new TodoItem { ID = 1, Title = "To go to gym", Description = "To do some exercise to stay fit", IsDone = false }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action to show the ToDo list on the home screen
        public IActionResult Index()
        {
            return View(todoItems);
        }

        // Action to mark a task as done
        public IActionResult MarkAsDone(int id)
        {
            var todoItem = todoItems.Find(item => item.ID == id);
            if (todoItem != null)
            {
                todoItem.IsDone = true;
            }
            return RedirectToAction("Index");
        }

        // Action to delete a task
        public IActionResult Delete(int id)
        {
            var todoItem = todoItems.Find(item => item.ID == id);
            if (todoItem != null)
            {
                todoItems.Remove(todoItem);
            }
            return RedirectToAction("Index");
        }

        // Action to show the form for creating a new task (added for completeness, not requested)
        public IActionResult Create()
        {
            return View();
        }

        // POST Action to create a new task
        [HttpPost]
        public IActionResult Create(TodoItem newItem)
        {
            if (ModelState.IsValid)
            {
                // Assign a unique ID to the new item
                int newId = todoItems.Count > 0 ? todoItems.Max(item => item.ID) + 1 : 1;
                newItem.ID = newId;
                todoItems.Add(newItem);
                return RedirectToAction("Index");
            }
            // If ModelState is invalid (e.g., validation failed), return the view with the newItem model to display validation errors
            return View(newItem);
        }
    }
}
