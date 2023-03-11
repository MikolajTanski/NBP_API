using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBPAPI.Mapping.DTO
{
    public class GoldPriceDTO
    {
        int Id { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Cena { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }
    }
}
