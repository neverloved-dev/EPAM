using WebTask.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebTask.Services;

public class ProductService:IGenericService<Product>
{
    private DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }
    public void Add(Product entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var productToDelete = _context.Products.Find(id);
        if (productToDelete == null)
        {
            throw new NullReferenceException("The object could not be found!");
        }

        _context.Products.Remove(productToDelete);
        _context.SaveChanges();
    }

    public void Update(Product entity,int id)
    {
       var productToUpdate = _context.Products.Find(id);
        productToUpdate.ProductName = entity.ProductName;
        productToUpdate.UnitPrice = entity.UnitPrice;
        productToUpdate.CategoryID = entity.CategoryID;
        _context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product Get(int id)
    {
        return _context.Products.Find(id);
    }

    public List<Product> GetProductsPaginated(int page, int pageSize, int categoryId)
    {
        IQueryable<Product> query = _context.Products;

        if (categoryId != 0)
        {
            query = query.Where(p => p.CategoryID == categoryId);
        }

        int skipAmount = page * pageSize;

        return query.Skip(skipAmount)
                    .Take(pageSize)
                    .ToList();
    }
}
