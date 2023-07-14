using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItem>> GetAll();
        Task<MenuItem> GetById(int id);
        Task<MenuItem> Create(MenuItem menuItem);
        Task<MenuItem> Update(MenuItem menuItem);
        Task<MenuItem> Delete(MenuItem menuItem);
    }
}
