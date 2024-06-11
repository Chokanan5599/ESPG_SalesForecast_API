using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class Form_Fill
    {
        [Key]
        public long RECID { get; set; }
        public long PERSON { get; set; }
        public string? salesName { get; set; }
        public string? user { get; set; }
        public DateTime? validfrom { get; set; }
    }
}
