using WebTask.Models;

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
        _context.Products.Update(entity);
        _context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product Get(int id)
    {
        throw new NotImplementedException();
    }
}