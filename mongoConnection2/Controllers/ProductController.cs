using Microsoft.AspNetCore.Mvc;
using mongoConnection2.Models;
using mongoConnection2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mongoConnection2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/ProductController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET api/ProductController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/ProductController
        [HttpPost]
        public async Task <IActionResult> Post(Product product)
        {
            
            await _productService.CreateAsync(product);
            return Ok("created succesfully");
        }

        // PUT api/ProductController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product newProduct)
        {
            
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.UpdateAsync(id,newProduct);
            return Ok("updated succesfully");
        }

        // DELETE api/ProductController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            
            await _productService.DeleteAsync(id);
            return Ok("Deleted succesfully");
        }
    }
}
