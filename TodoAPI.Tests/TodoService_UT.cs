using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.Tests.Data;
using Xunit;

namespace TodoAPI.Tests
{
    public class TodoService_UT
    {
        

        [Fact]
        public void GetAllTodos_Returns_All_Todos()
        {
            // Arrange
            MockTodoRepository repo = new MockTodoRepository();
            TodoService todoService = new TodoService(repo);

            // Act
            var actual = todoService.GetAllTodos();

            // Assert
            Assert.True(actual.ToList().Count == 3);
        }

        [Fact]
        public void GetTodo_Returns_Correct_Todo()
        {
            // Arrange
            MockTodoRepository repo = new MockTodoRepository();
            TodoService todoService = new TodoService(repo);
            int id = 3;

            // Act
            var actual = todoService.GetTodo(id);
            var expected = repo.Todos.Last();
            // Assert 
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void DeleteTodo_Works()
        {
            // Arrange
            MockTodoRepository repo = new MockTodoRepository();
            TodoService todoService = new TodoService(repo);
            int id = 3;

            // Act
            var success = todoService.DeleteTodo(id);
            var actual = todoService.GetAllTodos();
            
            // Assert
            Assert.True(success);
            Assert.True(actual.ToList().Count == 2);
            Assert.DoesNotContain(actual, t => t.Id == id);
        }
    }
}
