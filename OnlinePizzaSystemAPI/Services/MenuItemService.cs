using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly AppDbContext _context;

        public MenuItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> Create(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<MenuItem> Delete(MenuItem menuItem)
        {
            _context.Remove(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            var all = await _context.MenuItems
                .Include(x => x.Customers)
                .Include(x => x.OrderMenuItems)
                .ToListAsync();
            return all!;
        }

        public async Task<MenuItem> GetById(int id)
        {
            var menuItem = await _context.MenuItems
                .Include(x => x.Customers)
                .Include(x => x.OrderMenuItems)
                .SingleOrDefaultAsync(x => x.Id == id);
            return menuItem!;
        }

        public async Task<MenuItem> Update(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }
    }
}
