using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MVCTASK.Models;
using Newtonsoft.Json;
using Xunit;

namespace MVCTASK.Tests
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

            var product = new Product
            {
                // Provide valid properties for the new product
            };

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Product/New", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Fact]
        public async Task Edit_Post_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();

            // Assuming there is a product with ID 1 for testing purposes
            var existingProduct = new Product
            {
                // Provide valid properties for the existing product
            };

            var json = JsonConvert.SerializeObject(existingProduct);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Product/Edit/1", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
    }
}
