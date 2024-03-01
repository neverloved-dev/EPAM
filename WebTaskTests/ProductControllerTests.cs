using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTaskTests
{
    public class ProductControllerTests
    {
        public ProductControllerTests() 
        {

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
