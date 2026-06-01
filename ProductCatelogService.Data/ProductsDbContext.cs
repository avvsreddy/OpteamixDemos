using Microsoft.EntityFrameworkCore;
using ProductCatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatelogService.Data
{
    public class ProductsDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OpteamixProductsDb2026;Trusted_Connection=true;");
        }

        public DbSet<Product> Products { get; set; }

    }
}
