using ProductCatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatelogService.Domain.Repositories
{
    public interface IProductsRepository
    {
        Task SaveAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int productId);

        Task<List<Product>> GetProductsByCategoryAsync(string categoryName);
    }
}
