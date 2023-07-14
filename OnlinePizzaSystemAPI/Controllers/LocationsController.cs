using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _locationService.GetAll();
            if (all == null)
                return BadRequest("No locations found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var location = await _locationService.GetById(id);

            if (location == null)
                return BadRequest($"No location with id: {id} founded !!");

            var locationDto = new LocationDto
            {
                Id = location.Id,
                Address = location.Address,
                Email = location.Email,
                PhoneNumber = location.PhoneNumber
            };

            return Ok(locationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LocationDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid location, you must fill it again !!");

            var location = new Location
            {
                Id = dto.Id,
                PhoneNumber= dto.PhoneNumber,
                Email = dto.Email,
                Address = dto.Address,
            };

            await _locationService.Create(location);

            return Ok(location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] LocationDto dto)
        {
            var location = await _locationService.GetById(id);
            if (location == null)
                return BadRequest($"No location found with id: {id}");

            location.PhoneNumber = dto.PhoneNumber;
            location.Address = dto.Address;
            location.Email = dto.Email;
            location.Id = dto.Id;

            await _locationService.Update(location);
            return Ok(location);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var location = await _locationService.GetById(id);

            if (location == null)
                return NotFound($"No location was found with id '{id}' to be deleted !!");

            await _locationService.Delete(location);

            return Ok(location);
        }
    }
}
