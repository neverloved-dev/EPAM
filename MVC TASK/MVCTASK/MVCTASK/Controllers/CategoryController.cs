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
        return View();
    }
}