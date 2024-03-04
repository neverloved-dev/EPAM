using Azure;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

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
            var response = await client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void PutCategoryReturns200()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PostCategoryReturns200WithNewCategoryInsideList()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ReturnsSingleCategoryWith200Response(int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/products/{categoryId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public void DeletesSingleCategoryWith200Response()
        {
            throw new NotImplementedException();
        }
    }
}