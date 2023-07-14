using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Delete(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var all = await _context.Customers
                .ToListAsync();
            return all!;
        }

        public async Task<Customer> GetById(int id)
        {
            var payment = await _context.Customers
                .SingleOrDefaultAsync(x => x.Id == id);
            return payment!;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
