﻿using Azure;
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
        [InlineData(1)]
        [InlineData(3)]
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
            var response = await client.GetAsync($"/api/products/page={page}?pageSize={pageSize}?categoryId={categoryId}");
            // check if the list returned matches the pageSize and that the categories match
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task UpdatesProductWith200ResponseAndReturnsIt()
        {
            var client = _applicationFactory.CreateClient();
            var resposne = await client.GetAsync($"/api/products/1");
            var productToUpdateinJSON = await resposne.Content.ReadAsStringAsync();
            var productToUpdate = JsonSerializer.Deserialize<Product>(productToUpdateinJSON,JsonSerializerOptions.Default);
            productToUpdate.ProductName = "updated product name";
            var jsonToSend = JsonSerializer.Serialize(productToUpdate);
            var content = new StringContent(jsonToSend, Encoding.UTF8, "application/json");
            var responseForUpdate = await client.PutAsync("/api/products/1", content);
            responseForUpdate.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,responseForUpdate.StatusCode);
            var updatedProduct = JsonSerializer.Deserialize<Product>(await responseForUpdate.Content.ReadAsStringAsync(), JsonSerializerOptions.Default);
            Assert.Equal("updated product name", updatedProduct.ProductName);
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
