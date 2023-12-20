using EFCore_Class_Library.Context;
using EFCore_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private EfCoreDbContext _dbContext = new EfCoreDbContext();
        public void Delete(int id)
        {
            Product productToDelete = _dbContext.Find<Product>(id);
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetSingle(int value)
        {
            return _dbContext.Products.Find(value);
        }

        public Product Update(Product entity)
        {
            return _dbContext.Products.Save(entity);
        }

        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
