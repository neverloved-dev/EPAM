using System;
using System.Collections.Generic;
using System.Text;
using EFCore_Class_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Class_Library.Context
{
    public class EfCoreDbContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
        }
    }
}
