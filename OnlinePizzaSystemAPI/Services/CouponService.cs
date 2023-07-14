using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Models;
using System.Runtime.CompilerServices;

namespace OnlinePizzaSystemAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly AppDbContext _context;

        public CouponService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> Create(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<IEnumerable<Coupon>> GetAll()
        {
            var coupons = await _context.Coupons.ToListAsync();
            return coupons;
        }

        public async Task<Coupon> GetById(int id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);
            return coupon;
        }
    }
}
