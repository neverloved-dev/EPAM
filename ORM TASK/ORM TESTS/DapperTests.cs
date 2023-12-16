using ORM_Classes;
using ORM_Classes.Models;

namespace ORM_TESTS
{
    public class DapperTests
    {
        [Fact]
        public void TestSingleInsert()
        {

        }
        [Theory]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        public void TestMultipleInsertProductes()
        {

        }
        [Theory]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        public void TestMultipleInsertOrders()
        {

        }
        [Theory]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        [InlineData(new Product())]
        public void TestUpdateProduct()
        {

        }
        [Theory]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        public void TestUpdateOrder()
        {

        }
        [Fact]
        public void GetsMultipleOrders()
        {

        }
        [Fact]
        public void GetAllProductes()
        {

        }
        [Fact]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        [InlineData(new Order())]
        public void BulkDeletesOrders()
        {

        }
    }
}