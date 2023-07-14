using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No order item found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var item = await _service.GetById(id);

            if (item == null)
                return BadRequest($"No order item with id: {id} founded !!");

            var dto = new OrderItemDto
            {
                Id = item.Id,
                OrderId = item.OrderId,
                Price = item.Price,
                Quantity = item.Quantity,
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderItemDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid order item, you must fill it again !!");

            var orderItem = new OrderItem
            {
                Id = dto.Id,
                Quantity = dto.Quantity,
                Price= dto.Price,
                OrderId= dto.OrderId,
            };

            await _service.Create(orderItem);

            return Ok(orderItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]  OrderItemDto dto)
        {
            var item = await _service.GetById(id);
            if (item == null)
                return BadRequest($"No order item found with id: {id}");
            
            item.OrderId = dto.OrderId;
            item.Price = dto.Price;
            item.Quantity = dto.Quantity;
            item.Id = dto.Id;

            await _service.Update(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedItem = await _service.GetById(id);

            if (deletedItem == null)
                return NotFound($"No order item was found with id '{id}' to be deleted !!");

            await _service.Delete(deletedItem);

            return Ok(deletedItem);
        }
    }
}