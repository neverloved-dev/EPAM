using ADO.NET.Models;
using Microsoft.Data.SqlClient;

namespace ADO.NET;

public class OrderRepository
{
    private readonly string connectionString;

    public OrderRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void InsertOrder(Order order)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Orders (Status, CreatedDate, UpdatedDate, ProductId) " +
                           "VALUES (@Status, @CreatedDate, @UpdatedDate, @ProductId)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Status", order.Status.ToString());
                command.Parameters.AddWithValue("@CreatedDate", order.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", order.UpdatedDate);
                command.Parameters.AddWithValue("@ProductId", order.ProductId);

                command.ExecuteNonQuery();
            }
        }
    }

    public Order GetOrderById(int orderId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT ID, Status, CreatedDate, UpdatedDate, ProductId " +
                           "FROM Orders WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", orderId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order(
                            (int)reader["ID"],
                            Enum.Parse<Status>(reader["Status"].ToString()),
                            (DateTime)reader["CreatedDate"],
                            (DateTime)reader["UpdatedDate"],
                            (int)reader["ProductId"]
                        );
                    }
                }
            }
        }

        return null;
    }

    public void UpdateOrder(Order order)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE Orders SET Status = @Status, " +
                           "CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, " +
                           "ProductId = @ProductId WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", order.ID);
                command.Parameters.AddWithValue("@Status", order.Status.ToString());
                command.Parameters.AddWithValue("@CreatedDate", order.CreatedDate);
                command.Parameters.AddWithValue("@UpdatedDate", order.UpdatedDate);
                command.Parameters.AddWithValue("@ProductId", order.ProductId);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteOrder(int orderId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Orders WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", orderId);

                command.ExecuteNonQuery();
            }
        }
    }
}