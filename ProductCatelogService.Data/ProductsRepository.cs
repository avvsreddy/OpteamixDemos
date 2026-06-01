using Microsoft.EntityFrameworkCore;
using ProductCatelogService.Domain.Entities;
using ProductCatelogService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatelogService.Data
{
    public class ProductsRepository : IProductsRepository
    {

        private ProductsDbContext _dbContext;

        public ProductsRepository()
        {
            _dbContext = new ProductsDbContext();
        }
        public ProductsRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        public async Task SaveAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
