using DataLayer.Configuration;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DBContext
{
    public class CRUD_DBContext : DbContext
    {
        public CRUD_DBContext(DbContextOptions<CRUD_DBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new NationCofiguration());

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Nation> Nations { get; set; }

    }
}
