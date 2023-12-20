using EFCore_Class_Library.Context;
using EFCore_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private EfCoreDbContext _dbContext = new EfCoreDbContext();
        public void Delete(int id)
        {
            Order orderToDelete = _dbContext.Find<Order>(id);
            _dbContext.Remove<Order>(orderToDelete);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetSingle(int value)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
        public void Create(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrderFilterByStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
