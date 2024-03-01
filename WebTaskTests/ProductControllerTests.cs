using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTaskTests
{
    public class ProductControllerTests
    {
        private static HttpClient _httpClient;
        public ProductControllerTests() 
        {
            _httpClient = new HttpClient("localhost:");
        }

        [Fact]
        public void GetAllProductsReturns200WithListOfProducts()
        {

        }
        [Fact]
        public void GetSingleProductsReturnsSingleProduct()
        {

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
