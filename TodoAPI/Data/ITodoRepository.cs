using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodo(int id);
        bool DeleteTodo(int id);
    }
}
