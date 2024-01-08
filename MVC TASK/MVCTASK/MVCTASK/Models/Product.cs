using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCTASK.Models;

public class Product
{
    public int Id { get; private set; }
    [Required(ErrorMessage = "Please enter a product name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter a product price!")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "You must select a category")]
    public int CategoryId { get; set; }
}