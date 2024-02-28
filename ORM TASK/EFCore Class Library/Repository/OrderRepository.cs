using EFCore_Class_Library.Context;
using EFCore_Class_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore_Class_Library.Repository
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private EfCoreDbContext _dbContext;

        public OrderRepository(EfCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            Order orderToDelete = _dbContext.Find<Order>(id);
            _dbContext.Orders.Remove(orderToDelete);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetSingle(int value)
        {
            return _dbContext.Orders.Find(value);
        }

        public Order Update(Order entity)
        {
            var oldEntity = _dbContext.Orders.Find(entity.ID);
            oldEntity.Status = entity.Status;
            oldEntity.CreatedDate = entity.CreatedDate;
            oldEntity.UpdatedDate = entity.UpdatedDate;
            _dbContext.Entry(oldEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return oldEntity;
        }
        public void Create(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<Order> OrderFilterByStatus(Status status)
        {
            return _dbContext.Orders.Where(s=>s.Status == status).ToList();
        }
    }
}
