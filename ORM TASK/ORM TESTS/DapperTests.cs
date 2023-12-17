using ORM_Classes;
using ORM_Classes.Models;
using ORM_Classes.Repositories;
using ORM_Classes.Services;
using System.Data.Common;

namespace ORM_TESTS
{
    public class DapperTests
    {
        private ProductRepository productRepository = new ProductRepository();
        private OrderRepository orderRepository = new OrderRepository();
        private readonly string connectionString = "Data Source=X0NR;Initial Catalog=ORM TASK;Integrated Security=True";

        [Fact]
        public void ProductSingleUpdate()
        {
            //Arrange
            Product productToUpdate = productRepository.GetSingle(1);
            productToUpdate.Name = "Updated Name";
            //Act
            productRepository.Update(productToUpdate);
            //Assert
            Product result = productRepository.GetSingle(1);
            Assert.Equal(result, productToUpdate);
        }

        [Fact]
        public void ProductSingleDelete()
        {
            //Arrange
            Product product = productRepository.GetSingle(1);
            //Act
            productRepository.Delete(product.Id);
            //Assert
            Assert.Null(productRepository.GetSingle(1));
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
            Assert.Equal(resultProduct,product);
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
            Order order = orderRepository.GetSingle(1);
            //Act
            order.Status = Status.LOADING;
            orderRepository.Update(order);
            //Assert
            Order result = orderRepository.GetSingle(1);
           Assert.Equal(order.Status,result.Status);

        }
        
        [Fact]
        public void OrderFilterDelete()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}