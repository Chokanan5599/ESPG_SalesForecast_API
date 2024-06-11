using System.ComponentModel.DataAnnotations;
namespace ESPG_SalesForecast_API.Model
{
    public class Form_Sales_Forecast_List_Tb
    {
        [Key]
        public long HCM_RECID { get; set; }
        public long recID { get; set; }
        public string QuotationID { get; set; } = string.Empty;
        public string WORKERSALESRESPONSIBLE { get; set; } = string.Empty;
        public string Assign_To { get; set; } = string.Empty ;

        public string Customer_Account { get; set; } = string.Empty;
        public string Customer_Name { get; set;} = string.Empty;
        public string item_Number { get; set; } = string.Empty;

        public string Formula_Version { get; set; } = string.Empty;  

        public Decimal Quantity { get; set; }   
        public string Quantity_Type { get; set; } = string.Empty;    

        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;


        public string Quotation_No { get; set; } = string.Empty;
        public string Sales_Order_No { get; set; } = string.Empty;
        public string Sales_Order_Status { get; set; } = string.Empty;

        //---> FROM COST MAGIM <--------

        public string TransportaTion_Type { get; set; } = string.Empty;
        public decimal expenses_2 { get; set; }
        public decimal expenses_5 { get; set; }
        public decimal expenses_9 { get; set; }
        public decimal expenses_10 { get; set; }
        public decimal expenses_13 { get; set; }
        public decimal expenses_14 { get; set; }
        public decimal expenses_16 { get; set; }
        public decimal specialdisc { get; set; }

        public decimal expenses_1 { get; set; }
        public decimal expenses_18 { get; set; }
        public decimal expenses_6 { get; set; }
        public decimal expenses_7 { get; set; }
        public decimal expenses_11 { get; set; }
        public decimal expenses_12 { get; set; }
        public decimal expenses_15 { get; set; }
        public decimal expenses_Perton { get; set; }
        public string remark2 { get; set; } = string.Empty ;

        public decimal priceper_Ton { get; set; }
        public string taxItem_Group { get; set; } = string.Empty;
        public decimal total_Sales { get; set; }
        public decimal costper_Ton { get; set; }
        public decimal total_Cost_Sales { get; set; }
        public decimal margin_Ton { get; set; }
        public decimal total_Margin { get; set; }
        public decimal margin_Percen { get; set; }
        public decimal credit_limit { get; set; }
    }
}
