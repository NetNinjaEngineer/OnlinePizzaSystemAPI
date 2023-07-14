using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly AppDbContext _context;

        public PizzaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pizza> Create(Pizza pizza)
        {
            await _context.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza> Delete(Pizza pizza)
        {
            _context.Remove(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            var all = await _context.Pizzas.Include(x => x.Toppings).ToListAsync();
            return all;
        }

        public async Task<Pizza> GetById(int id)
        {
            var pizza = await _context.Pizzas
                .Include(x => x.Toppings)
                .SingleOrDefaultAsync(x => x.Id == id);
            return pizza!;
        }

        public async Task<Pizza> Update(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }
    }
}
