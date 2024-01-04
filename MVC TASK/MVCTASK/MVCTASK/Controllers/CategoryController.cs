using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVCTASK.Models;


namespace MVCTASK.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public IActionResult Categories()
    {
        return View();
    }
}