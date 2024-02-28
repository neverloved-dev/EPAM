using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MVCTASK.Models;
using Newtonsoft.Json;
using Xunit;

namespace MVC_TESTS
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ListAll_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Product/ListAll");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task New_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Product/New");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Edit_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            // Assuming there is a product with ID 1 for testing purposes
            var response = await client.GetAsync("/Product/Edit/1");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
    public async Task New_Post_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            var formData = new MultipartFormDataContent
        {

            { new StringContent("some Name"), "ProductName" },
            { new StringContent("1"), "UnitPrice" },
            { new StringContent("5"), "Category" }
        };

            var response = await client.PostAsync("/Product/New", formData);

            response.EnsureSuccessStatusCode();
            Assert.Equal(StatusCodes.Status200OK.ToString(),response.StatusCode.ToString());
        }

        [Fact]
        public async Task Edit_Post_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            // Assuming there is a product with ID 1 for testing purposes
            var existingProduct = new Product
            {
                ProductName = "some Name",
                UnitPrice = Decimal.One,
                CategoryID = 5
            };

            var formData = new MultipartFormDataContent
        {
            { new StringContent(existingProduct.ProductName), "ProductName" },
            { new StringContent(existingProduct.UnitPrice.ToString()), "UnitPrice" },
            { new StringContent(existingProduct.CategoryID.ToString()), "Category" }
        };

            var response = await client.PostAsync("Product/Edit/1", formData);

            response.EnsureSuccessStatusCode();
            Assert.Equal(StatusCodes.Status302Found, (int)response.StatusCode);
        }
    }
}
