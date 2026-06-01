using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatelogService.Api.Controllers
{


    // http://localhost:5000/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // GET: http://localhost:5000/api/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            // fetch data from database and return to client
        }


    }
}
