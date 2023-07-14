using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class DeliveryDriverService: IDeliveryDriverService
    {
        private readonly AppDbContext _context;

        public DeliveryDriverService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeliveryDriver> Create(DeliveryDriver driver)
        {
            _context.DeliveryDrivers.Add(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<DeliveryDriver> Delete(DeliveryDriver driver)
        {
            _context.Remove(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<IEnumerable<DeliveryDriver>> GetAll()
        {
            var all = await _context.DeliveryDrivers
                .Include(x => x.Store)
                .Include(x => x.Orders)
                .ToListAsync();
            return all;
        }

        public async Task<DeliveryDriver> GetById(int id)
        {
            var driver = await _context.DeliveryDrivers
                .Include(x => x.Store)
                .Include(x => x.Orders)
                .SingleOrDefaultAsync(x => x.Id == id);

            return driver!;
        }

        public async Task<DeliveryDriver> Update(DeliveryDriver driver)
        {
            _context.DeliveryDrivers.Update(driver);
            await _context.SaveChangesAsync();
            return driver;
        }
    }
}
