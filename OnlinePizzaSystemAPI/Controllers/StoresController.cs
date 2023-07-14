using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;
using OnlinePizzaSystemAPI.Services;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _service;

        public StoresController(IStoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stores = await _service.GetAll();
            if (stores == null)
                return BadRequest("No Stores founded !!");
            return Ok(stores);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var store = await _service.GetById(id);

            if (store == null)
                return BadRequest($"No store with id: {id} founded !!");

            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] StoreDto dto)
        {
            var store = new Store
            {
                Id = dto.Id,
                StoreManager = dto.StoreManager,
                StoreName = dto.StoreName,
            };

            await _service.Create(store);

            return Ok(store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] StoreDto dto)
        {
            var store = await _service.GetById(id);

            if (store == null)
                return NotFound($"No store was found with ID: {id} to be modified !!");
            store.StoreManager = dto.StoreManager;
            store.StoreName = dto.StoreName;
            store.Id = dto.Id;

            await _service.Update(store);
            return Ok(store);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var store = await _service.GetById(id);

            if (store == null)
                return NotFound($"No store was found with id '{id}' to be deleted !!");

            await _service.Delete(store);

            return Ok(store);
        }
    }
}
