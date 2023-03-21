using Hangfire;
using Microsoft.AspNetCore.Mvc;
using NBPAPI.Repos.CronRepo.ICronRepo;
using NBPAPI.Services.CronService.ICronService;

[Route("api/[controller]")]
[ApiController]
public class CronController : ControllerBase
{
    private readonly IGetGoldFromNBPCronService _GetGoldFromNBPRService;

    public CronController(IGetGoldFromNBPCronService GetGoldFromNBPService)
    {
        _GetGoldFromNBPRService = GetGoldFromNBPService;
    }

    [HttpPost]
    [Route("JobForDailyGoldPrice")]
    public async Task<IActionResult> JobForDailyGoldPrice()
    {
        RecurringJob.AddOrUpdate(
      "JobForDailyGoldPrice",
      () => _GetGoldFromNBPRService.GetGoldFromNBPAsync(),
      "0 */5 * * *"); // Run every 5 hours

        return Ok($"Job Completed. Cool!");
    }
}
