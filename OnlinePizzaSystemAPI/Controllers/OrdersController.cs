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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly AppDbContext _context;

        public OrdersController(IOrderService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No Orders found !!");
            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _service.GetById(id);

            if (order == null)
                return BadRequest($"No order founded with id: {id} !!");

            var dto = new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderTime = order.OrderTime,
                CustomerId = order.CustomerId,
                DeliveryDriverId = order.DeliveryDriverId,
                DeliveryOptions = order.DeliveryOptions,
                TotalCost = order.TotalCost
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid order, you must fill it again !!");

            var isValidCustomerId = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidCustomerId)
                return BadRequest("Invalid customer Id !!");

            var isValidDeliveryDriverId = await _context.DeliveryDrivers.AnyAsync(x => x.Id == dto.DeliveryDriverId);
            if (!isValidDeliveryDriverId)
                return BadRequest("Invalid Driver Id Id !!");

            var order= new Order
            {
                Id = dto.Id,
                CustomerId= dto.CustomerId,
                DeliveryDriverId = dto.DeliveryDriverId,
                TotalCost= dto.TotalCost,
                DeliveryOptions = dto.DeliveryOptions,
                OrderDate = dto.OrderDate,
                OrderTime = dto.OrderTime,
            };

            await _service.Create(order);

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] OrderDto dto)
        {
            var exist = await _service.GetById(id);
            if (exist == null)
                return BadRequest($"No order found with id: {id}");

            var isValidCustomerId = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidCustomerId)
                return BadRequest("Invalid customer Id !!");

            var isValidDeliveryDriverId = await _context.DeliveryDrivers.AnyAsync(x => x.Id == dto.DeliveryDriverId);
            if (!isValidDeliveryDriverId)
                return BadRequest("Invalid Driver Id Id !!");

            exist.DeliveryOptions = dto.DeliveryOptions;
            exist.DeliveryDriverId = dto.DeliveryDriverId;
            exist.OrderDate = dto.OrderDate;
            exist.OrderTime = dto.OrderTime;
            exist.CustomerId = dto.CustomerId;
            exist.TotalCost = dto.TotalCost;
            exist.Id = dto.Id;

            await _service.Update(exist);
            return Ok(exist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var del = await _service.GetById(id);

            if (del == null)
                return NotFound($"No order was found with id '{id}' to be deleted !!");

            await _service.Delete(del);

            return Ok(del);
        }

    }
}
