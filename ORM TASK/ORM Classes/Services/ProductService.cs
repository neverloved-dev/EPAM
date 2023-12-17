using ORM_Classes.Models;
using ORM_Classes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_Classes.Services
{
    public class ProductService : IGenericService<Product>
    {
        private readonly ProductRepository productRepository;
        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetSingle(int value)
        {
            return productRepository.GetSingle(value);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
        public Product Create(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
