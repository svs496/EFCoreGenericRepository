using System;
using Microsoft.EntityFrameworkCore;
using ProductAppCore2.Models;

namespace ProductAppCore2.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }

    }
}
