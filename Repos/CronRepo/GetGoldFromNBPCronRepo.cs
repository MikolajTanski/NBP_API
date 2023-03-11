using NBPAPI.Middelware.Exception;
using NBPAPI.Models;
using NBPAPI.Repos.CronRepo.ICronRepo;
using Newtonsoft.Json;
using NuGet.DependencyResolver;
using System.Diagnostics;

namespace NBPAPI.Repos.CronRepo
{
    public class GetGoldFromNBPCronRepo : IGetGoldFromNBPCronRepo
    {
        private readonly DataContext _db;

        public GetGoldFromNBPCronRepo(DataContext db)
        {
            _db = db;
        }

        //TODO refactor do serwisu

        /// <summary>
        /// metoda pozwalajaca pobierac ceny złota z nbp na podstawie url
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task GetGoldFromNBPAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://api.nbp.pl/api/cenyzlota/?format=json");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var goldPrices = JsonConvert.DeserializeObject<List<GoldPrice>>(content);

                    // dla kazdego elementu z listy nowy obiekt zapisywany w bazie z czasem importu
                    var importedGoldPrices = new List<GoldPrice>();

                    foreach (var item in goldPrices)
                    {
                        var newGoldPrice = new GoldPrice
                        {
                            Cena = item.Cena,
                            Data = item.Data,
                            //TODO: zły format daty +1
                            ImportTime = DateTime.UtcNow
                        };

                        if (item == null)
                            throw new NotFoundException("nic nie dostalismy z nbp");

                        importedGoldPrices.Add(newGoldPrice);
                    }

                    await _db.AddRangeAsync(importedGoldPrices);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    Debug.WriteLine("Nie udało się pobrać danych z adresu URL.");
                }
            }
        }
    }
}

