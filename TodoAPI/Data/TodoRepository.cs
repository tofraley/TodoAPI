using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Services;

namespace TodoAPI.Data
{

    public class TodoRepository : ITodoRepository
    {
        public TodoRepository()
        {
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            throw new NotImplementedException();
        }

        public Todo GetTodo(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
