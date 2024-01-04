namespace MVCTASK.Models;

public class Product
{
    public int Id { get; private set; }
    
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}