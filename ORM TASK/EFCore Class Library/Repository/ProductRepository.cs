using EFCore_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
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
