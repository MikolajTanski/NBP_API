using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBPAPI.Models;
using NBPAPI.Services.GoldServices.IGoldServices;

namespace NBPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldPriceController : ControllerBase
    {
        private readonly IGoldPriceService _goldPriceService;
        //private readonly IMapper _mapper;

        public GoldPriceController(IGoldPriceService goldPriceService)
        {
            _goldPriceService = goldPriceService;
        }

        [HttpGet]
        [Route("GetGoldPriceById")]
        public async Task<ActionResult<GoldPrice>> GetById(int id)
        {
            var result = await _goldPriceService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet]
        [Route("GetAllGoldPrice")]
        public async Task<ActionResult<List<GoldPrice>>> GetAll()
        {
            var result = await _goldPriceService.GetAllAsync();
            return result;
        }

        [HttpPost]
        [Route("AddGoldPrice")]
        public async Task Add([FromBody] GoldPrice goldPrice)
        {
            await _goldPriceService.AddAsync(goldPrice);
        }

        [HttpPut]
        [Route("UpdateGoldPrice")]
        public async Task  Update(int id, [FromBody] GoldPrice goldPrice)
        {
            await _goldPriceService.UpdateAsync(id,goldPrice);
        }

        [HttpDelete]
        [Route("DeleteGoldPrice")]
        public async Task  Delete(int id)
        {
            await _goldPriceService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("GetInDateRange")]
        public async Task<ActionResult<List<GoldPrice>>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = await _goldPriceService.GetByDateRangeAsync(startDate, endDate);
            return result;
        }
    }
}
