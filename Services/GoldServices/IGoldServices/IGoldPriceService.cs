using NBPAPI.Models;

namespace NBPAPI.Services.GoldServices.IGoldServices
{
    public interface IGoldPriceService
    {
        Task<GoldPrice> GetByIdAsync(int id);
        Task<List<GoldPrice>> GetAllAsync();
        Task AddAsync(GoldPrice goldPrice);
        Task UpdateAsync(GoldPrice goldPrice);
        Task DeleteAsync(int id);
        Task<List<GoldPrice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
