using Azure;
using System.Net;

namespace WebTaskTests
{
    public class CategoryControllerTests
    {
        private static HttpClient _httpClient;
        public CategoryControllerTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:7910");
        }

        [Fact]
        public async Task GetCategoriesReturns200WithListOfCategories()
        {
            var response = await _httpClient.GetAsync("/api/categories");
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
        public void ReturnsSingleCategoryWith200Response(int categoryId)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeletesSingleCategoryWith200Response()
        {
            throw new NotImplementedException();
        }
    }
}