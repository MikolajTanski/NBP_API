using Hangfire;
using Microsoft.AspNetCore.Mvc;
using NBPAPI.Repos.CronRepo.ICronRepo;

[Route("api/[controller]")]
[ApiController]
public class CronController : ControllerBase
{
    private readonly IGetGoldFromNBPCronRepo _iGetGoldFromNBPRepo;

    public CronController(IGetGoldFromNBPCronRepo iGetGoldFromNBPRepo)
    {
        _iGetGoldFromNBPRepo = iGetGoldFromNBPRepo;
    }

    [HttpPost]
    [Route("JobForDailyGoldPrice")]
    public async Task<IActionResult> JobForDailyGoldPrice()
    {
        RecurringJob.AddOrUpdate(
      "JobForDailyGoldPrice",
      () => _iGetGoldFromNBPRepo.GetGoldFromNBPAsync(),
      "0 */5 * * *"); // Run every 5 hours

        return Ok($"Job Completed. Cool!");
    }
}
