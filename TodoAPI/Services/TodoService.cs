using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public interface ITodoService
    {
        bool DeleteTodo(int id);
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodo(int id);
    }

    public class TodoService : ITodoService
    {
        private ITodoRepository Repo { get; set; }

        public TodoService(ITodoRepository repo)
        {
            Repo = repo;
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return Repo.GetAllTodos();
        }

        public Todo GetTodo(int id)
        {
            return Repo.GetTodo(id);
        }

        public bool DeleteTodo(int id)
        {
            return Repo.DeleteTodo(id);
        }
    }
}
