using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TodoAPI.Data;
using TodoAPI.Tests.Data;
using Xunit;

namespace TodoAPI.Tests
{
    public class TodoController_IT : IClassFixture<WebApplicationFactory<TodoAPI.Startup>>
    {
        private readonly WebApplicationFactory<TodoAPI.Startup> _factory;
        private readonly HttpClient _client;

        public TodoController_IT(WebApplicationFactory<TodoAPI.Startup> factory)
        {
            _factory = factory;
            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ITodoRepository, MockTodoRepository>();
                });
            })
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("get", "/todos")]
        [InlineData("get", "/todos/1")]
        [InlineData("delete", "/todos/1")]
        public async void Endpoints_Returns_Success_And_ContentType(string method, string url)
        {
            // Arrange
            var req = new HttpRequestMessage(new HttpMethod(method), url);

            // Act
            var response = await _client.SendAsync(req);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
