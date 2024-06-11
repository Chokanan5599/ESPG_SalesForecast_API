using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class DirpersonName
    {
        public long PERSON { get; set; }
        public string FIRSTNAME { get; set; } = string.Empty;
        public string MIDDLENAME { get; set; } = string.Empty;
        public string LASTNAME { get; set; } = string.Empty;
        public DateTime VALIDFROM { get; set; }
        public int VALIDFROMTZID { get; set; }
        public DateTime VALIDTO { get; set; }
        public int VALIDTOTZID { get; set; }
        public string MODIFIEDBY { get; set; } = string.Empty;
        public string CREATEDBY { get; set; } = string.Empty;
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }
    }
}
