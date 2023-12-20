using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetSingle(int value);
        public T Update(T entity);
        public void Delete(int id);
        public void Create(T entity);
    }
}
