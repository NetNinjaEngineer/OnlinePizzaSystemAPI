using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Contracts
{
    public interface ICouponService
    {
        Task<IEnumerable<Coupon>> GetAll();
        Task<Coupon> GetById(int id);
        Task<Coupon> Create(Coupon coupon);
    }
}
