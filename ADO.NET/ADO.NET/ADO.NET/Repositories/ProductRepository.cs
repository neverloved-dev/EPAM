using ADO.NET.Models;
using Microsoft.Data.SqlClient;

namespace ADO.NET;

public class ProductRepository
{
    private readonly string connectionString;

    public ProductRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void InsertProduct(Product product)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Products (Name, Description, Weight, Height, Width, Length) " +
                           "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@Height", product.Height);
                command.Parameters.AddWithValue("@Width", product.Width);
                command.Parameters.AddWithValue("@Length", product.Length);

                command.ExecuteNonQuery();
            }
        }
    }

    public Product GetProductById(int productId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Id, Name, Description, Weight, Height, Width, Length " +
                           "FROM Products WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", productId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product(
                            (int)reader["Id"],
                            (string)reader["Name"],
                            (string)reader["Description"],
                            (double)reader["Weight"],
                            (double)reader["Height"],
                            (double)reader["Width"],
                            (double)reader["Length"]
                        );
                    }
                }
            }
        }

        return null;
    }

    public void UpdateProduct(Product product)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE Products SET Name = @Name, Description = @Description, " +
                           "Weight = @Weight, Height = @Height, Width = @Width, Length = @Length " +
                           "WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Weight", product.Weight);
                command.Parameters.AddWithValue("@Height", product.Height);
                command.Parameters.AddWithValue("@Width", product.Width);
                command.Parameters.AddWithValue("@Length", product.Length);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteProduct(int productId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Products WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", productId);

                command.ExecuteNonQuery();
            }
        }
    }

}
