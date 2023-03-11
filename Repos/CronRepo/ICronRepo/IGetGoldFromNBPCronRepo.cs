using NBPAPI.Models;

namespace NBPAPI.Repos.CronRepo.ICronRepo
{
    public interface IGetGoldFromNBPCronRepo
    {
        public Task GetGoldFromNBPAsync();
    }
}
