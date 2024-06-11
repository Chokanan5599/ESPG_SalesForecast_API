using ESPG_SalesForecast_API.Entity;
using ESPG_SalesForecast_API.Helpers;
using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Services_Businesslogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Azure.Core.HttpHeader;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ESPG_SalesForecast_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Sales_Forecast_DetailsController : ControllerBase
    {

        private readonly TAAX63TEST_DbContext _db;

        public Sales_Forecast_DetailsController(TAAX63TEST_DbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        //[Authorize]
        [Route("Sales_Forcast_List")]
        public async Task<IActionResult> Sales_Forcast_List(
            string salesRespon_recid,
            string user_Id,
            string _class,
            string company,
            string foreCast_user_Id,
            string month_Year
            )
        {
            List<Form_Sales_Forecast_List_Tb> list_data = new List<Form_Sales_Forecast_List_Tb>();
            List<Form_Fill> list_data_Form = new List<Form_Fill>();
            string dateForm = month_Year;//Parameter
            var myDate = Convert.ToDateTime(dateForm);
            var startOfMonth = new DateTime(myDate.Year, myDate.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            if (salesRespon_recid == "All") {
                if (_class == "Admin"){
                    var fill_Admin = (
                           from a in _db.DirpersonName

                           from a2 in _db.DirpersonName
                                   .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                               o.VALIDFROM == _db.DirpersonName
                                                   .Where(o => o.PERSON == a.PERSON)
                                                   .Select(o => o.VALIDFROM).Max())

                           join b in _db.HCMWORKER on a.PERSON equals b.PERSON
                           join c in _db.DirpersonUser on a.PERSON equals c.PERSONPARTY
                           join d in _db.ETP_Oc_Team on b.RECID equals d.EMPLOYEE

                           where d.ETP_TEAM != 0 && d.DATAAREA == company
                           select new
                           {
                               pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                               pERSON = a.PERSON,
                               name = a.FIRSTNAME,
                               user = c.USER_,
                               vALIDFROM = a.VALIDFROM
                           }).ToList();
                    foreach (var s in fill_Admin)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }
                }
                if (_class == "Director") {
                    var fill_Director = (
                            from a in _db.DirpersonName

                            from a2 in _db.DirpersonName
                                    .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                                o.VALIDFROM == _db.DirpersonName
                                                    .Where(o => o.PERSON == a.PERSON)
                                                    .Select(o => o.VALIDFROM).Max())

                            join b in _db.HCMWORKER on a.PERSON equals b.PERSON
                            join c in _db.DirpersonUser on a.PERSON equals c.PERSONPARTY
                            join d in _db.ETP_Oc_Team on b.RECID equals d.EMPLOYEE

                            where d.ETP_TEAM != 0 && d.DATAAREA == company
                            select new
                            {
                                pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                pERSON = a.PERSON,
                                name = a.FIRSTNAME,
                                user = c.USER_,
                                vALIDFROM = a.VALIDFROM
                            }).ToList();
                    foreach (var s in fill_Director)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }
                }
                if (_class == "Leader"){
                    var fill_Leader = (

                                         from a in _db.DirpersonName
                                         from a2 in _db.DirpersonName
                                             .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&

                                                         o.VALIDFROM == _db.DirpersonName
                                                             .Where(o => o.PERSON == a.PERSON)
                                                             .Select(o => o.VALIDFROM).Max())

                                         join b in _db.HCMWORKER on a.PERSON equals b.PERSON
                                         join c in _db.DirpersonUser on a.PERSON equals c.PERSONPARTY
                                         join d in _db.ETP_Oc_Team on b.RECID equals d.EMPLOYEE

                                         where d.ETP_TEAM != 0
                                         //&& d.DATAAREA == company
                                         select new
                                         {
                                             pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                             pERSON = a.PERSON,
                                             name = a.FIRSTNAME,
                                             user = c.USER_,
                                             vALIDFROM = a.VALIDFROM
                                         }).ToList();
                    var fill_Leader2 = (from br1 in _db.DirpersonUser
                                        join br2 in _db.HCMWORKER on br1.PERSONPARTY equals br2.PERSON

                                        join br3 in _db.ETP_Oc_Team on br2.RECID equals br3.MANAGER
                                        where br1.USER_ == foreCast_user_Id
                                        select new
                                        {
                                            emp_id = Convert.ToInt64(br3.EMPLOYEE)
                                        }).ToList();


                    int i;
                    for (i = 0; i < fill_Leader2.Count(); i++)
                    {
                        foreach (var s in fill_Leader)
                        {
                            Form_Fill a = new Form_Fill();
                            if (s.pRECID == fill_Leader2[i].emp_id)
                            {
                                a.RECID = s.pRECID;
                                a.salesName = s.name;
                                a.PERSON = s.pERSON;
                                a.user = s.user;
                                a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                                list_data_Form.Add(a);
                                break;
                            }
                        }
                    }

                }
                if (_class == "Officer") {
                    var fill_Officer = (from a in _db.DirpersonName
                                        from a2 in _db.DirpersonName
                                            .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                                        o.VALIDFROM == _db.DirpersonName
                                                            .Where(o => o.PERSON == a.PERSON)
                                                            .Select(o => o.VALIDFROM).Max())

                                        join b in _db.HCMWORKER on a.PERSON equals b.PERSON

                                        join c in _db.DirpersonUser on a.PERSON equals c.PERSONPARTY

                                        join d in _db.ETP_Oc_Team on b.RECID equals d.EMPLOYEE

                                        where
                                            b.PERSON == a.PERSON
                                                && a.PERSON == c.PERSONPARTY
                                                && d.EMPLOYEE == b.RECID
                                                && d.ETP_TEAM != 0
                                                && c.USER_ == foreCast_user_Id
                                                && d.DATAAREA == company
                                        select new
                                        {
                                            pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                            pERSON = a.PERSON,
                                            name = a.FIRSTNAME,
                                            user = c.USER_,
                                            vALIDFROM = a.VALIDFROM
                                        }).ToList();
                    foreach (var s in fill_Officer)
                    {
                        Form_Fill a = new Form_Fill();
                        a.RECID = s.pRECID;
                        a.salesName = s.name;
                        a.PERSON = s.pERSON;
                        a.user = s.user;
                        a.validfrom = Convert.ToDateTime(s.vALIDFROM);
                        list_data_Form.Add(a);
                    }

                }

                var sales_Forecast_List = (from ForecastH in _db.ETP_ImportSalesFileHistory
                                           from ForecastL in _db.ETP_ImportSalesHistory
                                           
                                         .Where(x => ForecastH.RECID == x.RECID && ForecastH.DATAAREAID == x.DATAAREAID).DefaultIfEmpty()
                                           from Custtable_L in _db.CUSTTABLE
                                           where
                                                //d.ETP_TEAM != 0 
                                                //&& d.DATAAREA == company
                                                ForecastH.DATAAREAID == company
                                               && ForecastH.TODATE >= startOfMonth
                                               && ForecastH.TODATE <= endOfMonth
                                               //&& ForecastL.WORKERSALESRESPONSIBLE.ToString().Contains(list_data_Form[i].RECID.ToString())
                                               && (ForecastH.STATUSIMPORTSALES == 1 || ForecastH.STATUSIMPORTSALES == 2 || ForecastH.STATUSIMPORTSALES == 4)
                                               && ForecastH.RECID == (from newForecastH in _db.ETP_ImportSalesFileHistory
                                                                          .OrderByDescending(O => O.CREATEDDATETIME)
                                                                      from newForecastL in _db.ETP_ImportSalesHistory
                                                                          .Where(y => newForecastH.RECID == y.FILEREFRECID && newForecastH.DATAAREAID == y.DATAAREAID).DefaultIfEmpty()
                                                                      where
                                                                             newForecastL.DATAAREAID == ForecastL.DATAAREAID &&
                                                                             newForecastL.QUOTATIONID == ForecastL.QUOTATIONID &&
                                                                             (newForecastH.STATUSIMPORTSALES == 1 || newForecastH.STATUSIMPORTSALES == 2 || newForecastH.STATUSIMPORTSALES == 4)
                                                                      select newForecastH.RECID).FirstOrDefault()
                                              && ForecastL.CUSTACCOUNT == Custtable_L.ACCOUNTNUM
                                              && ForecastL.DATAAREAID == Custtable_L.DATAAREAID
                                           select new
                                           {
                                               ForecastH.RECID,
                                               ForecastL.WORKERSALESRESPONSIBLE,
                                               ForecastH.ETP_APPROVER_ID,
                                               ForecastL.QUOTATIONID,
                                               ForecastH.STATUSIMPORTSALES,
                                               ForecastL.CUSTACCOUNT,
                                               ForecastL.CUSTNAME,
                                               ForecastL.SALE,
                                               ForecastL.ITEMID,
                                               ForecastL.QUOTATION_TYPE,
                                               ForecastL.BOMID,
                                               ForecastL.FORECAST,
                                               ForecastL.VERSION,

                                               //---> FROM COST MAGIM--------
                                               ForecastL.TRANSPORTATION_TYPE,
                                               ForecastL.EXPENSES_2,
                                               ForecastL.EXPENSES_5,
                                               ForecastL.EXPENSES_9,
                                               ForecastL.EXPENSES_10,
                                               ForecastL.EXPENSES_13,
                                               ForecastL.EXPENSES_14,
                                               ForecastL.EXPENSES_16,
                                               ForecastL.SPECIALDISC,
                                               //----------------------------
                                               ForecastL.EXPENSES_1,
                                               ForecastL.EXPENSES_18,
                                               ForecastL.EXPENSES_6,
                                               ForecastL.EXPENSES_7,
                                               ForecastL.EXPENSES_11,
                                               ForecastL.EXPENSES_12,
                                               ForecastL.EXPENSES_15,
                                               ForecastL.EXPENSESPERTON,
                                               ForecastL.REMARK2,
                                               //------------------------------
                                               ForecastL.PRICEPERTON,
                                               ForecastL.TAXITEMGROUP,
                                               ForecastL.TOTALSALES,
                                               ForecastL.COSTPERTON,
                                               ForecastL.TOTALCOSTSALES,
                                               ForecastL.MARGINTON,
                                               ForecastL.TOTALMARGIN,
                                               ForecastL.MARGINPERCEN,
                                               //---> FROM COST MAGIM--------

                                               //---> FROM OVER VIEW
                                               Custtable_L.CREDITMAX,





                                           }).ToList();


                //Query FullName Sales Team 
                var sales_Name_Forecast_List = (
                                              //from team_sales in new_sales_Responsible 
                                              from a in _db.DirpersonName
                                              from a2 in _db.DirpersonName
                                                  .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&
                                                              o.VALIDFROM == _db.DirpersonName
                                                                  .Where(o => o.PERSON == a.PERSON)
                                                                  .Select(o => o.VALIDFROM).Max())
                                              join b in _db.HCMWORKER on a.PERSON equals b.PERSON
                                              select new
                                              {
                                                  pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                                  pERSON = a.PERSON,
                                                  name = a.FIRSTNAME + "  " + a.LASTNAME,
                                                  vALIDFROM = a.VALIDFROM
                                              }).ToList();
                var new_sales_Name_Responsible = (
                                                      from all_sales_Forcast_List in sales_Forecast_List
                                                      from sales_name in sales_Name_Forecast_List
                                                      .Where(o => o.pRECID == all_sales_Forcast_List.WORKERSALESRESPONSIBLE)
                                                      select new
                                                      {
                                                          recID = all_sales_Forcast_List.RECID,
                                                          QuotationID = all_sales_Forcast_List.QUOTATIONID,
                                                          Workersalesresponsible = all_sales_Forcast_List.WORKERSALESRESPONSIBLE,
                                                          Addsign_To = all_sales_Forcast_List.ETP_APPROVER_ID,
                                                          Customer_Account = all_sales_Forcast_List.CUSTACCOUNT,
                                                          Customer_Name = all_sales_Forcast_List.CUSTNAME,
                                                          Item_Number = all_sales_Forcast_List.ITEMID,
                                                          Quotation_Type = all_sales_Forcast_List.QUOTATION_TYPE,
                                                          BomId = all_sales_Forcast_List.BOMID,
                                                          Forecast= all_sales_Forcast_List.FORECAST,
                                                          StatusimportSales = all_sales_Forcast_List.STATUSIMPORTSALES,
                                                          Version = all_sales_Forcast_List.VERSION,
                                                          SalesName = sales_name.name,

                                                          //---> FROM COST MAGIM--------
                                                          TransportaTion_Type = all_sales_Forcast_List.TRANSPORTATION_TYPE,
                                                          expenses_2 = all_sales_Forcast_List.EXPENSES_2,
                                                          expenses_5 = all_sales_Forcast_List.EXPENSES_5,
                                                          expenses_9 = all_sales_Forcast_List.EXPENSES_9,
                                                          expenses_10 = all_sales_Forcast_List.EXPENSES_10,
                                                          expenses_13 = all_sales_Forcast_List.EXPENSES_13,
                                                          expenses_14 = all_sales_Forcast_List.EXPENSES_14,
                                                          expenses_16 = all_sales_Forcast_List.EXPENSES_16,
                                                          specialdisc = all_sales_Forcast_List.SPECIALDISC,
                                                          //-------------------------------------------
                                                          expenses_1 = all_sales_Forcast_List.EXPENSES_1,
                                                          expenses_18 = all_sales_Forcast_List.EXPENSES_18,
                                                          expenses_6 = all_sales_Forcast_List.EXPENSES_6,
                                                          expenses_7 = all_sales_Forcast_List.EXPENSES_7,
                                                          expenses_11 = all_sales_Forcast_List.EXPENSES_11,
                                                          expenses_12 = all_sales_Forcast_List.EXPENSES_12,
                                                          expenses_15 = all_sales_Forcast_List.EXPENSES_15,
                                                          expenses_Perton = all_sales_Forcast_List.EXPENSESPERTON,
                                                          remark2 = all_sales_Forcast_List.REMARK2,
                                                          //-------------------------------------------
                                                          priceper_Ton = all_sales_Forcast_List.PRICEPERTON,
                                                          taxItem_Group = all_sales_Forcast_List.TAXITEMGROUP,
                                                          total_Sales = all_sales_Forcast_List.TOTALSALES,
                                                          costper_Ton = all_sales_Forcast_List.COSTPERTON,
                                                          total_Cost_Sales = all_sales_Forcast_List.TOTALCOSTSALES,
                                                          margin_Ton = all_sales_Forcast_List.MARGINTON,
                                                          total_Margin = all_sales_Forcast_List.TOTALMARGIN,
                                                          margin_Percen = all_sales_Forcast_List.MARGINPERCEN,
                                                          //---> FROM COST MAGIM--------

                                                          //---> FROM OVER VIEW--------
                                                          credit_limit = all_sales_Forcast_List.CREDITMAX,

                                                      }
                                                      ).ToList();
                    foreach (var s in new_sales_Name_Responsible)
                    {
                        Form_Sales_Forecast_List_Tb a = new Form_Sales_Forecast_List_Tb();

                    //a.Full_Name = s.SalesName.ToString();
                        a.recID = s.recID;
                        a.QuotationID = s.QuotationID.ToString();
                        a.WORKERSALESRESPONSIBLE = s.Workersalesresponsible.ToString();
                        
                        a.Assign_To = s.Addsign_To.ToString();
                        a.Customer_Account = s.Customer_Account.ToString();
                        a.Customer_Name = s.Customer_Name.ToString();
                        a.item_Number = s.Item_Number.ToString();
                        a.Formula_Version = s.BomId.ToString();
                        a.Quantity = s.Forecast;
                        a.Quantity_Type = s.Quotation_Type.ToString() == "0" ? "Forecast": "Quotation";
                        // -- 2 = create , 1 = inreview , 4 = reject
                        a.Status = s.StatusimportSales.ToString() == "1" ? "inreview" : s.StatusimportSales.ToString() == "2" ? "create" : s.StatusimportSales.ToString() == "4" ? "reject" : "-";
                        a.Version = s.Version;

                    //---> FROM COST MAGIM--------
                        a.TransportaTion_Type = s.TransportaTion_Type.ToString() == "0" ? "พ่วง" : s.TransportaTion_Type.ToString() == "1" ? "เดี่ยว" : s.TransportaTion_Type.ToString() == "2" ? "เทรลเลอร์ สั้น" : s.TransportaTion_Type.ToString() == "3" ? "เทรลเลอร์ ยาว" : s.TransportaTion_Type.ToString() == "4" ? "ปูนเต้า เดี่ยว" : s.TransportaTion_Type.ToString() == "5" ? "ปูนเต้า พ่วง" : "-";
                        a.expenses_2 = Math.Round(s.expenses_2,2);
                        a.expenses_5 = Math.Round(s.expenses_5,2);
                        a.expenses_9 = Math.Round(s.expenses_9,2);
                        a.expenses_10 = Math.Round(s.expenses_10,2);
                        a.expenses_13 = Math.Round(s.expenses_13,2);
                        a.expenses_14 = Math.Round(s.expenses_14,2);
                        a.expenses_16 = Math.Round(s.expenses_16,2);
                        a.specialdisc = Math.Round(s.specialdisc, 2);
                    //-------------------------------
                        a.expenses_1 = Math.Round(s.expenses_1, 2);
                        a.expenses_18 = Math.Round(s.expenses_18, 2);
                        a.expenses_6 = Math.Round(s.expenses_6, 2);
                        a.expenses_7 = Math.Round(s.expenses_7, 2);
                        a.expenses_11 = Math.Round(s.expenses_11, 2);
                        a.expenses_12 = Math.Round(s.expenses_12, 2);
                        a.expenses_15 = Math.Round(s.expenses_15, 2);
                        a.expenses_Perton = Math.Round(s.expenses_Perton, 2);
                        a.remark2 = s.remark2.ToString() != "" ? s.remark2.ToString() : " ";
                    //-------------------------------
                        a.priceper_Ton = Math.Round(s.priceper_Ton, 2);
                        a.taxItem_Group = s.taxItem_Group.ToString();
                        a.total_Sales = Math.Round(s.total_Sales, 2);
                        a.costper_Ton = Math.Round(s.costper_Ton, 2);
                        a.total_Cost_Sales = Math.Round(s.total_Cost_Sales, 2);
                        a.margin_Ton = Math.Round(s.margin_Ton, 2);
                        a.total_Margin = Math.Round(s.total_Margin, 2);
                        a.margin_Percen = Math.Round(s.margin_Percen, 2);
                        a.credit_limit = Math.Round(s.credit_limit, 2);
                    list_data.Add(a);
                    }
   


            }
            else {

                var sales_Forecast_List = (from ForecastH in _db.ETP_ImportSalesFileHistory
                                           from ForecastL in _db.ETP_ImportSalesHistory
                                           .Where(x => ForecastH.RECID == x.RECID && ForecastH.DATAAREAID == x.DATAAREAID).DefaultIfEmpty()
                                           from Custtable_L in _db.CUSTTABLE
                                           where
                                                //d.ETP_TEAM != 0 
                                                //&& d.DATAAREA == company
                                                ForecastH.DATAAREAID == company
                                               && ForecastH.TODATE >= startOfMonth
                                               && ForecastH.TODATE <= endOfMonth
                                               && ForecastL.WORKERSALESRESPONSIBLE.ToString().Contains(salesRespon_recid)
                                               && (ForecastH.STATUSIMPORTSALES == 1 || ForecastH.STATUSIMPORTSALES == 2 || ForecastH.STATUSIMPORTSALES == 4)
                                               && ForecastH.RECID == (from newForecastH in _db.ETP_ImportSalesFileHistory
                                               .OrderByDescending(O => O.CREATEDDATETIME)
                                                                      from newForecastL in _db.ETP_ImportSalesHistory
                                                                         .Where(y => newForecastH.RECID == y.FILEREFRECID && newForecastH.DATAAREAID == y.DATAAREAID).DefaultIfEmpty()
                                                                      where
                                                                             newForecastL.DATAAREAID == ForecastL.DATAAREAID &&
                                                                             newForecastL.QUOTATIONID == ForecastL.QUOTATIONID &&
                                                                             (newForecastH.STATUSIMPORTSALES == 1 || newForecastH.STATUSIMPORTSALES == 2 || newForecastH.STATUSIMPORTSALES == 4)
                                                                      select newForecastH.RECID).FirstOrDefault()
                                                && ForecastL.CUSTACCOUNT == Custtable_L.ACCOUNTNUM
                                                && ForecastL.DATAAREAID == Custtable_L.DATAAREAID
                                           select new
                                           {
                                               ForecastH.RECID,
                                               ForecastL.WORKERSALESRESPONSIBLE,
                                               ForecastH.ETP_APPROVER_ID,
                                               ForecastL.QUOTATIONID,
                                               ForecastH.STATUSIMPORTSALES,
                                               ForecastL.CUSTACCOUNT,
                                               ForecastL.CUSTNAME,
                                               ForecastL.SALE,
                                               ForecastL.ITEMID,
                                               ForecastL.QUOTATION_TYPE,
                                               ForecastL.BOMID,
                                               ForecastL.FORECAST,
                                               ForecastL.VERSION,

                                         

                                               //---> FROM COST MAGIM--------
                                               ForecastL.TRANSPORTATION_TYPE,
                                               ForecastL.EXPENSES_2,
                                               ForecastL.EXPENSES_5,
                                               ForecastL.EXPENSES_9,
                                               ForecastL.EXPENSES_10,
                                               ForecastL.EXPENSES_13,
                                               ForecastL.EXPENSES_14,
                                               ForecastL.EXPENSES_16,
                                               ForecastL.SPECIALDISC,
                                               //----------------------------
                                               ForecastL.EXPENSES_1,
                                               ForecastL.EXPENSES_18,
                                               ForecastL.EXPENSES_6,
                                               ForecastL.EXPENSES_7,
                                               ForecastL.EXPENSES_11,
                                               ForecastL.EXPENSES_12,
                                               ForecastL.EXPENSES_15,
                                               ForecastL.EXPENSESPERTON,
                                               ForecastL.REMARK2,
                                               //------------------------------
                                               ForecastL.PRICEPERTON,
                                               ForecastL.TAXITEMGROUP,
                                               ForecastL.TOTALSALES,
                                               ForecastL.COSTPERTON,
                                               ForecastL.TOTALCOSTSALES,
                                               ForecastL.MARGINTON,
                                               ForecastL.TOTALMARGIN,
                                               ForecastL.MARGINPERCEN,

                                               //---> FROM OVER VIEW
                                               Custtable_L.CREDITMAX,


                                           }).ToList();

                var sales_Name_Forecast_List = (
                                                 //from team_sales in new_sales_Responsible 
                                                 from a in _db.DirpersonName
                                                 from a2 in _db.DirpersonName
                                                     .Where(o => o.VALIDFROM == a.VALIDFROM && o.PERSON == a.PERSON &&

                                                                 o.VALIDFROM == _db.DirpersonName
                                                                     .Where(o => o.PERSON == a.PERSON)
                                                                     .Select(o => o.VALIDFROM).Max())
                                                 join b in _db.HCMWORKER on a.PERSON equals b.PERSON
                                                 select new
                                                 {
                                                     pRECID = b.RECID, // HCMWORKER (RECID) -> Key ที่จะนำไปใช้กับ Sales ForeCast 
                                                     pERSON = a.PERSON,
                                                     name = a.FIRSTNAME + "  " + a.LASTNAME,
                                                     vALIDFROM = a.VALIDFROM
                                                 }).ToList();
                var new_sales_Name_Responsible = (
                                                  from all_sales_Forcast_List in sales_Forecast_List
                                                  from sales_name in sales_Name_Forecast_List
                                                  .Where(o => o.pRECID == all_sales_Forcast_List.WORKERSALESRESPONSIBLE)
                                                  select new
                                                  {

                                                      recID = all_sales_Forcast_List.RECID,
                                                      QuotationID = all_sales_Forcast_List.QUOTATIONID,
                                                      Workersalesresponsible = all_sales_Forcast_List.WORKERSALESRESPONSIBLE,
                                                      Addsign_To = all_sales_Forcast_List.ETP_APPROVER_ID,
                                                      Customer_Account = all_sales_Forcast_List.CUSTACCOUNT,
                                                      Customer_Name = all_sales_Forcast_List.CUSTNAME,
                                                      Item_Number = all_sales_Forcast_List.ITEMID,
                                                      Quotation_Type = all_sales_Forcast_List.QUOTATION_TYPE,
                                                      BomId = all_sales_Forcast_List.BOMID,
                                                      Forecast = all_sales_Forcast_List.FORECAST,
                                                      StatusimportSales = all_sales_Forcast_List.STATUSIMPORTSALES,
                                                      Version = all_sales_Forcast_List.VERSION,
                                                      SalesName = sales_name.name,


                                                      //---> FROM COST MAGIM--------
                                                      TransportaTion_Type = all_sales_Forcast_List.TRANSPORTATION_TYPE,
                                                      expenses_2 = all_sales_Forcast_List.EXPENSES_2,
                                                      expenses_5 = all_sales_Forcast_List.EXPENSES_5,
                                                      expenses_9 = all_sales_Forcast_List.EXPENSES_9,
                                                      expenses_10 = all_sales_Forcast_List.EXPENSES_10,
                                                      expenses_13 = all_sales_Forcast_List.EXPENSES_13,
                                                      expenses_14 = all_sales_Forcast_List.EXPENSES_14,
                                                      expenses_16 = all_sales_Forcast_List.EXPENSES_16,
                                                      specialdisc = all_sales_Forcast_List.SPECIALDISC,
                                                      //-------------------------------------------
                                                      expenses_1 = all_sales_Forcast_List.EXPENSES_1,
                                                      expenses_18 = all_sales_Forcast_List.EXPENSES_18,
                                                      expenses_6 = all_sales_Forcast_List.EXPENSES_6,
                                                      expenses_7 = all_sales_Forcast_List.EXPENSES_7,
                                                      expenses_11 = all_sales_Forcast_List.EXPENSES_11,
                                                      expenses_12 = all_sales_Forcast_List.EXPENSES_12,
                                                      expenses_15 = all_sales_Forcast_List.EXPENSES_15,
                                                      expenses_Perton = all_sales_Forcast_List.EXPENSESPERTON,
                                                      remark2 = all_sales_Forcast_List.REMARK2,
                                                      //-------------------------------------------
                                                      priceper_Ton = all_sales_Forcast_List.PRICEPERTON,
                                                      taxItem_Group = all_sales_Forcast_List.TAXITEMGROUP,
                                                      total_Sales = all_sales_Forcast_List.TOTALSALES,
                                                      costper_Ton = all_sales_Forcast_List.COSTPERTON,
                                                      total_Cost_Sales = all_sales_Forcast_List.TOTALCOSTSALES,
                                                      margin_Ton = all_sales_Forcast_List.MARGINTON,
                                                      total_Margin = all_sales_Forcast_List.TOTALMARGIN,
                                                      margin_Percen = all_sales_Forcast_List.MARGINPERCEN,
                                                      //---> FROM OVER VIEW--------
                                                      credit_limit = all_sales_Forcast_List.CREDITMAX,
                                                  }
                                                  ).ToList();
                foreach (var s in new_sales_Name_Responsible)
                {
                    Form_Sales_Forecast_List_Tb a = new Form_Sales_Forecast_List_Tb();

                    //a.Full_Name = s.SalesName.ToString();
                    a.recID = s.recID;
                    a.QuotationID = s.QuotationID.ToString();
                    a.WORKERSALESRESPONSIBLE = s.Workersalesresponsible.ToString();

                    a.Assign_To = s.Addsign_To.ToString();
                    a.Customer_Account = s.Customer_Account.ToString();
                    a.Customer_Name = s.Customer_Name.ToString();
                    a.item_Number = s.Item_Number.ToString();
                    a.Formula_Version = s.BomId.ToString();
                    a.Quantity = s.Forecast;
                    a.Quantity_Type = s.Quotation_Type.ToString() == "0" ? "Forecast" : "Quotation";
                    // -- 2 = create , 1 = inreview , 4 = reject
                    a.Status = s.StatusimportSales.ToString() == "1" ? "inreview" : s.StatusimportSales.ToString() == "2" ? "create" : "reject";
                    a.Version = s.Version;

                    //---> FROM COST MAGIM--------
                    a.TransportaTion_Type = s.TransportaTion_Type.ToString() == "0" ? "พ่วง" : s.TransportaTion_Type.ToString() == "1" ? "เดี่ยว" : s.TransportaTion_Type.ToString() == "2" ? "เทรลเลอร์ สั้น" : s.TransportaTion_Type.ToString() == "3" ? "เทรลเลอร์ ยาว" : s.TransportaTion_Type.ToString() == "4" ? "ปูนเต้า เดี่ยว" : s.TransportaTion_Type.ToString() == "5" ? "ปูนเต้า พ่วง" : "-";
                    a.expenses_2 = Math.Round(s.expenses_2, 2);
                    a.expenses_5 = Math.Round(s.expenses_5, 2);
                    a.expenses_9 = Math.Round(s.expenses_9, 2);
                    a.expenses_10 = Math.Round(s.expenses_10, 2);
                    a.expenses_13 = Math.Round(s.expenses_13, 2);
                    a.expenses_14 = Math.Round(s.expenses_14, 2);
                    a.expenses_16 = Math.Round(s.expenses_16, 2);
                    a.specialdisc = Math.Round(s.specialdisc, 2);
                    //-------------------------------
                    a.expenses_1 = Math.Round(s.expenses_1, 2);
                    a.expenses_18 = Math.Round(s.expenses_18, 2);
                    a.expenses_6 = Math.Round(s.expenses_6, 2);
                    a.expenses_7 = Math.Round(s.expenses_7, 2);
                    a.expenses_11 = Math.Round(s.expenses_11, 2);
                    a.expenses_12 = Math.Round(s.expenses_12, 2);
                    a.expenses_15 = Math.Round(s.expenses_15, 2);
                    a.expenses_Perton = Math.Round(s.expenses_Perton, 2);
                    a.remark2 = s.remark2.ToString() != "" ? s.remark2.ToString() : " ";
                    //-------------------------------
                    a.priceper_Ton = Math.Round(s.priceper_Ton, 2);
                    a.taxItem_Group = s.taxItem_Group.ToString();
                    a.total_Sales = Math.Round(s.total_Sales, 2);
                    a.costper_Ton = Math.Round(s.costper_Ton, 2);
                    a.total_Cost_Sales = Math.Round(s.total_Cost_Sales, 2);
                    a.margin_Ton = Math.Round(s.margin_Ton, 2);
                    a.total_Margin = Math.Round(s.total_Margin, 2);
                    a.margin_Percen = Math.Round(s.margin_Percen, 2);
                    a.credit_limit = Math.Round(s.credit_limit, 2);
                    list_data.Add(a);
                }
            }
            return Ok( new { data = list_data });
        }

        [HttpGet]
        //[Authorize]
        [Route("Sales_Forcast_Related_Info")]
        public async Task<IActionResult> Sales_Forcast_Related_Info(string quotation_ID)
        {


            List<Form_Related_Info> list_data_Related_Info = new List<Form_Related_Info>();

            try
            {
                var related_info = (from SalesQuotation_H in _db.SALESQUOTATIONTABLE
                                      from Sales_L in _db.SALESTABLE
                                      where SalesQuotation_H.QUOTATIONID == quotation_ID &&
                                             SalesQuotation_H.SALESIDREF == Sales_L.SALESID &&
                                             SalesQuotation_H.DATAAREAID == Sales_L.DATAAREAID
                                      select new
                                      {
                                          quotationID = SalesQuotation_H.QUOTATIONID,
                                          sales_order_ID = Sales_L.SALESID,
                                          sales_order_Status = Sales_L.SALESSTATUS,
                                      }).ToList();
                if (related_info.Count > 0) {
                    foreach (var s in related_info)
                    {
                        Form_Related_Info a = new Form_Related_Info();
                        a.QUOTATIONID = s.quotationID.ToString();
                        a.SALES_ORDER_NO = s.sales_order_ID.ToString();
                        a.SALES_ORDER_STATUS = s.sales_order_Status.ToString() == "0" ? "none" : s.sales_order_Status.ToString() == "1" ? "Open order" : s.sales_order_Status.ToString() == "2" ? "Delivered" : s.sales_order_Status.ToString() == "3" ? "Invoiced" : s.sales_order_Status.ToString() == "4" ? "Canceled" : "-";
                        list_data_Related_Info.Add(a);
                    }
                }
                else {
                    return Ok(new { data = "NG" });
                }
            }
            catch (Exception ex){}
            return Ok(new { data = list_data_Related_Info });
        }

        [HttpPut]
        //[Authorize]
        [Route("Cancel_Sales_Forcast_List")] 
        public async Task<IActionResult> Cancel_Sales_Forcast_List(string[] recid_DataCancel) {
            List<string> list_data_cancelCompleted = new List<string>();
            List<string> list_data_cancelFail = new List<string>();
            try {
                if (recid_DataCancel.Length != 0)
                {
                    for (int i = 0; i < recid_DataCancel.Length; i++)
                    {
                        var salesForecast_ETP_ImportSalesFileHistory = await _db.ETP_ImportSalesFileHistory.FirstOrDefaultAsync(index => index.RECID == Convert.ToInt64(recid_DataCancel[i]));
                        if (salesForecast_ETP_ImportSalesFileHistory != null && (salesForecast_ETP_ImportSalesFileHistory.STATUSIMPORTSALES == 0 || salesForecast_ETP_ImportSalesFileHistory.STATUSIMPORTSALES == 1 || salesForecast_ETP_ImportSalesFileHistory.STATUSIMPORTSALES == 4))
                        {
                            salesForecast_ETP_ImportSalesFileHistory.STATUSIMPORTSALES = 3;
                            var result = await _db.SaveChangesAsync();
                            list_data_cancelCompleted.Add(recid_DataCancel[i]);
                           // return result >= 0 ? salesForecast_UserPermissionIndex : null;
                        }
                        else
                        {
                            list_data_cancelFail.Add(recid_DataCancel[i]);
                        }
                    }
                }
                else
                {

                    return Ok("NoData");
                }
            }
            catch(Exception e) {
                return null;
            }
            return Ok(new { dataCompleted = list_data_cancelCompleted, dataFail = list_data_cancelFail}); 
        
        }
    
    
    }
}
