using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using OnlinePizzaSystemAPI.Contracts;
using OnlinePizzaSystemAPI.Data;
using OnlinePizzaSystemAPI.Data.Config;
using OnlinePizzaSystemAPI.Dtos;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly AppDbContext _context;

        public CouponsController(ICouponService couponService, AppDbContext context)
        {
            _couponService = couponService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var coupons = await _couponService.GetAll();
            if (coupons == null)
                return BadRequest("No coupons found");
            return Ok(coupons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var coupon = await _couponService.GetById(id);
            if (coupon == null)
                return BadRequest("No coupons found");
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CouponDto dto)
        {
            var isValidCustomerId = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidCustomerId)
                return BadRequest("Invalid customer id");

            var coupon = new Coupon
            {
                Id = dto.Id,
                Code = dto.Code,
                CustomerId = dto.CustomerId,
                DiscountAmount = dto.DiscountAmount,
                ExpirationDate = dto.ExpirationDate,
                UsageCount = dto.UsageCount,
            };

            if (coupon == null)
                return BadRequest("No coupons found");

            await _couponService.Create(coupon);

            return Ok(coupon);
        }

    }
}
