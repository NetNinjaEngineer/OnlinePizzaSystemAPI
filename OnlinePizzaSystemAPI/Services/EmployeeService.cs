using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(Employee employee)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var all = await _context.Employees
                .Include(x => x.Location)
                .ToListAsync();
            return all!;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(x => x.Location)
                .SingleOrDefaultAsync(x => x.Id == id);

            return employee!;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
