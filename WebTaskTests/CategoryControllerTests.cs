using Azure;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebTask.Models;

namespace WebTaskTests
{
    public class CategoryControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;
        public CategoryControllerTests(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task GetCategoriesReturns200WithListOfCategories()
        {
           var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/categories");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void PutCategoryReturns200()
        {
            var client = _applicationFactory.CreateClient();
            var categoryToUpdateRequest = client.GetAsync("api/categories/1");

            var categoryToUpdate = categoryToUpdateRequest.Result.Content.ReadAsStringAsync();
            // update the category fields
            var json = JsonConvert.SerializeObject(categoryToUpdate);
            var content = new StringContent(json, Encoding.UTF8,, "application/json");
            var response = await client.PutAsync("/api/categories/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostCategoryReturns200WithNewCategoryInsideList()
        {
            var client = _applicationFactory.CreateClient();
            var category = new Category
            {
                CategoryID = 2,
                CategoryName = "Beverages",
                Description = "Drinks"
                
            };
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("/api/categories", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ReturnsSingleCategoryWith200Response(int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/categories/{categoryId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void Deletes_SingleCategory_With200Response(int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync($"/api/categories/{categoryId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}