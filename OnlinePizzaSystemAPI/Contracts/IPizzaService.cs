using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAll();
        Task<Pizza> GetById(int id);
        Task<Pizza> Create(Pizza pizza);
        Task<Pizza> Update(Pizza pizza);
        Task<Pizza> Delete(Pizza pizza);
    }
}
