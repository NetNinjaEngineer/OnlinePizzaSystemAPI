using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAll();
        Task<OrderItem> GetById(int id);
        Task<OrderItem> Create(OrderItem orderItem);
        Task<OrderItem> Update(OrderItem orderItem);
        Task<OrderItem> Delete(OrderItem orderItem);
    }
}
