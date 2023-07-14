using Microsoft.AspNetCore.Mvc;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _service;

        public MenuItemsController(IMenuItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No menu items found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var menuItem = await _service.GetById(id);

            if (menuItem == null)
                return BadRequest($"No menuItem with id: {id} founded !!");

            var menuDto = new MenuItemDto
            {
                Id = menuItem.Id,
                Description = menuItem.Description,
                Name = menuItem.Name,
                Price = menuItem.Price
            };

            return Ok(menuDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MenuItemDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid menu item, you must fill it again !!");

            var menuItem = new MenuItem
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
            };

            await _service.Create(menuItem);

            return Ok(menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] MenuItemDto dto)
        {
            var menuItem = await _service.GetById(id);
            if (menuItem == null)
                return BadRequest($"No menu item found with id: {id}");

            menuItem.Name = dto.Name;
            menuItem.Description = dto.Description;
            menuItem.Id = dto.Id;
            menuItem.Price = dto.Price;

            await _service.Update(menuItem);
            return Ok(menuItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _service.GetById(id);

            if (item == null)
                return NotFound($"No menu item was found with id '{id}' to be deleted !!");

            await _service.Delete(item);

            return Ok(item);
        }
    }
}
