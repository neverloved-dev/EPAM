using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        [InlineData(1)]
        [InlineData(3)]
        public async Task GetSingleProductsReturnsSingleProduct(int productId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData(1,10,0)]
        [InlineData(2,20,4)]
        public async Task GetProductsPaginatedReturnsPaginatedProducts(int page,int pageSize,int categoryId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync($"/api/products/page={page}?pageSize={pageSize}?categoryId={categoryId}");
            // check if the list returned matches the pageSize and that the categories match
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task UpdatesProductWith200ResponseAndReturnsIt()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task PostProductWith200ResponseAndReturnsIt()
        {
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task DeleteProductWith200Response(int productId)
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
    
}
