using ADO.NET.Models;

namespace ADO.NET;

public class OrderRepository:IGenericRepository<Order>
{
    public void CreateT(Order entity)
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAll()
    {
        throw new NotImplementedException();
    }

    public Order Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Order Update(Order entity, int id)
    {
        throw new NotImplementedException();
    }
}