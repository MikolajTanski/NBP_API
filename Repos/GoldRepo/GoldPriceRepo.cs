using Microsoft.EntityFrameworkCore;
using NBPAPI.Models;
using NBPAPI.Repos.GoldRepo.IGoldRepo;

namespace NBPAPI.Repos.GoldRepo
{
    public class GoldPriceRepo : IGoldPriceRepo
    {
        private readonly DataContext _db;

        public GoldPriceRepo(DataContext db)
        {
            _db = db;
        }

        public async Task<GoldPrice> GetByIdAsync(int id)
        {
            return await _db.GoldPrices.FindAsync(id);
        }

        public async Task<List<GoldPrice>> GetAllAsync()
        {
            return await _db.GoldPrices.ToListAsync();
        }

        public async Task AddAsync(GoldPrice goldPrice)
        {
            await _db.GoldPrices.AddAsync(goldPrice);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoldPrice goldPrice)
        {
            _db.GoldPrices.Update(goldPrice);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(GoldPrice goldPrice)
        {
            _db.GoldPrices.Remove(goldPrice);
            await _db.SaveChangesAsync();
        }

        public async Task<List<GoldPrice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _db.GoldPrices
                .Where(gp => gp.ImportTime >= startDate && gp.ImportTime <= endDate)
                .ToListAsync();
        }
        
        //TODO: średnia cena? średnia cena dla jakiegos okresu?

        //public async Task<decimal> GetAveragePriceAsync(List<GoldPrice> goldPrices)
        //{
        //    if (goldPrices == null || goldPrices.Count == 0)
        //    {
        //        throw new ArgumentException("GoldPrices cannot be null or empty");
        //    }

        //    decimal sum = 0;
        //    foreach (var goldPrice in goldPrices)
        //    {
        //        sum += goldPrice.PricePerGram;
        //    }

        //    return sum / goldPrices.Count;
        //}

    }

}
