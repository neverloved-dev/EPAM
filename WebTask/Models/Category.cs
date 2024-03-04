using System.ComponentModel.DataAnnotations;

namespace WebTask.Models;

public class Category
{
    [Key]
    public int CategoryID { get;  set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}