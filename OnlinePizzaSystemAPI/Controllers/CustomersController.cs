using Microsoft.AspNetCore.Mvc;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No customers found !!");
            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customer = await _service.GetById(id);

            if (customer  == null)
                return BadRequest($"No payment with id: {id} founded !!");

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                DeliveryAddress = customer.DeliveryAddress,
            };

            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid customer, you must fill it again !!");

            var customer = new Customer
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                DeliveryAddress = dto.DeliveryAddress
            };

            await _service.Create(customer);

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CustomerDto dto)
        {
            var customer = await _service.GetById(id);
            if (customer == null)
                return BadRequest($"No customer found with id: {id}");

            customer.Email= dto.Email;
            customer.Name = dto.Name;
            customer.DeliveryAddress = dto.DeliveryAddress;
            customer.Id = dto.Id;

            await _service.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var customer = await _service.GetById(id);
            
            if (customer == null)
                return NotFound($"No customer was found with id '{id}' to be deleted !!");

            await _service.Delete(customer);

            return Ok(customer);
        }
    }
}
