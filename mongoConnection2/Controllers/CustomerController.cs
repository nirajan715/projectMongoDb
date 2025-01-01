using Microsoft.AspNetCore.Mvc;
using mongoConnection2.Models;
using mongoConnection2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mongoConnection2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/CustomerController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // GET api/CustomerController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/CustomerController
        [HttpPost]
        public async Task <IActionResult> Post(Customer customer)
        {
            await _customerService.CreateAsync(customer);
            return Ok("created succesfully");
        }

        // PUT api/CustomerController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Customer newCustomer)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(id,newCustomer);
            return Ok("updated succesfully");
        }

        // DELETE api/CustomerController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
                return NotFound();
            
            await _customerService.DeleteAsync(id);
            return Ok("Deleted succesfully");
        }
    }
}
