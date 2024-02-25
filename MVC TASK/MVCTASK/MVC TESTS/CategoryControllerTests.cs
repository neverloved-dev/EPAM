using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using MVCTASK.Controllers;
using MVCTASK.Models;
using Newtonsoft.Json;

namespace MVC_TESTS
{

    public class CategoryControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CategoryControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Categories_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Category/Categories");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CategoryForm_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Category/CategoryForm");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var categoryToUpdate = new Category
            {
                // Provide valid properties for the category to update
            };

            var json = JsonConvert.SerializeObject(categoryToUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Assuming there is a category with ID 1 for testing purposes
            var response = await client.PostAsync("/Category/UpdateCategory/1", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode); // Assuming UpdateCategory returns NoContent on success
        }

        [Fact]
        public async Task AddNewCategory_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var newCategory = new Category
            {
                // Provide valid properties for the new category
            };

            var json = JsonConvert.SerializeObject(newCategory);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Category/AddNewCategory", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode); // Assuming AddNewCategory returns NoContent on success
        }
    }
}
