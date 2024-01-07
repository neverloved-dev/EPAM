using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVCTASK.Models;


namespace MVCTASK.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private DataContext _context;
    public CategoryController(ILogger<CategoryController> logger,DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Categories()
    {
        List<Category> categories = _context.Categories.ToList();
        return View(categories);
    }

    public IActionResult CategoryForm()
    {
        return View();
    }

    public void UpdateCategory(Category category,int categoryId)
    {
        var oldCategory = _context.Categories.Find(categoryId);
        oldCategory.Supplier = category.Supplier;
        oldCategory.Name = category.Name;
        _context.Categories.Update(oldCategory);
        _context.SaveChanges();
    }

    public void AddNewCategory(Category newCategory)
    {
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
    }
}