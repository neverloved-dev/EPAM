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
        var productCount = _configuration.GetValue<int>("MaxProductCount");
        List<Product> products;
        products = productCount > 0 ? _context.Products.Take(productCount).ToList() : _context.Products.ToList();
        return View(products);
    }

    public IActionResult New()
    {
        ViewBag.Categories = ReturnCategoryViewBag();
        return View(new Product());
    }

    private SelectList ReturnCategoryViewBag()
    {
        List<Category> categories = _context.Categories.ToList();
        List<int> categoryIds = new List<int>();
        for (int i = 0; i < categories.Count; i++)
        {
            categoryIds.Add(categories[i].CategoryID);
        }
        return new SelectList(categoryIds);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult New(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            return RedirectToAction("ListAll");
        }

        ViewBag.Categories = ReturnCategoryViewBag();
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

        ViewBag.Categories = ReturnCategoryViewBag();
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

        ViewBag.Categories = ReturnCategoryViewBag();
        return View(product);
    }

}