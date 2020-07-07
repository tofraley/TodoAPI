using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoAPI.Models;
using TodoAPI.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : Controller
    {
        private ITodoService _todoService { get; set; }

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAllTodos()
        {
            IEnumerable<Todo> response = _todoService.GetAllTodos();

            return response;
        }

        [HttpGet("{id}")]
        public Todo GetTodo(int id)
        {
            Todo response = _todoService.GetTodo(id);

            return response;
        }

        [HttpDelete("{id}")]
        public bool DeleteTodo(int id)
        {
            bool response = _todoService.DeleteTodo(id);

            return response;
        }
    }
}
