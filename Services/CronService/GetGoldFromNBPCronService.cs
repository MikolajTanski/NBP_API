using NBPAPI.Models;
using NBPAPI.Repos.CronRepo.ICronRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPAPI.Services.CronService.ICronService
{
    public class GetGoldFromNBPCronService : IGetGoldFromNBPCronService
    {
        private readonly IGetGoldFromNBPCronRepo _repo;

        public GetGoldFromNBPCronService(IGetGoldFromNBPCronRepo repo)
        {
            _repo = repo;
        }

        public async Task GetGoldFromNBPAsync()
        {
            await _repo.GetGoldFromNBPAsync();
        }
    }
}
