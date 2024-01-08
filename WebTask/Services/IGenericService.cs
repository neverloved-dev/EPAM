namespace WebTask.Services;

public interface IGenericService<T>
{
    public void Add(T entity);
    public void Delete(int id);
    public void Update(T entity,int id);
    public List<T> GetAll();
    public T Get(int id);
}