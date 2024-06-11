//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Security.Cryptography.Xml;
//using System.Transactions;
//using System;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class Sales_Quotation_Table
    {
              [Key]
              public string QUOTATIONID { get; set; } = string.Empty;
              public string QUOTATIONNAME { get; set; }  = string.Empty;
              public DateTime QUOTATIONEXPIRYDATE { get; set; }
              public int QUOTATIONTYPE { get; set; }
              public string ORIGQUOTATIONID { get; set; } = string.Empty;
        public DateTime CONFIRMDATE { get; set; }
              public int QUOTATIONSTATUS { get; set; }
              public string QUOTATIONCATEGORY { get; set; } = string.Empty;
              public string DELIVERYNAME { get; set; } = string.Empty;
              public string DLVMODE { get; set; } = string.Empty;
              public string DLVTERM { get; set; } = string.Empty;
              public string SALESGROUP { get; set; } = string.Empty;
                public string SALESUNITID { get; set; } =string.Empty;
                public string SALESPOOLID { get; set; } =string.Empty;
                public string COMMISSIONGROUP { get; set; } =string.Empty;
                public string MARKUPGROUP { get; set; } =string.Empty;
                public string CURRENCYCODE { get; set; } =string.Empty;
                public string TAXGROUP { get; set; } =string.Empty;
                public string VATNUM { get; set; } =string.Empty;
                public int INCLTAX { get; set; }
                public string LINEDISC { get; set; } = string.Empty;
                public string MULTILINEDISC { get; set; } = string.Empty;
                public string ENDDISC { get; set; } = string.Empty;
                public double DISCPERCENT { get; set; }
                public string PAYMENT { get; set; } = string.Empty;
                public string PAYMMODE { get; set; } = string.Empty;
                public string PAYMSPEC { get; set; } = string.Empty;
                public string INVENTSITEID { get; set; } = string.Empty;
                public string CASHDISC { get; set; } = string.Empty;
                public int LISTCODE { get; set; }
                public int FREIGHTSLIPTYPE { get; set; }
                public string FREIGHTZONE { get; set; } = string.Empty;
                public string INVENTLOCATIONID { get; set; } = string.Empty;
                public string CUSTACCOUNT { get; set; } = string.Empty;
                public string BUSRELACCOUNT { get; set; } = string.Empty;
                public DateTime RECEIPTDATEREQUESTED { get; set; }
                public string POSTINGPROFILE { get; set; } = string.Empty;
                public string CUSTOMERREF { get; set; } = string.Empty;
                public string CONTACTPERSONID { get; set; } = string.Empty;
                public string EMAIL { get; set; } = string.Empty;
                public string URL { get; set; } = string.Empty;
                public string NUMBERSEQUENCEGROUP { get; set; } = string.Empty;
                public string LANGUAGEID { get; set; } = string.Empty;
                public Int64 DEFAULTDIMENSION { get; set; }
                public int DELIVERYDATECONTROLTYPE { get; set; }
                public string REASONID { get; set; } = string.Empty;
                public string SALESIDREF { get; set; } = string.Empty;
                public string PROJIDREF { get; set; } = string.Empty;
                public string SERVICEID { get; set; } = string.Empty;
                public string CAMPAIGNID { get; set; } = string.Empty;
                public string CALLLISTID { get; set; } = string.Empty;
                public string DOCUINTRO { get; set; } = string.Empty;
                public string DOCUCONCLUSION { get; set; } = string.Empty;
                public string DOCUTITLE { get; set; } = string.Empty;
                public string CUSTPURCHASEORDER { get; set; } = string.Empty;
                public string SALESORIGINID { get; set; } = string.Empty;
                public DateTime QUOTATIONFOLLOWUPDATE { get; set; }
                public string QUOTATIONFOLLOWUPACTIVITY { get; set; } = string.Empty;
                public int TOUCHED { get; set; }
                public int ADDRESSREFTABLEID { get; set; }
                public string INVOICEACCOUNT { get; set; } = string.Empty;
                public double FIXEDEXCHRATE { get; set; }
                public string TRANSACTIONCODE { get; set; } = string.Empty;
                public string TRANSPORT { get; set; } = string.Empty;
                public string PORT { get; set; } = string.Empty;
                public string STATPROCID { get; set; } = string.Empty;
                public int SETTLEVOUCHER { get; set; }
                public int COVSTATUS { get; set; }
                public DateTime FIXEDDUEDATE { get; set; }
                public double ESTIMATE { get; set; }
                public string PRICEGROUPID { get; set; } = string.Empty;
                public string TEMPLATEGROUPID { get; set; } = string.Empty;
                public string TEMPLATENAME { get; set; } = string.Empty;
                public int TEMPLATEACTIVE { get; set; }
                public string PROJINVOICEPROJID { get; set; } = string.Empty;
                public string MODELID { get; set; } = string.Empty;
                public int TRANSFERREDTOFORECAST { get; set; }
                public Int64 ADDRESSREFRECID { get; set; }
                public DateTime SHIPPINGDATEREQUESTED { get; set; }
                public int ITEMTAGGING { get; set; }
                public string EXPORTREASON { get; set; } = string.Empty;
                public string DLVREASON { get; set; } = string.Empty;
                public string ENTERPRISENUMBER { get; set; } = string.Empty;
                public int CASETAGGING { get; set; }
                public int PALLETTAGGING { get; set; }
                public double CASHDISCPERCENT { get; set; }
                public string OPPORTUNITYID { get; set; } = string.Empty;
                public int TRANSFERREDTOITEMREQ { get; set; }
                public int SYSTEMENTRYSOURCE { get; set; }
                public Int64 SYSTEMENTRYCHANGEPOLICY { get; set; }
                public Int64 MANUALENTRYCHANGEPOLICY { get; set; }
                public string COUNTYORIGDEST { get; set; } = string.Empty;
                public Int64 DELIVERYPOSTALADDRESS { get; set; }
                public Int64 WORKERSALESTAKER { get; set; }
                public int BANKDOCUMENTTYPE { get; set; }
                public string INTERESTCODE_BR { get; set; } = string.Empty;
                public string FINECODE_BR { get; set; } = string.Empty;
                public int CUSTFINALUSER_BR { get; set; }
                public int PSAWIZARDNOTOK { get; set; }
                public string CRMSTATUS { get; set; } = string.Empty;
                public byte DAXINTEGRATIONID { get; set; }
                public double PSAESTDPROJDURATION { get; set; }
                public DateTime PSAESTPROJENDDATE { get; set; }
                public DateTime PSAESTPROJSTARTDATE { get; set; }
                public string PSAEXTERNALDESCRIPTION { get; set; } = string.Empty ;
                public string PSAINTERNALDESCRIPTION { get; set; } = string.Empty ;
                public string PSASCHEDCALENDARID { get; set; } = string.Empty ;
                public Int64 SALESPURCHOPERATIONTYPE_BR { get; set; }
                public Int64 WORKERSALESRESPONSIBLE { get; set; }
                public DateTime MODIFIEDDATETIME { get; set; }
                public DateTime CREATEDDATETIME { get; set; }
                public string DATAAREAID { get; set; } = string.Empty;
                public int RECVERSION { get; set; }
                public Int64 PARTITION { get; set; }
                public Int64 RECID { get; set; }
                public string ECL_REMARKS{ get; set; } = string.Empty;
                public int TLA_APPROVE { get; set; }
                public string TLA_APPROVER { get; set; } = string.Empty;
                public int TLA_CHECKBOX { get; set; }
                public string ETP_APPROVER_ID { get; set; } = string.Empty;
    }
}
