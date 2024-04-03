using System.ComponentModel.DataAnnotations;

namespace WebTask.Models;

public class Product
{
    public int ProductID { get; set; }
    [Required(ErrorMessage = "Please enter a product name")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Please enter a product price!")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal UnitPrice { get; set; }
    [Required(ErrorMessage = "You must select a category")]
    public int CategoryID { get; set; }

    public Product()
    {

    }
    public Product(string name, decimal price, int categoryId)
    {
        ProductName = name;
        UnitPrice = price;
        CategoryID = categoryId;
    }
}