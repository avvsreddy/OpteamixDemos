using Microsoft.AspNet.OData;
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

        private readonly IProductsRepository repo;

        public ProductsController(IProductsRepository repo) // DIP - Dependency Inversion Principle
        {
            this.repo = repo;
        }



        // Design the endpoint uri and method for getting all products with Odata support
        // GET: http://localhost:5000/api/products/odata
        [HttpGet]
        [Route("odata")]
        [EnableQuery]
        public IQueryable<Product> GetProductsOData()
        {
            //IProductsRepository repo = new ProductsRepository();
            var products = repo.GetAllProductsAsync().Result.AsQueryable();
            return products;
        }


        // GET: http://localhost:5000/api/products
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            // fetch data from database and return to client
            //IProductsRepository repo = new ProductsRepository();
            return await repo.GetAllProductsAsync();
        }


        // Design the endpoint uri and method for searching product by id
        // GET: http://localhost:5000/api/products/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //IProductsRepository repo = new ProductsRepository();

            var product = await repo.GetProductByIdAsync(id);
            if (product == null)
            {
                // return 404 not found
                return NotFound();

            }
            // return 200 with data
            return Ok(product);
        }


        // get all products by category
        // GET: http://localhost:5000/api/products/category/electronics
        [HttpGet]
        [Route("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            //IProductsRepository repo = new ProductsRepository();
            var products = await repo.GetProductsByCategoryAsync(category);
            if (products == null || products.Count == 0)
            {
                // return 404 not found
                return NotFound();
            }
            return Ok(products);

        }

        // get all products by country
        // GET: http://localhost:5000/api/products/country/{usa}
        // get all products in stock
        // GET: http://localhost:5000/api/products/instock
        // get all products in price range Ex: between 100 and 500
        // GET: http://localhost:5000/api/products/pricerange/min/{100}/max/{500}
        // get cheapest product
        // GET: http://localhost:5000/api/products/cheapest
        // get most expensive product
        // GET: http://localhost:5000/api/products/mostexpensive



        // End point for Add new product
        // POST: http://localhost:5000/api/products

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {

            // validation
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //IProductsRepository repo = new ProductsRepository();
            await repo.SaveAsync(product);
            // return 201 + location header + data
            return Created($"api/products/{product.ProductId}", product);
        }

        // Design the endpoint uri and method for updating product by id
        // PUT: http://localhost:5000/api/products/1
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            //IProductsRepository repo = new ProductsRepository();
            await repo.UpdateAsync(product);
            return NoContent();
        }

        // Design the endpoint uri and method for deleting product by id
        // DELETE: http://localhost:5000/api/products/1
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //IProductsRepository repo = new ProductsRepository();
            var productToDelete = await repo.GetProductByIdAsync(id);
            if (productToDelete == null)
            {
                return NotFound("Product not found");
            }
            // code to delete the product
            await repo.DeleteAsync(productToDelete);
            return Ok();

        }
    }
}
