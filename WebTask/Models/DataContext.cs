using Microsoft.EntityFrameworkCore;

namespace WebTask.Models;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Product>Products { get; set; }
    public DbSet<Category>Categories { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
}