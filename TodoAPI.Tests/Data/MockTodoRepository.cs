using System.Collections.Generic;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Tests.Data
{

    public class MockTodoRepository : ITodoRepository
    {
        public List<Todo> Todos = new List<Todo>() {
            new Todo()
            {
                Id=1,
                IsChecked = false,
                Content = "my first todo"
            },
            new Todo()
            {
                Id=2,
                IsChecked = false,
                Content = "my second todo"
            },
            new Todo()
            {
                Id=3,
                IsChecked = false,
                Content = "my third todo"
            }
        };

        public IEnumerable<Todo> GetAllTodos()
        {
            return Todos;
        }

        public Todo GetTodo(int id)
        {
            Todo result = null;

            foreach (Todo t in Todos)
            {
                if (t.Id == id)
                {
                    result = t;
                }
            }

            return result;
        }

        public bool DeleteTodo(int id)
        {
            Todos.RemoveAll(todo => todo.Id == id);

            return true;
        }
    }
}
