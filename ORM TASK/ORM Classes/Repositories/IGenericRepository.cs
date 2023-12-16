using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Classes.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public T GetAll();
        public T GetSingle(int value);
        public T Update(T entity);
        public T Delete(int id);
    }
}
