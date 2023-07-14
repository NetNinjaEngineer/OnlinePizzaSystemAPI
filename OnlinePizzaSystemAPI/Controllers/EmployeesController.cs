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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly AppDbContext _context;

        public EmployeesController(IEmployeeService employeeService, AppDbContext context)
        {
            this.employeeService = employeeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await employeeService
                .GetAll();
            if (all == null)
                return BadRequest("No employees found !!");

            return Ok(all);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var employee = await employeeService.GetById(id);

            if (employee == null)
                return BadRequest($"No employee founded with id: {id} !!");

            var employeeDto = new EmployeeDetailsDto
            {
                Id = employee.Id,
                LocationId = employee.LocationId,
                LocationName = employee.Location.Address,
                PhoneNumber = employee.PhoneNumber,
                Name = employee.Name,
                Position = employee.Position
            };

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid employee, you must fill it again !!");

            var isLocation = await _context.Locations.AnyAsync(x => x.Id == dto.LocationId);
            if (!isLocation)
                return BadRequest("Invalid location Id !!");

            var employee = new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                LocationId = dto.LocationId,
                Position = dto.Position
            };

            await employeeService.Create(employee);

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeDto dto)
        {
            var exist = await employeeService.GetById(id);
            if (exist == null)
                return BadRequest($"No employee found with id: {id}");

            var isValidEmployee = await _context.Locations.AnyAsync(x => x.Id == dto.LocationId);
            if (!isValidEmployee)
                return BadRequest("Invalid employee Id !!");
            exist.LocationId = dto.LocationId;
            exist.Name = dto.Name;
            exist.PhoneNumber = dto.PhoneNumber;
            exist.Position = dto.Position;

            await employeeService.Update(exist);
            return Ok(exist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var del = await employeeService.GetById(id);

            if (del == null)
                return NotFound($"No employee was found with id '{id}' to be deleted !!");

            await employeeService.Delete(del);

            return Ok(del);
        }
    }
}
