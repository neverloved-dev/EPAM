using Azure;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;
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
            var categoryToUpdateRequest = client.GetAsync("api/categories/7");
            var categoryToUpdate = await categoryToUpdateRequest.Result.Content.ReadAsStringAsync();
            var category = System.Text.Json.JsonSerializer.Deserialize<Category>(categoryToUpdate);
            category.CategoryName = "Updated";
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/categories/7",content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var updatedCategoryRequest = client.GetAsync("api/categories/7");
            var updatedCategoryString = await updatedCategoryRequest.Result.Content.ReadAsStringAsync();
            var updatedCategoryObject = System.Text.Json.JsonSerializer.Deserialize<Category>(updatedCategoryString);
            Assert.Equal("Updated", updatedCategoryObject.CategoryName);
        }

        [Fact]
        public async Task PostCategoryReturns200WithNewCategoryInsideList()
        {
            var client = _applicationFactory.CreateClient();
            var category = new Category
            {
                //CategoryID = 2,
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
        [InlineData(3)]
        [InlineData(4)]
        public async Task ReturnsSingleCategoryWith200Response(int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/categories/{categoryId}");
            response.EnsureSuccessStatusCode();
            var resultCategoryJson = await response.Content.ReadAsStringAsync();
            var resultCategory = System.Text.Json.JsonSerializer.Deserialize<Category>(resultCategoryJson.ToString());
            Assert.Equal(categoryId, resultCategory.CategoryID);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        public async void Deletes_SingleCategory_With200Response(int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync($"/api/categories/{categoryId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}