using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Location> Create(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> Delete(Location location)
        {
            _context.Remove(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            var all = await _context.Locations
                .Include(x => x.Employees)
                .ToListAsync();
            return all!;
        }

        public async Task<Location> GetById(int id)
        {
            var location = await _context.Locations
                .Include(x => x.Employees)
                .SingleOrDefaultAsync(x => x.Id == id);
            return location!;
        }

        public async Task<Location> Update(Location location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
