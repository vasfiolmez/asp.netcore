using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace WebApi.Model
{
    public class ProductsContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 1, ProductName = "Iphone 13", Price = 1000, Status = true });
            modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 2, ProductName = "Iphone 14", Price = 1001, Status = true });
            modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 3, ProductName = "Iphone 15", Price = 1111, Status = true });
            modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 4, ProductName = "Iphone 16", Price = 1222, Status = false });
            modelBuilder.Entity<Product>().HasData(new Product() { ProductId = 5, ProductName = "Iphone 17", Price = 2000, Status = false });

        }
        public DbSet<Product> Products { get; set; }

    }
}