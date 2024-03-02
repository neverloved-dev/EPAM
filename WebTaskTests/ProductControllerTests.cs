using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebTask.Models;
using Newtonsoft.Json;

namespace WebTaskTests
{
    public class ProductControllerTests
    {
        private static HttpClient _httpClient;
        public ProductControllerTests() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:7910");
        }

        [Fact]
        public async Task GetAllProductsReturns200WithListOfProducts()
        {
           var response = await _httpClient.GetAsync("/api/products");
           response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async void GetSingleProductsReturnsSingleProduct(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData(1,10,0)]
        public void GetProductsPaginatedReturnsPaginatedProducts(int page,int pageSize,int categoryId)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task UpdatesProductWith200ResponseAndReturnsIt()
        {
            //Arrange
            var product = new Product("Product1", Decimal.Parse("12.0"), 5);
            var packageToSend = new StringContent(JsonConvert.SerializeObject(product),Encoding.UTF8,"application/json");
            //Act
            var response =await  _httpClient.PutAsync("/api/products",packageToSend);
            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public void PostProductWith200ResponseAndReturnsIt()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void DeleteProductWith200Response()
        {
            throw new NotImplementedException();
        }
    }
    
}
