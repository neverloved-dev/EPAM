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
       var productToUpdate = _context.Products.Find(id);
        productToUpdate.Name = entity.Name;
        productToUpdate.Price = entity.Price;
        productToUpdate.CategoryId = entity.CategoryId;
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