using NBPAPI.Middelware.Exception;
using NBPAPI.Models;
using NBPAPI.Repos.GoldRepo.IGoldRepo;
using NBPAPI.Services.GoldServices.IGoldServices;

namespace NBPAPI.Services.GoldServices
{
    public class GoldPriceService : IGoldPriceService
    {
        private readonly IGoldPriceRepo _goldPriceRepo;
        public GoldPriceService(IGoldPriceRepo goldPriceRepo)
        {
            _goldPriceRepo= goldPriceRepo;
        }
        public async Task<GoldPrice> GetByIdAsync(int id)
        {
            var result = await _goldPriceRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException("nie znaleziono ceny złota.");

            return result;
        }

        public async Task<List<GoldPrice>> GetAllAsync()
        {
           var result = await _goldPriceRepo.GetAllAsync();

            if (result == null)
                throw new NotFoundException("nie znaleziono ceny złota.");

            return result;
        }

        public async Task AddAsync(GoldPrice goldPrice)
        {
           await _goldPriceRepo.AddAsync(goldPrice);
        }

        public async Task UpdateAsync(int id, GoldPrice goldPrice)
        {
           await _goldPriceRepo.UpdateAsync(id, goldPrice);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _goldPriceRepo.GetByIdAsync(id);

            if (result == null)
                throw new NotFoundException("nie znaleziono ceny złota.");

            await _goldPriceRepo.DeleteAsync(result);
        }

        public async Task<List<GoldPrice>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           var result = await _goldPriceRepo.GetByDateRangeAsync(startDate, endDate);

           return result;
        }
    }
}
