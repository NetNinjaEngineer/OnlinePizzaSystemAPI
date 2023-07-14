using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> Create(Supplier supplier)
        {
            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> Delete(Supplier supplier)
        {
            _context.Remove(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var all = await _context.Suppliers.Include(x => x.Ingredients).ToListAsync();
            return all;
        }

        public async Task<Supplier> GetById(int id)
        {
            var supplier = await _context.Suppliers
                .Include(x => x.Ingredients)
                .SingleOrDefaultAsync(x => x.Id == id);
            return supplier!;
        }

        public async Task<Supplier> Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}
