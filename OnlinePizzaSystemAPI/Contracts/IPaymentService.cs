using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<Payment> Create(Payment payment);
        Task<Payment> Update(Payment payment);
        Task<Payment> Delete(Payment payment);
    }
}
