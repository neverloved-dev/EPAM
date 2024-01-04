using Microsoft.AspNetCore.Mvc;

namespace MVCTASK.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult ListAll()
    {
        return View();
    }
}