using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCTASK.Models;

namespace MVCTASK.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly DataContext _context;
    public ProductController(IConfiguration configuration, DataContext context)
    {
        _configuration = configuration;
        _context = context;
    }
    
    // GET
    public IActionResult ListAll()
    {
        int productCount = _configuration.GetValue<int>("MaxProductCount");
        List<Product> products;
        if (productCount > 0)
        {
          products =  _context.Products.Take(productCount).ToList();   
        }
        else
        {
            products = _context.Products.ToList();
        }
        return View(products);
    }

    public IActionResult New()
    {
        ViewBag.Categories = GetCategoriesSelectList();
        return View(new Product());
    }

    private SelectList GetCategoriesSelectList(int selectedCategory = 0)
    {
        List<Category> categories = _context.Categories.ToList();
        return new SelectList(categories, "Id", "Name", selectedCategory);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult New(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            return RedirectToAction("ListAll");
        }

        ViewBag.Categories = GetCategoriesSelectList();
        return View(product);
    }
    
    
    // GET: Product/Edit/{id}
    public ActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }

        ViewBag.Categories = GetCategoriesSelectList(product.CategoryID);
        return View(product);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Update(product);
            return RedirectToAction("ListAll");
        }

        ViewBag.Categories = GetCategoriesSelectList(product.CategoryID);
        return View(product);
    }

}