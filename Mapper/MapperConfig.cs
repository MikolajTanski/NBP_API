using AutoMapper;
using NBPAPI.Mapping.DTO;
using NBPAPI.Models;

namespace NBPAPI.Mapping
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring GoldPrice and GoldPriceDTO
                cfg.CreateMap<GoldPrice, GoldPriceDTO>();
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }

}
