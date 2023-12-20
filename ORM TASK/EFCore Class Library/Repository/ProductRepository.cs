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
            var oldEntity = _dbContext.Products.Find(entity.Id);
            oldEntity.Id = entity.Id;
            oldEntity.Name = entity.Name;
            oldEntity.Description = entity.Description;
            oldEntity.Weight = entity.Weight;
            oldEntity.Width = entity.Width;
            oldEntity.Height = entity.Height;
            oldEntity.Length = entity.Length;
            _dbContext.Entry(oldEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return oldEntity;

        }

        public void Create(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();

        }
    }
}
