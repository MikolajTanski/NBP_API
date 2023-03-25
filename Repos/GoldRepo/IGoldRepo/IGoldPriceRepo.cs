using NBPAPI.Models;

namespace NBPAPI.Repos.GoldRepo.IGoldRepo
{
    public interface IGoldPriceRepo
    {
        Task<GoldPrice> GetByIdAsync(int id);
        Task<List<GoldPrice>> GetAllAsync();
        Task AddAsync(GoldPrice goldPrice);
        Task UpdateAsync(int id, GoldPrice goldPrice);
        Task DeleteAsync(GoldPrice goldPrice);
        Task<List<GoldPrice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
         //TODO: średnia cena
        //Task<decimal> GetAveragePriceAsync(List<GoldPrice> goldPrices);
    }
}

