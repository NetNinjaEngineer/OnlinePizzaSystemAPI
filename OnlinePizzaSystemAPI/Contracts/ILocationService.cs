using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAll();
        Task<Location> GetById(int id);
        Task<Location> Create(Location location);
        Task<Location> Update(Location location);
        Task<Location> Delete(Location location);
    }
}
