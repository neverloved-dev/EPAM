using Dapper;
using Microsoft.Data.SqlClient;
using ORM_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Classes.Repositories
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly string _connectionString = "Data Source=X0NR;Initial Catalog=ORM TASK;Integrated Security=True;Encrypt=False";
        public void Delete(int orderId)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("DELETE FROM orders WHERE id = @id", new { id = orderId });
            connection.Close();
        }

        public List<Order> GetAll()
        {

            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var orders = connection.Query<Order>("SELECT * FROM orders").AsList();
            connection.Close();
            return orders;
        }

        public Order GetSingle(int value)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var order = connection.QueryFirst<Order>("SELECT * FROM orders WHERE ID = @id", new { id = value });
            connection.Close();
            return order;
        }

        public Order Update(Order entity)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("UPDATE orders SET Status = @Status, CreatedDate = @dateCreated, UpdatedDate= @updatedDate, ProductId = @productId" +
                "WHERE id = @id",
                    new { id = entity.ID, status = entity.Status, dateCreated = entity.CreatedDate, updatedDate = entity.UpdatedDate,productId = entity.ProductId });
            Order order = connection.Query("SELECT * FROM orders WHERE id = @id", new { id = entity.ID }).First();
            connection.Close();
            return order;
        }
        public List<Order> GetOrdersByStatus(Status status) 
        {
            List<Order> orders = new List<Order>();
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var results = connection.Query("SELECT * FROM orders WHERE Status = @status", new { status = status }).ToList();
            foreach (var order in results)
            {
                orders.Add(order);  
            }
            connection.Close();
            return orders;
        }

        public void Create(Order entity)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("INSERT INTO orders(ID,Status,CreatedDate,UpdatedDate,ProductId) VALUES(@id,@status,@createdDate,@updatedDate,@productId)",
                new { id = entity.ID, status = entity.Status, createdDate = entity.CreatedDate, updatedDate = entity.UpdatedDate, productId = entity.ProductId });
            connection.Close();
        }

        public List<Order> OrderFilterByStatus(Status status)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = connection.Query<Order>("SELECT  * FROM orders WHERE Status = @status", new { status = status }).ToList();
            connection.Close();
            return result;
        }
    }
}
