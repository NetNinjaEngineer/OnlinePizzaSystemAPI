using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> Create(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredient> Delete(Ingredient ingredient)
        {
            _context.Remove(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            var all = await _context.Ingredients
                .Include(x => x.Supplier)
                .ToListAsync();
            return all!;
        }

        public async Task<Ingredient> GetById(int id)
        {
            var ingredient = await _context.Ingredients
                .Include(x => x.Supplier)
                .SingleOrDefaultAsync(x => x.Id == id);
            return ingredient!;
        }

        public async Task<Ingredient> Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }
    }
}
