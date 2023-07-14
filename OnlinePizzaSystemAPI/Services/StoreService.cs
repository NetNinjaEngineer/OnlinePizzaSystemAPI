using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class StoreService : IStoreService
    {
        private readonly AppDbContext _context;

        public StoreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Store> Create(Store store)
        {
            await _context.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store> Delete(Store store)
        {
            _context.Remove(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            var all = await _context.Stores
                .Include(x => x.DeliveryDrivers).ToListAsync();
            return all;
        }

        public async Task<Store> GetById(int id)
        {
            var store = await _context.Stores
                .Include(x => x.DeliveryDrivers)
                .SingleOrDefaultAsync(x => x.Id == id);
            return store!;
        }

        public async Task<Store> Update(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
            return store;
        }
    }
}
