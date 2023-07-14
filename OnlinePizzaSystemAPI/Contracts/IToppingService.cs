using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface IToppingService
    {
        Task<IEnumerable<Topping>> GetAll();
        Task<Topping> GetById(int id);
        Task<Topping> Create(Topping topping);
        Task<Topping> Update(Topping topping);
        Task<Topping> Delete(Topping topping);
    }
}
