using Fleet_Management.DTO;
using Fleet_Management.Models;
using Fleet_Management.Repository;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // Get All Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _service.GetAllCustomers();
            return Ok(customers);
        }

        // Get Customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(long id)
        {
            var customer = await _service.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");

            return Ok(customer);
        }

        // Get Customer by Email
        [HttpGet("email/{email}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByEmail(string email)
        {
            var customer = await _service.GetCustomerByEmail(email);
            if (customer == null)
                return NotFound($"Customer with email {email} not found.");

            return Ok(customer);
        }

        // Add New Customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO newCustomer)
        {
            if (newCustomer == null)
                return BadRequest("Customer data is required.");

            await _service.AddCustomer(newCustomer);
            return CreatedAtAction(nameof(GetCustomerByEmail), new { email = newCustomer.Email }, newCustomer);
        }

        // Update Customer
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, [FromBody] CustomerDTO updatedCustomer)
        {
            if (updatedCustomer == null)
                return BadRequest("Updated customer data is required.");

            await _service.UpdateCustomer(id, updatedCustomer);
            return NoContent();
        }

        // Delete Customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            await _service.DeleteCustomer(id);
            return NoContent();
        }
    }
}
