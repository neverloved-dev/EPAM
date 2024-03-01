using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        }

        [Fact]
        public void UpdatesProductWith200ResponseAndReturnsIt()
        {

        }

        [Fact]
        public void PostProductWith200ResponseAndReturnsIt()
        {

        }

        [Fact]
        public void DeleteProductWith200Response()
        {

        }
    }
    
}
