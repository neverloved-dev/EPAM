using Azure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebTask.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebTaskTests
{
    public class ProductControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;
        public ProductControllerTests(WebApplicationFactory<Program> applicationFactory)
        { 
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task GetAllProductsReturns200WithListOfProducts()
        {
            var client = _applicationFactory.CreateClient();
           var response = await client.GetAsync("/api/products");
           response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData(7)]
        [InlineData(9)]
        public async Task GetSingleProductsReturnsSingleProduct(int productId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            var resultProductJson = await response.Content.ReadAsStringAsync();
            var resultProduct = System.Text.Json.JsonSerializer.Deserialize<Product>(resultProductJson.ToString());
            Assert.Equal(productId, resultProduct.ProductID);
        }
        [Theory]
        [InlineData(1,10,0)]
        [InlineData(2,20,4)]
        public async Task GetProductsPaginatedReturnsPaginatedProducts(int page,int pageSize,int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/paginated?page={page}&pageSize={pageSize}&categoryId={categoryId}");
            // check if the list returned matches the pageSize and that the categories match
            response.EnsureSuccessStatusCode();
            var productsJson = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(productsJson.ToString());
            Assert.True(pageSize>=products.Count);
            if (categoryId != 0)
            {
                foreach (var product in products)
                {
                    Assert.Equal(categoryId, product.CategoryID);
                }
            }
        }

        [Fact]
        public async Task UpdatesProductWith200ResponseAndReturnsIt()
        {
            var client = _applicationFactory.CreateClient();
            var resposne = await client.GetAsync($"/api/products/7");
            var productToUpdateinJSON = await resposne.Content.ReadAsStringAsync();
            var productToUpdate = JsonSerializer.Deserialize<Product>(productToUpdateinJSON,JsonSerializerOptions.Default);
            productToUpdate.ProductName = "updated product name";
            var jsonToSend = JsonSerializer.Serialize(productToUpdate);
            var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
            var responseForUpdate = await client.PutAsync("/api/products/7", content);
            responseForUpdate.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,responseForUpdate.StatusCode);
            var updatedGetResponse = await client.GetAsync($"/api/products/7");
            var contentOfUpdated = await updatedGetResponse.Content.ReadAsStringAsync();
            var productToCheck = JsonSerializer.Deserialize<Product>(contentOfUpdated);
            Assert.Equal("updated product name", productToCheck.ProductName);
        }

        [Fact]
        public async Task PostProductWith200ResponseAndReturnsIt()
        {
            var client = _applicationFactory.CreateClient();
            var product = new Product
            {
                ProductName = "Our new product",
                UnitPrice = Decimal.Parse("15.0"),
                CategoryID = 3
            }; 
            var json = System.Text.Json.JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await client.PostAsync("/api/products", content);
            resposne.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,resposne.StatusCode);

        }

        [Theory]
        [InlineData(1104)]
        [InlineData(1107)]
        public async Task DeleteProductWith200Response(int productId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
    
}
