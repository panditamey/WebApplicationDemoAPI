using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("/")]
        [Route("")]
        [Route("/index")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        { 
            var products = await _productRepository.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet("{id}",Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
             Product? productFound =  await _productRepository.GetProductById(id);
            if (productFound == null)
            {
                return NotFound();
            }
            return Ok(productFound);
        }

        //[HttpGet("name", Name = "GetProductByName")]
        [HttpGet(@"{name:regex(^[[a-zA-Z]]+$)}", Name = "GetProductByName")]
        public async Task<ActionResult<List<Product>>> GetProductByName(string name)
        {
            var productsFound = await _productRepository.GetProductsByName(name);
            if (productsFound == null)
            {
                return NotFound();
            }
            return Ok(productsFound);
        }


        [HttpGet("byrating", Name = "GetProductsByRating")]
        public async Task<ActionResult<List<Product>>> GetProductsByRating(double rating)
        {
            var productsFound = await _productRepository.GetProductsByRating(rating);
            if (productsFound == null || productsFound.Count==0)
            {
                return NotFound();
            }
            return Ok(productsFound);
        }


        [HttpPut("{id}",Name = "UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, double price)
        {
            Product? productFound = null;
            productFound = await _productRepository.UpdateProductPrice(id, price);
            if (productFound == null)
            {
                return NotFound();
            }
            return Ok(productFound);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<bool>> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    bool value = await _productRepository.CreateProduct(product);
                    return Ok(value);
                }
                return BadRequest();
            }
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<ActionResult<bool>> DeleteProduct(int id) 
        { 
            bool value = await _productRepository.DeleteProduct(id);
            return value? Ok(value): BadRequest("Product Not Found");
        }

        [HttpGet("{min},{max}", Name = "GetProductsByPriceRange")]
        public async Task<ActionResult<List<Product>>> GetProductsByPriceRange([FromQuery]double min, double max)
        {
            var productsFound = await _productRepository.GetProductsByPriceRange(min,max);
            if (productsFound == null || productsFound.Count == 0)
            {
                return NotFound();
            }
            return Ok(productsFound);
        }

        [HttpGet("category", Name = "GetProductsByCategory")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(string category)
        {
            var productsFound = await _productRepository.GetProductsByCategory(category);
            if (productsFound == null)
            {
                return NotFound();
            }
            return Ok(productsFound);
        }

        [HttpGet(@"{code:regex(^[[A-Z]]{{3}}-[[A-Z]]{{3}}$)}",Name = "GetProductByProductCode")]
        public async Task<ActionResult<Product>> GetProductByProductCode(string code)
        {
            var productFound = await _productRepository.GetProductByProductCode(code);
            if (productFound == null)
            {
                return NotFound();
            }
            return Ok(productFound);
        }
    }
}
