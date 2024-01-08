using Microsoft.AspNetCore.Mvc;

namespace WebTask.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}