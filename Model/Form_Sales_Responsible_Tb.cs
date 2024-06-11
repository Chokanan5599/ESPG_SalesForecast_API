using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class Form_Sales_Responsible_Tb
    {
        [Key]
        public long HCM_RECID { get; set; }
        public string Full_Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Fore_cast { get; set; }
        public decimal Total_Sales { get; set; }
        public decimal Total_CostSales { get; set; }
        public decimal Total_Margin { get; set; }
        public double Profit_THB { get; set; }
        public decimal Profit_Percentage { get; set; }

        //--------
        public string QUOTATIONID { get; set; } = string.Empty;
        public string WORKERSALESRESPONSIBLE { get; set; } = string.Empty;


    }
    public class ReceID
    {
        public List<string> Recid { get; set; }

    }
}
