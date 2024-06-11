using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class ETP_Import_Sales_History
    {
        public string BOMID { get; set; } = string.Empty;
        public double COST_1 { get; set; }
        public double COST_10 { get; set; }
        public double COST_2 { get; set; }
        public double COST_3 { get; set; }
        public double COST_4 { get; set; }
        public double COST_5 { get; set; }
        public double COST_6 { get; set; }
        public double COST_7 { get; set; }
        public double COST_8 { get; set; }
        public double COST_9 { get; set; }
        public decimal COSTPERTON { get; set; }
        public int CREATFORMULA { get; set; }
        public string CURRENCYCODE { get; set; } = string.Empty;
        public string CUSTACCOUNT { get; set; } = string.Empty;
        public string CUSTNAME { get; set; } = string.Empty;
        public string DATAAREANAME { get; set; } = string.Empty;
        public decimal EXPENSES_1 { get; set; }
        public decimal EXPENSES_10 { get; set; }
        public decimal EXPENSES_11 { get; set; }
        public decimal EXPENSES_12 { get; set; }
        public decimal EXPENSES_13 { get; set; }
        public decimal EXPENSES_14 { get; set; }
        public decimal EXPENSES_15 { get; set; }
        public decimal EXPENSES_2 { get; set; }
        public decimal EXPENSES_3 { get; set; }
        public decimal EXPENSES_4 { get; set; }
        public decimal EXPENSES_5 { get; set; }
        public decimal EXPENSES_6 { get; set; }
        public decimal EXPENSES_7 { get; set; }
        public decimal EXPENSES_8 { get; set; }
        public decimal EXPENSES_9 { get; set; }
        public decimal EXPENSESPERTON { get; set; }
        public int FILEREFRECID { get; set; }
        public decimal FORECAST { get; set; }
        public string ITEM_SPEC { get; set; } = string.Empty;
        public string ITEMID { get; set; } = string.Empty;
        public decimal MARGINPERCEN { get; set; }
        public decimal MARGINTON { get; set; }
        public int NO { get; set; }
        public double PERCEN_1 { get; set; }
        public double PERCEN_10 { get; set; }
        public double PERCEN_2 { get; set; }
        public double PERCEN_3 { get; set; }
        public double PERCEN_4 { get; set; }
        public double PERCEN_5 { get; set; }
        public double PERCEN_6 { get; set; }
        public double PERCEN_7 { get; set; }
        public double PERCEN_8 { get; set; }
        public double PERCEN_9 { get; set; }
        public double PICKCOST_1 { get; set; }
        public double PICKCOST_10 { get; set; }
        public double PICKCOST_2 { get; set; }
        public double PICKCOST_3 { get; set; }
        public double PICKCOST_4 { get; set; }
        public double PICKCOST_5 { get; set; }
        public double PICKCOST_6 { get; set; }
        public double PICKCOST_7 { get; set; }
        public double PICKCOST_8 { get; set; }
        public double PICKCOST_9 { get; set; }
        public string PICKITEM_1 { get; set; } = string.Empty;
        public string PICKITEM_10 { get; set; } = string.Empty;
        public string PICKITEM_2 { get; set; } = string.Empty;
        public string PICKITEM_3 { get; set; } = string.Empty;
        public string PICKITEM_4 { get; set; } = string.Empty;
        public string PICKITEM_5 { get; set; } = string.Empty;
        public string PICKITEM_6 { get; set; } = string.Empty;
        public string PICKITEM_7 { get; set; } = string.Empty;
        public string PICKITEM_8 { get; set; } = string.Empty;
        public string PICKITEM_9 { get; set; } = string.Empty;
        public string PLANNINGITEM { get; set; } = string.Empty;
        public string PRICEDISCJOURNALNUM { get; set; } = string.Empty;
        public decimal PRICEPERTON { get; set; }
        public string PRODID { get; set; } = string.Empty;
        public string QUOTATIONID { get; set; } = string.Empty;
        public string REMARK { get; set; } = string.Empty;
        public string REMARK2 { get; set; } = string.Empty;
        public string SALE { get; set; } = string.Empty;
        public string SCOOPINGMETHOD { get; set; } = string.Empty;
        public string SITE { get; set; } = string.Empty;
        public double STDPRICE_1 { get; set; }
        public double STDPRICE_10 { get; set; }
        public double STDPRICE_2 { get; set; }
        public double STDPRICE_3 { get; set; }
        public double STDPRICE_4 { get; set; }
        public double STDPRICE_5 { get; set; }
        public double STDPRICE_6 { get; set; }
        public double STDPRICE_7 { get; set; }
        public double STDPRICE_8 { get; set; }
        public double STDPRICE_9 { get; set; }
        public decimal TOTALCOST { get; set; }
        public decimal TOTALCOSTSALES { get; set; }
        public decimal TOTALMARGIN { get; set; }
        public double TOTALPERCEN { get; set; }
        public decimal TOTALSALES { get; set; }
        public string TYPE_CUSTOMER { get; set; } = string.Empty;
        public string VERSION { get; set; } = string.Empty;
        public string VERSIONSALE { get; set; } = string.Empty;
        public string DATAAREAID { get; set; } = string.Empty;
        public int RECVERSION { get; set; }
        public int PARTITION { get; set; }
        [Key]public int RECID { get; set; }
        public decimal EXPENSES_16 { get; set; }
        public decimal EXPENSES_17 { get; set; }
        public decimal EXPENSES_18 { get; set; }
        public string SALESIDREF { get; set; } = string.Empty;
        public string ETP_APPROVER_ID { get; set; } = string.Empty;
        public int SENDQUOTATION_CASEEDIT { get; set; }
        public Int64 WORKERSALESRESPONSIBLE { get; set; }
        public double ADB { get; set; }
        public string BOMID_1 { get; set; } = string.Empty;
        public string BOMID_10 { get; set; } = string.Empty;
        public string BOMID_2 { get; set; } = string.Empty;
        public string BOMID_3 { get; set; } = string.Empty;
        public string BOMID_4 { get; set; } = string.Empty;
        public string BOMID_5 { get; set; } = string.Empty;
        public string BOMID_6 { get; set; } = string.Empty;
        public string BOMID_7 { get; set; } = string.Empty;
        public string BOMID_8 { get; set; } = string.Empty;
        public string BOMID_9 { get; set; } = string.Empty;
        public double CONSUMPTION { get; set; }
        public string ECL_REMARKS { get; set; } = string.Empty;
        public string EXPORTREASON { get; set; } = string.Empty;
        public double FITEMCOST_8 { get; set; }
        public double FORECAST_FACTORY { get; set; }
        public double ITEMCOST_1 { get; set; }
        public double ITEMCOST_10 { get; set; }
        public double ITEMCOST_2 { get; set; }
        public double ITEMCOST_3 { get; set; }
        public double ITEMCOST_4 { get; set; }
        public double ITEMCOST_5 { get; set; }
        public double ITEMCOST_6 { get; set; }
        public double ITEMCOST_7 { get; set; }
        public double ITEMCOST_8 { get; set; }
        public double ITEMCOST_9 { get; set; }
        public string PACKINGGROUPID_1 { get; set; } = string.Empty;
        public string PACKINGGROUPID_2 { get; set; } = string.Empty;
        public string PACKINGGROUPID_3 { get; set; } = string.Empty;
        public string PACKINGGROUPID_4 { get; set; } = string.Empty;
        public string PACKINGGROUPID_5 { get; set; } = string.Empty;
        public int QUOTATION_TYPE { get; set; }
        public string RAWMATGROUPID_1 { get; set; } = string.Empty;
        public string RAWMATGROUPID_2 { get; set; } = string.Empty;
        public string RAWMATGROUPID_3 { get; set; } = string.Empty;
        public string RAWMATGROUPID_4 { get; set; } = string.Empty;
        public string RAWMATGROUPID_5 { get; set; } = string.Empty;
        public DateTime RECEIPTDATEREQUESTED { get; set; }
        public double SALESITEMDISC_1 { get; set; }
        public double SALESITEMDISC_10 { get; set; }
        public double SALESITEMDISC_2 { get; set; }
        public double SALESITEMDISC_3 { get; set; }
        public double SALESITEMDISC_4 { get; set; }
        public double SALESITEMDISC_5 { get; set; }
        public double SALESITEMDISC_6 { get; set; }
        public double SALESITEMDISC_7 { get; set; }
        public double SALESITEMDISC_8 { get; set; }
        public double SALESITEMDISC_9 { get; set; }
        public string SALESITEMID_1 { get; set; } = string.Empty;
        public string SALESITEMID_10 { get; set; } = string.Empty;
        public string SALESITEMID_2 { get; set; } = string.Empty;
        public string SALESITEMID_3 { get; set; } = string.Empty;
        public string SALESITEMID_4 { get; set; } = string.Empty;
        public string SALESITEMID_5 { get; set; } = string.Empty;
        public string SALESITEMID_6 { get; set; } = string.Empty;
        public string SALESITEMID_7 { get; set; } = string.Empty;
        public string SALESITEMID_8 { get; set; } = string.Empty;
        public string SALESITEMID_9 { get; set; } = string.Empty;
        public string SALESITEMNAME_1 { get; set; } = string.Empty;
        public string SALESITEMNAME_10 { get; set; } = string.Empty;
        public string SALESITEMNAME_2 { get; set; } = string.Empty;
        public string SALESITEMNAME_3 { get; set; } = string.Empty;
        public string SALESITEMNAME_4 { get; set; } = string.Empty;
        public string SALESITEMNAME_5 { get; set; } = string.Empty;
        public string SALESITEMNAME_6 { get; set; } = string.Empty;
        public string SALESITEMNAME_7 { get; set; } = string.Empty;
        public string SALESITEMNAME_8 { get; set; } = string.Empty;
        public string SALESITEMNAME_9 { get; set; } = string.Empty;
        public double SALESPRICE_1 { get; set; }
        public double SALESPRICE_10 { get; set; }
        public double SALESPRICE_2 { get; set; }
        public double SALESPRICE_3 { get; set; }
        public double SALESPRICE_4 { get; set; }
        public double SALESPRICE_5 { get; set; }
        public double SALESPRICE_6 { get; set; }
        public double SALESPRICE_7 { get; set; }
        public double SALESPRICE_8 { get; set; }
        public double SALESPRICE_9 { get; set; }
        public double SALESQTY_1 { get; set; }
        public double SALESQTY_10 { get; set; }
        public double SALESQTY_2 { get; set; }
        public double SALESQTY_3 { get; set; }
        public double SALESQTY_4 { get; set; }
        public double SALESQTY_5 { get; set; }
        public double SALESQTY_6 { get; set; }
        public double SALESQTY_7 { get; set; }
        public double SALESQTY_8 { get; set; }
        public double SALESQTY_9 { get; set; }
        public string SALESUNIT { get; set; } = string.Empty;
        public string SALESUNIT_1 { get; set; } = string.Empty;
        public string SALESUNIT_10 { get; set; } = string.Empty;
        public string SALESUNIT_2 { get; set; } = string.Empty;
        public string SALESUNIT_3 { get; set; } = string.Empty;
        public string SALESUNIT_4 { get; set; } = string.Empty;
        public string SALESUNIT_5 { get; set; } = string.Empty;
        public string SALESUNIT_6 { get; set; } = string.Empty;
        public string SALESUNIT_7 { get; set; } = string.Empty;
        public string SALESUNIT_8 { get; set; } = string.Empty;
        public string SALESUNIT_9 { get; set; } = string.Empty;
        public int TRANSPORTATION_TYPE { get; set; }
        public string UNIT { get; set; } = string.Empty;
        public DateTime MODIFIEDDATETIME { get; set; }
        public string MODIFIEDBY { get; set; } = string.Empty;
        public DateTime CREATEDDATETIME { get; set; }
        public string CREATEDBY { get; set; } = string.Empty;
        public decimal SPECIALDISC { get; set; }
        public string TAXITEMGROUP { get; set; } = string.Empty;
        public string REFPURCHID_1 { get; set; } = string.Empty;
        public string REFPURCHID_2 { get; set; } = string.Empty;
        public string REFPURCHID_3 { get; set; } = string.Empty;
        public string REFPURCHID_4 { get; set; } = string.Empty;
        public string REFPURCHID_5 { get; set; } = string.Empty;
    }
}
