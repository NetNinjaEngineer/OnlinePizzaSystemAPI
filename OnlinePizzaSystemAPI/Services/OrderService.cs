using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Delete(Order order)
        {
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var all = await _context.Orders
                .Include(x => x.DeliveryDriver)
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ToListAsync();
            return all!;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _context.Orders
                .Include(x => x.DeliveryDriver)
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .SingleOrDefaultAsync(x => x.Id == id);

            return order!;
        }

        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
