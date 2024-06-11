using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class HCM_Worker
    {
        public long PERSON { get; set; }
        public string? PERSONNELNUMBER { get; set; }
        public DateTime MODIFIEDDATETIME { get; set; }
        public string? MODIFIEDBY { get; set; }
        public DateTime CREATEDDATETIME { get; set; }
        public string? CREATEDBY { get; set; }
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }
    }
}
