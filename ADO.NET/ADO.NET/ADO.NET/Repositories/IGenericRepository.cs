namespace ADO.NET;

public interface IGenericRepository<T>
{
    
    public void CreateT(T entity);
    public List<T> GetAll();
    public T Get(int id);
    public void Delete(int id);
    public T Update(T entity, int id);
}