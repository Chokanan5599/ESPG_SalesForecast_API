//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System;
using System.ComponentModel.DataAnnotations;
namespace ESPG_SalesForecast_API.Model
{
    public class Sales_Table
    {
        [Key]
        public string SALESID { get; set; } = string.Empty;
        public string SALESNAME { get; set; } = string.Empty;
        public int RESERVATION { get; set; }
        public string CUSTACCOUNT { get; set; } = string.Empty;
        public string INVOICEACCOUNT { get; set; } = string.Empty;
        public DateTime DELIVERYDATE { get; set; }
        public string URL { get; set; } = string.Empty;
        public string PURCHORDERFORMNUM { get; set; } = string.Empty;
        public string SALESGROUP { get; set; } = string.Empty;
        public int FREIGHTSLIPTYPE { get; set; }
        public int DOCUMENTSTATUS { get; set; }
        public string INTERCOMPANYORIGINALSALESID { get; set; } = string.Empty;
        public string CURRENCYCODE { get; set; } = string.Empty;
        public string PAYMENT { get; set; } = string.Empty;
        public string CASHDISC { get; set; } = string.Empty;
        public string TAXGROUP { get; set; } = string.Empty;
        public string LINEDISC { get; set; } = string.Empty;
        public string CUSTGROUP { get; set; } = string.Empty;
        public double DISCPERCENT { get; set; }
        public string INTERCOMPANYORIGINALCUSTACCOUNT { get; set; } = string.Empty;
        public string PRICEGROUPID { get; set; } = string.Empty;
        public string MULTILINEDISC { get; set; } = string.Empty;
        public string ENDDISC { get; set; } = string.Empty;
        public string CUSTOMERREF { get; set; } = string.Empty;
        public string COUNTYORIGDEST { get; set; } = string.Empty;
        public int LISTCODE { get; set; }
        public string DLVTERM { get; set; } = string.Empty;
        public string DLVMODE { get; set; } = string.Empty;
        public string PURCHID { get; set; } = string.Empty;
        public int SALESSTATUS { get; set; }
        public string MARKUPGROUP { get; set; } = string.Empty;
        public int SALESTYPE { get; set; }
        public string SALESPOOLID { get; set; } = string.Empty;
        public string POSTINGPROFILE { get; set; } = string.Empty;
        public string TRANSACTIONCODE { get; set; } = string.Empty;
        public int INTERCOMPANYAUTOCREATEORDERS { get; set; } 
        public int INTERCOMPANYDIRECTDELIVERY { get; set; } 
        public int INTERCOMPANYDIRECTDELIVERYORIG { get; set; } 
        public int SETTLEVOUCHER { get; set; } 
        public string ENTERPRISENUMBER { get; set; } = string.Empty;
        public int INTERCOMPANYALLOWINDIRECTCREATION { get; set; } 
        public int INTERCOMPANYALLOWINDIRECTCREATIONORIG { get; set; } 
        public string DELIVERYNAME { get; set; } = string.Empty;
        public int ONETIMECUSTOMER { get; set; } 
        public int COVSTATUS { get; set; } 
        public string COMMISSIONGROUP { get; set; } = string.Empty;
        public string PAYMENTSCHED { get; set; } = string.Empty;
        public int INTERCOMPANYORIGIN { get; set; } 
        public string EMAIL { get; set; } = string.Empty;
        public string FREIGHTZONE { get; set; } = string.Empty;
        public string RETURNITEMNUM { get; set; } = string.Empty;
        public double CASHDISCPERCENT { get; set; }
        public string CONTACTPERSONID { get; set; } = string.Empty;
        public DateTime DEADLINE { get; set; }
        public string PROJID { get; set; } = string.Empty;
        public string INVENTLOCATIONID { get; set; } = string.Empty;
        public int ADDRESSREFTABLEID { get; set; }
        public string VATNUM { get; set; } = string.Empty;
        public string PORT { get; set; } = string.Empty;
        public int INCLTAX { get; set; }
        public int EINVOICELINESPEC { get; set; }
        public string NUMBERSEQUENCEGROUP { get; set; } = string.Empty;
        public double FIXEDEXCHRATE { get; set; }
        public string LANGUAGEID { get; set; } = string.Empty;
        public int AUTOSUMMARYMODULETYPE { get; set; }
        public int GIROTYPE { get; set; }
        public string SALESORIGINID { get; set; } = string.Empty;
        public double ESTIMATE { get; set; }
        public string TRANSPORT { get; set; } = string.Empty;
        public string PAYMMODE { get; set; } = string.Empty;
        public string PAYMSPEC { get; set; } = string.Empty;
        public DateTime FIXEDDUEDATE { get; set; }
        public string EXPORTREASON { get; set; } = string.Empty;
        public string STATPROCID { get; set; } = string.Empty;
        public string BANKCENTRALBANKPURPOSETEXT { get; set; } = string.Empty;
        public string INTERCOMPANYCOMPANYID { get; set; } = string.Empty;
        public string INTERCOMPANYPURCHID { get; set; } = string.Empty;
        public int INTERCOMPANYORDER { get; set; }
        public string DLVREASON { get; set; } = string.Empty;
        public string QUOTATIONID { get; set; } = string.Empty;
        public DateTime RECEIPTDATEREQUESTED { get; set; }
        public DateTime RECEIPTDATECONFIRMED { get; set; }
        public DateTime SHIPPINGDATEREQUESTED { get; set; }
        public DateTime SHIPPINGDATECONFIRMED { get; set; }
        public string BANKCENTRALBANKPURPOSECODE { get; set; } = string.Empty;
        public string EINVOICEACCOUNTCODE { get; set; } = string.Empty;
        public int ITEMTAGGING { get; set; }
        public int CASETAGGING { get; set; }
        public int PALLETTAGGING { get; set; }
        public Int64 ADDRESSREFRECID { get; set; }
        public string CUSTINVOICEID { get; set; } = string.Empty;
        public string INVENTSITEID { get; set; } = string.Empty;
        public Int64 DEFAULTDIMENSION { get; set; }
        public Int64 CREDITCARDCUSTREFID { get; set; }
        public string SHIPCARRIERACCOUNT { get; set; } = string.Empty;
        public string SHIPCARRIERID { get; set; } = string.Empty;
        public int SHIPCARRIERFUELSURCHARGE { get; set; }
        public int SHIPCARRIERBLINDSHIPMENT { get; set; }
        public string SHIPCARRIERDELIVERYCONTACT { get; set; } = string.Empty;
        public double CREDITCARDAPPROVALAMOUNT { get; set; }
        public string CREDITCARDAUTHORIZATION { get; set; } = string.Empty;
        public DateTime RETURNDEADLINE { get; set; }
        public string RETURNREPLACEMENTID { get; set; } = string.Empty;
        public int RETURNSTATUS { get; set; }
        public string RETURNREASONCODEID { get; set; } = string.Empty;
        public int CREDITCARDAUTHORIZATIONERROR { get; set; }
        public string SHIPCARRIERACCOUNTCODE { get; set; } = string.Empty;
        public int RETURNREPLACEMENTCREATED { get; set; }
        public int SHIPCARRIERDLVTYPE { get; set; }
        public int DELIVERYDATECONTROLTYPE { get; set; }
        public int SHIPCARRIEREXPEDITEDSHIPMENT { get; set; }
        public int SHIPCARRIERRESIDENTIAL { get; set; }
        public Int64 MATCHINGAGREEMENT { get; set; }
        public int SYSTEMENTRYSOURCE { get; set; }
        public Int64 SYSTEMENTRYCHANGEPOLICY { get; set; }
        public Int64 MANUALENTRYCHANGEPOLICY { get; set; }
        public Int64 DELIVERYPOSTALADDRESS { get; set; }
        public Int64 SHIPCARRIERPOSTALADDRESS { get; set; }
        public string SHIPCARRIERNAME { get; set; } = string.Empty;
        public Int64 WORKERSALESTAKER { get; set; }
        public Int64 SOURCEDOCUMENTHEADER { get; set; }
        public int BANKDOCUMENTTYPE { get; set; }
        public string SALESUNITID { get; set; } = string.Empty;
        public double SMMSALESAMOUNTTOTAL { get; set; }
        public string SMMCAMPAIGNID { get; set; } = string.Empty;
        public int CUSTOMSEXPORTORDER_IN { get; set; }
        public int CUSTOMSSHIPPINGBILL_IN { get; set; }
        public string TDSGROUP_IN { get; set; } = string.Empty;
        public string TCSGROUP_IN { get; set; } = string.Empty;
        public int NATUREOFASSESSEE_IN { get; set; }
        public int CONSTARGET_JP { get; set; }
        public DateTime INTRASTATFULFILLMENTDATE_HU { get; set; }
        public int UNITEDVATINVOICE_LT { get; set; }
        public double INTRASTATADDVALUE_LV { get; set; }
        public int INVOICEREGISTER_LT { get; set; }
        public int PACKINGSLIPREGISTER_LT { get; set; }
        public string BANKACCOUNT_LV { get; set; } = string.Empty;
        public DateTime CASHDISCBASEDATE { get; set; }
        public int CASHDISCBASEDAYS { get; set; }
        public Int64 CREDITNOTEREASONCODE { get; set; }
        public string CURBANKACCOUNT_LV { get; set; } = string.Empty;
        public string CUSTBANKACCOUNT_LV { get; set; } = string.Empty;
        public byte DAXINTEGRATIONID { get; set; }
        public Int64 DIRECTDEBITMANDATE { get; set; }
        public int FISCALDOCTYPE_PL { get; set; }
        public int MCRORDERSTOPPED { get; set; }
        public int PDSBATCHATTRIBAUTORES { get; set; }
        public string PDSCUSTREBATEGROUPID { get; set; } = string.Empty;
        public string PDSREBATEPROGRAMTMAGROUP { get; set; } = string.Empty;
        public int RELEASESTATUS { get; set; }
        public string TAXPERIODPAYMENTCODE_PL { get; set; } = string.Empty;
        public Int64 TRANSPORTATIONDOCUMENT { get; set; }
        public Int64 WORKERSALESRESPONSIBLE { get; set; }
        public DateTime MODIFIEDDATETIME { get; set; }
        public int DEL_MODIFIEDTIME { get; set; }
        public string MODIFIEDBY { get; set; } = string.Empty;
        public Int64 MODIFIEDTRANSACTIONID { get; set; }
        public DateTime CREATEDDATETIME { get; set; }
        public int DEL_CREATEDTIME { get; set; }
        public string CREATEDBY { get; set; } = string.Empty;
        public Int64 CREATEDTRANSACTIONID { get; set; }
        public string DATAAREAID { get; set; } = string.Empty;
        public int RECVERSION { get; set; }
        public Int64 PARTITION { get; set; }
        public Int64 RECID { get; set; }
        public string ECL_ALTNAME { get; set; } = string.Empty;
        public string ECL_ALTADDRESS { get; set; } = string.Empty;
        public string ECL_REFINVOICEID { get; set; } = string.Empty;
        public double ECL_WHTAXPERCENT { get; set; }
        public double ECL_WHTAXAMOUNT { get; set; }
        public string ECL_SALESREMARK { get; set; } = string.Empty;
        public string ECL_CUSTVATBRANCHID { get; set; } = string.Empty;
        public Int64 RETAILCHANNELTABLE { get; set; }
        public string ECL_WHTAXCODE { get; set; } = string.Empty;
        public string ECL_VATBRANCHID { get; set; } = string.Empty;
        public string ECL_REMITTEDTO { get; set; } = string.Empty;
        public string ECL_SHIPPEDPER { get; set; } = string.Empty;
        public string ECL_COUNTRYOFORIID { get; set; } = string.Empty;
        public string ECL_PORTOFDESID { get; set; } = string.Empty;
        public string ECL_PORTOFLOADID { get; set; } = string.Empty;
        public string ECL_EXPORTREMARK { get; set; } = string.Empty;
        public string ECL_PORTOFLOADDESCRIPTION { get; set; } = string.Empty;
        public string ECL_PORTOFDESDESCRIPTION { get; set; } = string.Empty;
        public string ECL_COUNTRYOFORIDESCRIPTION { get; set; } = string.Empty;
        public int ECL_PREPACKINGSLIPREQUIRED { get; set; }
        public int CHECKBOX_TOPLAN { get; set; }
        public string CONTRACTNUMBER { get; set; } = string.Empty;
        public int SENDMAIL { get; set; }
        public string ETP_MEMONUM { get; set; } = string.Empty;
        public string LOT_ITEM { get; set; } = string.Empty;
    }
}
