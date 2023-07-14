using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;
using OnlinePizzaSystemAPI.Services;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _service;
        private readonly AppDbContext _context;

        public IngredientsController(IIngredientService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No ingredients found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ingredient = await _service.GetById(id);

            if (ingredient == null)
                return BadRequest($"No ingredient with id: {id} founded !!");

            var isValidSupplierId = await _context.Suppliers.AnyAsync(x => x.Id == ingredient.SupplierId);

            if (!isValidSupplierId)
                return BadRequest("Invalid supplier id !! ");

            var ingredientDto = new IngredientDetailsDto
            {
                Id = ingredient.Id,
                Cost = ingredient.Cost,
                Name = ingredient.Name,
                InventoryId = ingredient.InventoryId,
                SupplierId = ingredient.SupplierId,
                SupplierName = ingredient.Supplier.Name,
            };

            return Ok(ingredientDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] IngredientDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid ingredient, you must fill it again !!");

            var ingredient = new Ingredient
            {
                Id = dto.Id,
                Cost = dto.Cost,
                Name = dto.Name,
                InventoryId= dto.InventoryId,
                SupplierId = dto.SupplierId,
            };

            await _service.Create(ingredient);

            return Ok(ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] IngredientDto dto)
        {
            var ingredient = await _service.GetById(id);
            if (ingredient == null)
                return BadRequest($"No ingredient found with id: {id}");

            ingredient.SupplierId = dto.SupplierId;
            ingredient.InventoryId = dto.InventoryId;
            ingredient.Cost = dto.Cost;
            ingredient.Name = dto.Name;

            await _service.Update(ingredient);
            return Ok(ingredient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ingredient = await _service.GetById(id);

            if (ingredient == null)
                return NotFound($"No ingredient was found with id '{id}' to be deleted !!");

            await _service.Delete(ingredient);

            return Ok(ingredient);
        }
    }
}
