using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class Cust_Table
    {
        [Key]
        public string ACCOUNTNUM { get; set; } = string.Empty;
        public string INVOICEACCOUNT { get; set; } = string.Empty;
        public string CUSTGROUP { get; set; } = string.Empty;
        public string LINEDISC { get; set; } = string.Empty;
        public string PAYMTERMID { get; set; } = string.Empty;
        public string CASHDISC { get; set; } = string.Empty;
        public string CURRENCY { get; set; } = string.Empty;
        public int INTERCOMPANYAUTOCREATEORDERS { get; set; }
        public string SALESGROUP { get; set; } = string.Empty;
        public int BLOCKED { get; set; }
        public int ONETIMECUSTOMER { get; set; }
        public int ACCOUNTSTATEMENT { get; set; }
        public decimal CREDITMAX { get; set; }
        public int MANDATORYCREDITLIMIT { get; set; }
        public string VENDACCOUNT { get; set; } = string.Empty;
        public string PRICEGROUP { get; set; } = string.Empty;
        public string MULTILINEDISC { get; set; } = string.Empty;
        public string ENDDISC { get; set; } = string.Empty;
        public string VATNUM { get; set; } = string.Empty;
        public string INVENTLOCATION { get; set; } = string.Empty;
        public string DLVTERM { get; set; } = string.Empty;
        public string DLVMODE { get; set; } = string.Empty;
        public string MARKUPGROUP { get; set; } = string.Empty;
        public string CLEARINGPERIOD { get; set; } = string.Empty;
        public string FREIGHTZONE { get; set; } = string.Empty;
        public string CREDITRATING { get; set; } = string.Empty;
        public string TAXGROUP { get; set; } = string.Empty;
        public string STATISTICSGROUP { get; set; } = string.Empty;
        public string PAYMMODE { get; set; } = string.Empty;
        public string COMMISSIONGROUP { get; set; } = string.Empty;
        public string BANKACCOUNT { get; set; } = string.Empty;
        public string PAYMSCHED { get; set; } = string.Empty;
        public string CONTACTPERSONID { get; set; } = string.Empty;
        public int INVOICEADDRESS { get; set; }
        public string OURACCOUNTNUM { get; set; } = string.Empty;
        public string SALESPOOLID { get; set; } = string.Empty;
        public int INCLTAX { get; set; }
        public string CUSTITEMGROUPID { get; set; } = string.Empty;
        public string NUMBERSEQUENCEGROUP { get; set; } = string.Empty;
        public string PAYMDAYID { get; set; } = string.Empty;
        public string LINEOFBUSINESSID { get; set; } = string.Empty;
        public string DESTINATIONCODEID { get; set; } = string.Empty;
        public int GIROTYPE { get; set; }
        public string SUPPITEMGROUPID { get; set; } = string.Empty;
        public int GIROTYPEINTERESTNOTE { get; set; }
        public string TAXLICENSENUM { get; set; } = string.Empty;
        public int WEBSALESORDERDISPLAY { get; set; }
        public string PAYMSPEC { get; set; } = string.Empty;
        public string BANKCENTRALBANKPURPOSETEXT { get; set; } = string.Empty;
        public string BANKCENTRALBANKPURPOSECODE { get; set; } = string.Empty;
        public int INTERCOMPANYALLOWINDIRECTCREATION { get; set; }
        public string PACKMATERIALFEELICENSENUM { get; set; } = string.Empty;
        public string TAXBORDERNUMBER_FI { get; set; } = string.Empty;
        public string EINVOICEEANNUM { get; set; } = string.Empty;
        public string FISCALCODE { get; set; } = string.Empty;
        public string DLVREASON { get; set; } = string.Empty;
        public int FORECASTDMPINCLUDE { get; set; }
        public int GIROTYPECOLLECTIONLETTER { get; set; }
        public string SALESCALENDARID { get; set; } = string.Empty;
        public string CUSTCLASSIFICATIONID { get; set; } = string.Empty;
        public int INTERCOMPANYDIRECTDELIVERY { get; set; }
        public string ENTERPRISENUMBER { get; set; } = string.Empty;
        public string SHIPCARRIERACCOUNT { get; set; } = string.Empty;
        public int GIROTYPEPROJINVOICE { get; set; }
        public string INVENTSITEID { get; set; } = string.Empty;
        public string ORDERENTRYDEADLINEGROUPID { get; set; } = string.Empty;
        public string SHIPCARRIERID { get; set; } = string.Empty;
        public int SHIPCARRIERFUELSURCHARGE { get; set; }
        public int SHIPCARRIERBLINDSHIPMENT { get; set; }
        public string SHIPCARRIERACCOUNTCODE { get; set; } = string.Empty;
        public int GIROTYPEFREETEXTINVOICE { get; set; }
        public byte SYNCENTITYID { get; set; }
        public Int64 SYNCVERSION { get; set; }
        public string MEMO { get; set; } = string.Empty;
        public string SALESDISTRICTID { get; set; } = string.Empty;
        public string SEGMENTID { get; set; } = string.Empty;
        public string SUBSEGMENTID { get; set; } = string.Empty;
        public int RFIDITEMTAGGING { get; set; }
        public int RFIDCASETAGGING { get; set; }
        public int RFIDPALLETTAGGING { get; set; }
        public string COMPANYCHAINID { get; set; } = string.Empty;
        public string COMPANYIDSIRET { get; set; } = string.Empty;
        public Int64 PARTY { get; set; }
        public string IDENTIFICATIONNUMBER { get; set; } = string.Empty;
        public string PARTYCOUNTRY { get; set; } = string.Empty;
        public string PARTYSTATE { get; set; } = string.Empty;
        public string ORGID { get; set; } = string.Empty;
        public string PAYMIDTYPE { get; set; } = string.Empty;
        public string FACTORINGACCOUNT { get; set; } = string.Empty;
        public Int64 DEFAULTDIMENSION { get; set; }
        public int CUSTEXCLUDECOLLECTIONFEE { get; set; }
        public int CUSTEXCLUDEINTERESTCHARGES { get; set; }
        public Int64 COMPANYNAFCODE { get; set; }
        public Int64 BANKCUSTPAYMIDTABLE { get; set; }
        public int GIROTYPEACCOUNTSTATEMENT { get; set; }
        public Int64 MAINCONTACTWORKER { get; set; }
        public int CREDITCARDADDRESSVERIFICATION { get; set; }
        public int CREDITCARDCVC { get; set; }
        public int CREDITCARDADDRESSVERIFICATIONVOID { get; set; }
        public int CREDITCARDADDRESSVERIFICATIONLEVEL { get; set; }
        public int COMPANYTYPE_MX { get; set; }
        public string RFC_MX { get; set; } = string.Empty;
        public string CURP_MX { get; set; } = string.Empty;
        public string STATEINSCRIPTION_MX { get; set; } = string.Empty;
        public string RESIDENCEFOREIGNCOUNTRYREGIONID_IT { get; set; } = string.Empty;
        public string BIRTHCOUNTYCODE_IT { get; set; } = string.Empty;
        public DateTime BIRTHDATE_IT { get; set; }
        public string BIRTHPLACE_IT { get; set; } = string.Empty;
        public int EINVOICE { get; set; }
        public string CCMNUM_BR { get; set; } = string.Empty;
        public string CNPJCPFNUM_BR { get; set; } = string.Empty;
        public string PBACUSTGROUPID { get; set; } = string.Empty;
        public string IENUM_BR { get; set; } = string.Empty;
        public string SUFRAMANUMBER_BR { get; set; } = string.Empty;
        public int SUFRAMA_BR { get; set; }
        public int CUSTFINALUSER_BR { get; set; }
        public string INTERESTCODE_BR { get; set; } = string.Empty;
        public string FINECODE_BR { get; set; } = string.Empty;
        public int SUFRAMAPISCOFINS_BR { get; set; }
        public int TAXWITHHOLDCALCULATE_TH { get; set; }
        public string TAXWITHHOLDGROUP_TH { get; set; } = string.Empty;
        public int CONSDAY_JP { get; set; }
        public string NIT_BR { get; set; } = string.Empty;
        public string INSSCEI_BR { get; set; } = string.Empty;
        public string CNAE_BR { get; set; } = string.Empty;
        public int ICMSCONTRIBUTOR_BR { get; set; }
        public int SERVICECODEONDLVADDRESS_BR { get; set; }
        public int INVENTPROFILETYPE_RU { get; set; }
        public string INVENTPROFILEID_RU { get; set; } = string.Empty;
        public int TAXWITHHOLDCALCULATE_IN { get; set; }
        public int UNITEDVATINVOICE_LT { get; set; }
        public string ENTERPRISECODE { get; set; } = string.Empty;
        public string COMMERCIALREGISTERSECTION { get; set; } = string.Empty;
        public string COMMERCIALREGISTERINSETNUMBER { get; set; } = string.Empty;
        public string COMMERCIALREGISTER { get; set; } = string.Empty;
        public string REGNUM_W { get; set; } = string.Empty;
        public int ISRESIDENT_LV { get; set; }
        public string INTBANK_LV { get; set; } = string.Empty;
        public string PAYMENTREFERENCE_EE { get; set; } = string.Empty;
        public int PACKAGEDEPOSITEXCEMPT_PL { get; set; }
        public int FEDNONFEDINDICATOR { get; set; }
        public int IRS1099CINDICATOR { get; set; }
        public string AGENCYLOCATIONCODE { get; set; } = string.Empty ;
        public string FEDERALCOMMENTS { get; set; } = string.Empty ;
        public int USEPURCHREQUEST { get; set; }
        public string MCRMERGEDPARENT { get; set; } = string.Empty;
        public string MCRMERGEDROOT { get; set; } = string.Empty;
        public int AFFILIATED_RU { get; set; }
        public int CASHDISCBASEDAYS { get; set; }
        public Int64 CUSTTRADINGPARTNERCODE { get; set; }
        public int CUSTWHTCONTRIBUTIONTYPE_BR { get; set; }
        public decimal DAXINTEGRATIONID { get; set; }
        public Int64 DEFAULTDIRECTDEBITMANDATE { get; set; }
        public string DEFAULTINVENTSTATUSID { get; set; } = string.Empty;
        public int ENTRYCERTIFICATEREQUIRED_W { get; set; }
        public int EXPORTSALES_PL { get; set; }
        public int EXPRESSBILLOFLADING { get; set; }
        public int FISCALDOCTYPE_PL { get; set; }
        public int FOREIGNRESIDENT_RU { get; set; }
        public int GENERATEINCOMINGFISCALDOCUMENT_BR { get; set; }
        public int INVOICEPOSTINGTYPE_RU { get; set; }
        public int ISSUEOWNENTRYCERTIFICATE_W { get; set; }
        public string ISSUERCOUNTRY_HU { get; set; } = string.Empty;
        public Int64 LVPAYMTRANSCODES { get; set; }
        public int MANDATORYVATDATE_PL { get; set; }
        public string PASSPORTNO_HU { get; set; } = string.Empty;
        public string PDSCUSTREBATEGROUPID { get; set; } = string.Empty;
        public int PDSFREIGHTACCRUED { get; set; }
        public string PDSREBATETMAGROUP { get; set; } = string.Empty;
        public string TAXPERIODPAYMENTCODE_PL { get; set; } = string.Empty;
        public int USECASHDISC { get; set; }
        public DateTime MODIFIEDDATETIME { get; set; }
        public int DEL_MODIFIEDTIME { get; set; }
        public string MODIFIEDBY { get; set; } = string.Empty;
        public DateTime CREATEDDATETIME { get; set; }
        public int DEL_CREATEDTIME { get; set; }
        public string DATAAREAID { get; set; } = string.Empty;
        public int RECVERSION { get; set; }
        public Int64 PARTITION { get; set; }
        public Int64 RECID { get; set; }
        public int EINVOICEREGISTER_IT { get; set; }
        public string FOREIGNERID_BR { get; set; } = string.Empty;
        public string ECL_TAXWITHHOLDGROUP { get; set; } = string.Empty;
        public int ECL_TAXWITHHOLDCALCULATE { get; set; }
        public string ECL_VATBRANCHID { get; set; } = string.Empty;
        public string ECL_FEDERALTAXID { get; set; } = string.Empty;
        public string AUTHORITYOFFICE_IT { get; set; } = string.Empty;
        public string FOREIGNTAXREGISTRATION_MX { get; set; } = string.Empty;
        public int PRESENCETYPE_BR { get; set; }
        public Int64 TAXGSTRELIEFGROUPHEADING_MY { get; set; }
        public string ECL_PORTOFLOADID { get; set; } = string.Empty;
        public string ECL_REMITTEDTO { get; set; } = string.Empty;
        public string ECL_SHIPPEDPER { get; set; } = string.Empty;
        public string ECL_PERSONALID { get; set; } = string.Empty;
        public string ECL_CUSTVATBRANCHID { get; set; } = string.Empty;
        public string ECL_COUNTRYOFORIID { get; set; } = string.Empty;
        public string ECL_PORTOFDESID { get; set; } = string.Empty;
        public string TLA_APPROVER_ID { get; set; } = string.Empty;
        public decimal TLA_CREDITMAX { get; set; }
        public Int64 WORKERSALESTAKER { get; set; }
        public string TLA_CONDITION_DELIVERY { get; set; } = string.Empty;
        public DateTime TEMPCREDITMAXDATE { get; set; }
    }
}
