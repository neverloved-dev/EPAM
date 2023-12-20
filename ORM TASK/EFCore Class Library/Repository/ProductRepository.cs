using EFCore_Class_Library.Context;
using EFCore_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private EfCoreDbContext _dbContext = new EfCoreDbContext();
        public void Delete(int id)
        {
            Product productToDelete = _dbContext.Find<Product>(id);
            _dbContext.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetSingle(int value)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
