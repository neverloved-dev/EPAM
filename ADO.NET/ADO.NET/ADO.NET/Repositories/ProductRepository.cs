using ADO.NET.Models;

namespace ADO.NET;

public class ProductRepository:IGenericRepository<Product>
{
    public void CreateT(Product entity)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Product Update(Product entity, int id)
    {
        throw new NotImplementedException();
    }
}