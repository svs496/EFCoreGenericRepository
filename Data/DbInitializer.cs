using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ProductAppCore2.Models;

namespace ProductAppCore2.Data
{
    public class DbInitializer
    {
        private readonly ProductDBContext context;

        public DbInitializer(ProductDBContext context)
        {
            this.context = context;
        }


        public async Task Seed()
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var suppliers = new Supplier[]
            {
                new Supplier{Name = "ABC DELHI", Address="MG ROAD DELHI", City="NEW DELHI", ContactNo="9818000201", Email="sup@sup.com"},
                new Supplier{Name = "RS COMPUTERS", Address="LINK ROAD MUMBAI", City="MUMBAI", ContactNo="9855550201", Email="mum@sup.com"},
                new Supplier{Name = "CH SOFTWARE", Address="MARINA BEACH", City="CHENNAI", ContactNo="8818000201", Email="chn@sup.com"},
                new Supplier{Name = "IT SERVERS", Address="100 FEET RD", City="BANGALORE", ContactNo="89818000201", Email="bglr@sup.com"}
            };

            foreach (Supplier item in suppliers)
            {
                context.Suppliers.Add(item);
            }
            await context.SaveChangesAsync();

            var products = new Product[]
            {
                new Product{Name="Laptop", SupplierId = suppliers.FirstOrDefault(p => p.Name == "ABC DELHI").Id},
                new Product{Name="IPAD", SupplierId = suppliers.FirstOrDefault(p => p.Name == "RS COMPUTERS").Id},
                new Product{Name="Printer", SupplierId = suppliers.FirstOrDefault(p => p.Name == "CH SOFTWARE").Id},
                new Product{Name="Monitors", SupplierId = suppliers.FirstOrDefault(p => p.Name == "ABC DELHI").Id},

            };
            foreach (Product item in products)
            {
                context.Products.Add(item);
            }
            await context.SaveChangesAsync();

        }

    }
}
