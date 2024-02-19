using EFCore_Class_Library.Repository;
using EFCore_Class_Library.Models;
using Microsoft.EntityFrameworkCore;
using EFCore_Class_Library.Context;

namespace EFCore_Tests
{
    public class EFCoreTests
    {
        private ProductRepository productRepository = new ProductRepository();
        private OrderRepository orderRepository = new OrderRepository();
        // constructor with an in memory database and then delete everything after the tests are over
        public EFCoreTests()
        {
            var options = new DbContextOptionsBuilder<EfCoreDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
        }

        public void Dispose()
        {
            using (var context = new EfCoreDbContext())
            {
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void ProductSingleUpdate()
        {
            //Arrange
            Product product = new Product(5, "Fan", "Just a fan", 2.0, 1.0, 3.0, 4.0);
            productRepository.Create(product);
            var productToUpdate = productRepository.GetSingle(5);
            //Act
            productToUpdate.Name = "Updated name";
            productRepository.Update(productToUpdate);
            //Assert
            Product result = productRepository.GetSingle(5);
            Assert.Equal(result, productToUpdate);
        }

        [Fact]
        public void ProductSingleDelete()
        {
            //Arrange
            Product product = new Product(4, "Fan", "Just a fan", 2.0, 1.0, 3.0, 4.0);
            productRepository.Create(product);
            Product retrievedProduct = productRepository.GetSingle(4);
            //Act
            productRepository.Delete(retrievedProduct.Id);
            //Assert
            Assert.Null(productRepository.GetSingle(4));
        }
        [Fact]
        public void ProductSingleCreate()
        {
            //Arrange
            Product product = new Product(3, "Fan", "Just a fan", 2.0, 1.0, 3.0, 4.0);
            //Act
            productRepository.Create(product);
            //Assert
            Product resultProduct = productRepository.GetSingle(3);
            Assert.Equal(resultProduct, product);
        }

        [Fact]
        public void ProductGetAll()
        {
            //Arrange
            //Act
            List<Product> productList = productRepository.GetAll();
            //Assert
            Assert.NotNull(productList);
        }

        [Fact]
        public void OrderCreate()
        {
            //Arrange
            Order order = new Order(1, Status.NOT_STARTED, DateTime.Now, DateTime.Now, 1);
            //Act
            orderRepository.Create(order);
            //Assert
            Order result = orderRepository.GetSingle(1);
            Assert.NotNull(result);
        }
        [Fact]
        public void OrderDelete()
        {
            //Arrange
            Order order = orderRepository.GetSingle(1);
            //Act
            orderRepository.Delete(order.ID);
            //Assert
            Order result = orderRepository.GetSingle(1);
            Assert.Null(result);
        }
        [Fact]
        public void OrderUpdate()
        {
            //Arrange
            Order order = new Order(3, Status.NOT_STARTED, DateTime.Now, DateTime.Now, 1);
            orderRepository.Create(order);
            //Act
            Order orderToUpdate = orderRepository.GetSingle(3);
            orderToUpdate.Status = Status.LOADING;
            orderRepository.Update(orderToUpdate);
            //Assert
            Order result = orderRepository.GetSingle(3);
            Assert.Equal(Status.LOADING, result.Status);

        }

        [Fact]
        public void OrderFilterDelete()
        {
            // Arrange
            Order order = new Order(2, Status.NOT_STARTED, DateTime.Now, DateTime.Now, 1);
            orderRepository.Create(order);
            //Act
            List<Order> orders = orderRepository.OrderFilterByStatus(Status.NOT_STARTED);
            //Assert
            Assert.NotEmpty(orders);
        }
    }
}