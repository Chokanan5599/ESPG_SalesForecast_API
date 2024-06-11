using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class ETP_Import_Sales_File_History
    {
        public string FILENAME { get; set; } = string.Empty;
        public DateTime FROMDATE { get; set; }
        public int STATUSIMPORTSALES { get; set; }
        public DateTime TODATE { get; set; }
        public DateTime CREATEDDATETIME { get; set; }
        public string CREATEDBY { get; set; } = string.Empty;
        public string DATAAREAID { get; set; } = string.Empty;
        public int RECVERSION { get; set; }
        public long PARTITION { get; set; }
        [Key]
        public long RECID { get; set; }
        public string ETP_APPROVER_ID { get; set; } = string.Empty;
    }
}
