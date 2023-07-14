using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly AppDbContext _context;

        public OrderItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> Delete(OrderItem orderItem)
        {
            _context.Remove(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            var all = await _context.OrderItems
                    .Include(x => x.Order)
                    .ToListAsync();
            return all!;
        }

        public async Task<OrderItem> GetById(int id)
        {
            var item = await _context.OrderItems
                 .Include(x => x.Order)
                .SingleOrDefaultAsync(x => x.Id == id);
            return item!;
        }

        public async Task<OrderItem> Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }
    }
}
