using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCTASK.Models;

public class Product
{
    [Key]
    public int ProductID { get; private set; }
    [Required(ErrorMessage = "Please enter a product name")]
    public string ProductName { get; set; }
    [Required(ErrorMessage = "Please enter a product price!")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal UnitPrice { get; set; }
    [Required(ErrorMessage = "You must select a category")]
    public int CategoryID { get; set; }
}