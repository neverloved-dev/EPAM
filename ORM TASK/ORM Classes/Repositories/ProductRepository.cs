using ORM_Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ORM_Classes.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly string _connectionString = "Data Source=X0NR;Initial Catalog=ORM TASK;Integrated Security=True";
        public void Delete(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM products WHERE id = @id", new { id = productId });
                connection.Close();
            }
        }

        public List<Product> GetAll()
        {
            List<Product> productsList = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var products = connection.Query("SELECT * FROM products").ToList();
                foreach (var product in products)
                {
                    productsList.Add(product);
                }
                connection.Close();
            }
            return productsList;
        }

        public Product GetSingle(int value)
        {
            Product product;
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Product>("SELECT * FROM products WHERE id = @id", new { id = value });
                product = result.First();
                connection.Close();
            }
            return product;
        }

        public Product Update(Product entity)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("UPDATE products SET Name = @name, Description = @description, Height = @height, Weight = @weight, Width = @width,Length = @length" +
                "WHERE id = @id",
                    new { id = entity.Id, name = entity.Name, description = entity.Description, height = entity.Height, weight = entity.Weight, width = entity.Width, length = entity.Length });
            Product product = connection.Query("SELECT * FROM products WHERE id = @id", new { id = entity.Id }).First();
            connection.Close();
            return product;

        }

        public void Create(Product entity)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO products(Id,Name,Description,Height,Weight,Width,Length) VALUES(@id,@name,@description,@height,@weight,@width,@length)",
                    new {id = entity.Id,name = entity.Name,description = entity.Description,height = entity.Height,weight = entity.Weight,width = entity.Width,length = entity.Length});
                connection.Close();
            }
        }
    }
}
