using EFCore_Class_Library.Repository;
using EFCore_Class_Library.Models;
using Microsoft.EntityFrameworkCore;
using EFCore_Class_Library.Context;

namespace EFCore_Tests
{
    public class EFCoreTests:IDisposable
    {
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        // constructor with an in memory database and then delete everything after the tests are over
        public EFCoreTests()
        {
            var options = new DbContextOptionsBuilder<EfCoreDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            EfCoreDbContext context = new EfCoreDbContext();
            productRepository = new ProductRepository(context);
            orderRepository = new OrderRepository(context);
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
            Dispose();
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
            Dispose();
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
            Assert.Equal(resultProduct.Id, product.Id);
            Dispose();
        }

        [Fact]
        public void ProductGetAll()
        {
            //Arrange
            productRepository.Create(new Product(1, "Product 1", "Description 1", 5.0, 10.0, 5.0, 15.0));
            productRepository.Create(new Product(2, "Product 2", "Description 2", 8.0, 12.0, 6.0, 18.0));
            productRepository.Create(new Product(7, "Product 3", "Description 3", 6.0, 8.0, 4.0, 12.0));
            //Act
            List<Product> productList = productRepository.GetAll();
            //Assert
            Assert.Equal(5.0, productList[0].Weight);
            Assert.Equal(15.0 , productList[0].Length);
            Assert.Equal(8.0, productList[1].Weight);
            Assert.Equal(18.0, productList[1].Length);
            Assert.Equal(6.0, productList[2].Weight);
            Assert.Equal(12.0, productList[2].Length);
            Dispose();
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
            Dispose();
        }
        [Fact]
        public void OrderDelete()
        {
            //Arrange
            Order order = new Order(1, Status.NOT_STARTED, DateTime.Now, DateTime.Now, 1);
            orderRepository.Create(order);
            Order orderToDelete = orderRepository.GetSingle(1);
            //Act
            orderRepository.Delete(orderToDelete.ID);
            //Assert
            Order result = orderRepository.GetSingle(1);
            Assert.Null(result);
            Dispose();
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
            Dispose();
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
            Dispose();
        }
    }
}