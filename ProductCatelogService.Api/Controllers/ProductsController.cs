using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatelogService.Data;
using ProductCatelogService.Domain.Entities;
using ProductCatelogService.Domain.Repositories;

namespace ProductCatelogService.Api.Controllers
{


    // http://localhost:5000/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // GET: http://localhost:5000/api/products
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            // fetch data from database and return to client
            IProductsRepository repo = new ProductsRepository();
            return await repo.GetAllProductsAsync();
        }


        // Design the endpoint uri and method for searching product by id
        // GET: http://localhost:5000/api/products/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            IProductsRepository repo = new ProductsRepository();

            var product = await repo.GetProductByIdAsync(id);
            if(product == null)
            {
                // return 404 not found
                return NotFound();

            }
            // return 200 with data
            return Ok(product);
        }

    }
}
