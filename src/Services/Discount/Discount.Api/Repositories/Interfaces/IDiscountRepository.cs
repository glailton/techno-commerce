using System.Threading.Tasks;
using Discount.Api.Entities;

namespace Discount.Api.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreatingDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}