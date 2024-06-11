using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class Form_Related_Info
    {
        [Key]
        public string QUOTATIONID { get; set; } = string.Empty;
        public string  SALES_ORDER_NO{ get; set; } = string.Empty;
        public string  SALES_ORDER_STATUS { get; set; } = string.Empty;

    }
}
