using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Net.Http.Headers;
using MVCTASK.Models;
using MVCTASK.Shared;
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
            var initResponse = await client.GetAsync("/Product/New");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);

                var formModel = new MultipartFormDataContent
                {
                    { new StringContent("some Name"), "ProductName" },
                    { new StringContent("1"), "UnitPrice" },
                    { new StringContent("5"), "CategoryID" },
                    {new StringContent(antiForgeryValues.fieldValue),AntiForgeryTokenExtractor.AntiForgeryFieldName}
                };
            //creating post request with the cookie
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Product/New");
            postRequest.Headers.Add("Cookie",new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            postRequest.Content = formModel;
            var response = await client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task Edit_Post_ReturnsSuccessStatusCode()
        {
            var client = _factory.CreateClient();
            var initResponse = await client.GetAsync("/Product/Edit/1");
            var antiForgeryValues = await AntiForgeryTokenExtractor.ExtractAntiForgeryValues(initResponse);
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
            { new StringContent(existingProduct.CategoryID.ToString()), "Category" },
            {new StringContent(antiForgeryValues.fieldValue),AntiForgeryTokenExtractor.AntiForgeryFieldName}
        };

            var putRequest = new HttpRequestMessage(HttpMethod.Post, "/Product/Edit/1");
            putRequest.Headers.Add("Cookie", new CookieHeaderValue(AntiForgeryTokenExtractor.AntiForgeryCookieName, antiForgeryValues.cookieValue).ToString());
            putRequest.Content = formData;
            var response = await client.SendAsync(putRequest);

            response.EnsureSuccessStatusCode();
            // checking if the product was actually updated\
            var finalGet = await client.GetAsync("/Product/1");
            var stringRep = finalGet.Content.ReadAsStringAsync();
            var newProduct = JsonSerializer.Deserialize<Product>(stringRep);
        }
    }
}
