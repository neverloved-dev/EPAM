using WebTask.Models;

namespace WebTask.Services;

public class CategoryService:IGenericService<Category>
{
    private DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }
    public void Add(Category entity)
    {
        _context.Categories.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var categoryToDelete = _context.Categories.Find(id);
        if (categoryToDelete == null)
        {
            throw new NullReferenceException("The object could not be found");
        }
        _context.Categories.Remove(categoryToDelete);
        _context.SaveChanges();
    }

    public void Update(Category entity)
    {
        _context.Categories.Update(entity);
        _context.SaveChanges();
    }

    public List<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Category Get(int id)
    {
        var category =  _context.Categories.Find(id);
        if (category == null)
        {
            throw new NullReferenceException("The object could not be found");
        }

        return category;

    }
}