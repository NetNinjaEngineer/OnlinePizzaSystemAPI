using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;
        private readonly AppDbContext _context;
        public PaymentsController(IPaymentService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No payments found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var payment = await _service.GetById(id);

            if (payment == null)
                return BadRequest($"No payment with id: {id} founded !!");

            var paymentDto = new PaymentDetailsDto
            {
                Id = payment.Id,
                CustomerId = payment.CustomerId,
                CustomerName = payment.Customer.Name,
                PaymentAmount = payment.PaymentAmount,
                PaymentMethod = payment.PaymentMethod
            };

            return Ok(paymentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PaymentDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid payment, you must fill it again !!");

            var isValidCustomer = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidCustomer)
                return BadRequest("Invalid customer Id !!");

            var payment = new Payment
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                PaymentAmount = dto.PaymentAmount,
                PaymentMethod = dto.PaymentMethod
            };

            await _service.Create(payment);

            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PaymentDto dto)
        {
            var payment = await _service.GetById(id);
            if (payment == null)
                return BadRequest($"No payment found with id: {id}");

            var isValidStoreId = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidStoreId)
                return BadRequest("Invalid customer id !!");

            payment.PaymentAmount = dto.PaymentAmount;
            payment.PaymentMethod = dto.PaymentMethod;
            payment.CustomerId = dto.CustomerId;
            payment.Id = dto.Id;

            await _service.Update(payment);
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var payment = await _service.GetById(id);

            if (payment == null)
                return NotFound($"No payment was found with id '{id}' to be deleted !!");

            await _service.Delete(payment);

            return Ok(payment);
        }
    }
}
