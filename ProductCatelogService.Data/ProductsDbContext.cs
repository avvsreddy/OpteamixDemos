using Microsoft.EntityFrameworkCore;
using ProductCatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatelogService.Data
{
    public class ProductsDbContext : DbContext
    {
        // for configuration from appsettings.json
        public ProductsDbContext( DbContextOptions<ProductsDbContext> options ): base( options )
        {
            // this constructor will be used by the DI container to create the DbContext instance
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OpteamixProductsDb2026;Trusted_Connection=true;");
            }
        }

        public DbSet<Product> Products { get; set; }

    }
}
