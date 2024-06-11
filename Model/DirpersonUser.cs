using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class DirpersonUser
    {
        public long PERSONPARTY { get; set; }
        public string? USER_ { get; set; }
        public DateTime VALIDTO { get; set; }
        public int VALIDTOTZID { get; set; }
        public DateTime VALIDFROM { get; set; }
        public int VALIDFROMTZID { get; set; }
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }

    }
}
