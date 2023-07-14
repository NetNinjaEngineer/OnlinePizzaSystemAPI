using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;
using OnlinePizzaSystemAPI.Services;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var suppliers = await _supplierService.GetAll();
            return Ok(suppliers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
                return BadRequest($"No supplier with id: {id} founded !!");

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SupplierDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid supplier, you must fill it again !!");
            var supplier = new Supplier
            {
                Name = dto.Name,
                Id = dto.Id,
            };

            await _supplierService.Create(supplier);

            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SupplierDto dto)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
                return NotFound($"No supplier was found with ID: {id}");
            supplier.Name = dto.Name;
            supplier.Id = dto.Id;

            await _supplierService.Update(supplier);
            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var supplier = await _supplierService.GetById(id);

            if (supplier == null)
                return NotFound($"No supplier was found with id '{id}' to be deleted !!");

            await _supplierService.Delete(supplier);

            return Ok(supplier);
        }

    }
}
