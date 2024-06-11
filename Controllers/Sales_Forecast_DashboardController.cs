using ESPG_SalesForecast_API.Entity;
using ESPG_SalesForecast_API.Helpers;
using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Services_Businesslogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Azure.Core.HttpHeader;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ESPG_SalesForecast_API.Controllers
{
        [Route("api/[controller]")]
    [ApiController]
    public class Sales_Forecast_DashboardController : ControllerBase
    {
        private readonly TAAX63TEST_DbContext _db;
       
        public Sales_Forecast_DashboardController(TAAX63TEST_DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize] 
        [Route("Sales_Reponsible")]
        //public async Task<IActionResult> Sales_Reponsible(List<string> obj)
        public async Task<IActionResult> Sales_Reponsible(
            string salesRespon_recid, 
            string user_Id, 
            string _class, 
            string company, 
            string foreCast_user_Id, 
            string month_Year)
        {
            List<Form_Sales_Responsible_Tb> list_data = new List<Form_Sales_Responsible_Tb>();
            List<Form_Fill> list_data_Form = new List<Form_Fill>();
            string dateForm = month_Year;//Parameter
            var myDate = Convert.ToDateTime(dateForm);
            var startOfMonth = new DateTime(myDate.Year, myDate.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            string[] workerSales_Responsible = new[] { "5637144625", "5637144628" };
            //IEnumerable<string> test1 = workerSales_Responsible.AsEnumerable();
            //string[] secondArray = (string[])test1;

            if (salesRespon_recid == "All")
            {
                if (_class == "Admin")
                {
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
                if (_class == "Director")
                {
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
                if (_class == "Leader")
                {

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

                    //var fill_Leader3 = fill_Leader.Where(s => fill_Leader2.ToString().Contains(Convert.ToString(s.pRECID))).ToList();
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
                if (_class == "Officer")
                {
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
                for (int i = 0; i < list_data_Form.Count; i++)
                {

                    var sales_Responsible = (from ForecastH in _db.ETP_ImportSalesFileHistory
                                             from ForecastL in _db.ETP_ImportSalesHistory
                                             .Where(x => ForecastH.RECID == x.RECID && ForecastH.DATAAREAID == x.DATAAREAID).DefaultIfEmpty()
                                             where
                                                 //d.ETP_TEAM != 0 
                                                 //&& d.DATAAREA == company
                                                  ForecastH.DATAAREAID == company
                                                 && ForecastH.TODATE >= startOfMonth
                                                 && ForecastH.TODATE <= endOfMonth
                                                 && ForecastL.WORKERSALESRESPONSIBLE.ToString().Contains(list_data_Form[i].RECID.ToString())
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
                                             select new
                                             {
                                            
                                                 ForecastL.QUOTATIONID,
                                                 ForecastH.STATUSIMPORTSALES,
                                                 ForecastL.FORECAST,
                                                 ForecastL.TOTALSALES,
                                                 ForecastL.TOTALCOST,
                                                 ForecastL.TOTALCOSTSALES,
                                                 ForecastL.TOTALMARGIN,
                                                 ForecastL.WORKERSALESRESPONSIBLE
                                             }).ToList();

                    var new_sales_Responsible = (
                                                 from all in sales_Responsible.GroupBy(o => o.WORKERSALESRESPONSIBLE)
                                                 select new
                                                 {
                                                    
                                                     WORKERSALESRESPONSIBLE = all.FirstOrDefault().WORKERSALESRESPONSIBLE,
                                                     FORECAST = all.Sum(c => c.FORECAST),
                                                     TOTALSALES = all.Sum(c => c.TOTALSALES),
                                                     TOTALCOSTSALES = all.Sum(c => c.TOTALCOSTSALES),
                                                     TOTALMARGIN = all.Sum(c => c.TOTALMARGIN),
                                                     PROFITPERCENTAGE = (all.Sum(c => c.TOTALMARGIN) / all.Sum(c => c.TOTALSALES)) * 100
                                                 }).ToList();
                    //Query FullName Sales Team 
                    var sales_Name_Responsible = (
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
                                                      name = a.FIRSTNAME+"  "+a.LASTNAME,
                                                      vALIDFROM = a.VALIDFROM
                                                  }).ToList();
                    var new_sales_Name_Responsible = (
                                                      from all_sales in new_sales_Responsible
                                                      from sales_name in sales_Name_Responsible
                                                      .Where(o => o.pRECID == all_sales.WORKERSALESRESPONSIBLE)
                                                      select new {
                                                       
                                                        SalesName = sales_name.name,
                                                        Workersalesresponsible = all_sales.WORKERSALESRESPONSIBLE,
                                                        FORECAST = all_sales.FORECAST,
                                                        TOTALSALES = all_sales.TOTALSALES,
                                                        TOTALCOSTSALES = all_sales.TOTALCOSTSALES,
                                                        TOTALMARGIN = all_sales.TOTALMARGIN,
                                                        PROFITPERCENTAGE = all_sales.PROFITPERCENTAGE,
                                                      }
                                                      ).ToList();




                    foreach (var s in new_sales_Name_Responsible)
                    {
                        Form_Sales_Responsible_Tb a = new Form_Sales_Responsible_Tb();
                    
                        a.Full_Name = s.SalesName.ToString();
                        a.WORKERSALESRESPONSIBLE = s.Workersalesresponsible.ToString();
                        a.Fore_cast = Math.Round(s.FORECAST, 2);
                        a.Total_Sales = Math.Round(s.TOTALSALES, 2);
                        a.Total_CostSales = Math.Round(s.TOTALCOSTSALES, 2);
                        a.Total_Margin = Math.Round(s.TOTALMARGIN,2) ;
                        a.Profit_Percentage = Math.Round(s.PROFITPERCENTAGE,2);
                        list_data.Add(a);
                    }
                }
            }
            else
            {
                    var sales_Responsible = (from ForecastH in _db.ETP_ImportSalesFileHistory
                                             from ForecastL in _db.ETP_ImportSalesHistory
                                             .Where(x => ForecastH.RECID == x.RECID && ForecastH.DATAAREAID == x.DATAAREAID).DefaultIfEmpty()
                                             where
                                                 ForecastH.DATAAREAID == company
                                                 && ForecastH.TODATE >= startOfMonth
                                                 && ForecastH.TODATE <= endOfMonth
                                                 && ForecastL.WORKERSALESRESPONSIBLE.ToString().Contains(salesRespon_recid)//ส่ง ReceId ของ Sales มาแค่คนเดียว
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
                                             select new
                                             {
                                                 ForecastL.QUOTATIONID,
                                                 ForecastH.STATUSIMPORTSALES,
                                                 ForecastL.FORECAST,
                                                 ForecastL.TOTALSALES,
                                                 ForecastL.TOTALCOST,
                                                 ForecastL.TOTALCOSTSALES,
                                                 ForecastL.TOTALMARGIN,
                                                 ForecastL.WORKERSALESRESPONSIBLE
                                             }).ToList();

                    var new_sales_Responsible = (from all in sales_Responsible.GroupBy(o => o.WORKERSALESRESPONSIBLE)
                                                 select new
                                                 {
                                                     WORKERSALESRESPONSIBLE = all.FirstOrDefault().WORKERSALESRESPONSIBLE,
                                                     FORECAST = all.Sum(c => c.FORECAST),
                                                     TOTALSALES = all.Sum(c => c.TOTALSALES),
                                                     TOTALCOSTSALES = all.Sum(c => c.TOTALCOSTSALES),
                                                     TOTALMARGIN = all.Sum(c => c.TOTALMARGIN),
                                                     PROFITPERCENTAGE = (all.Sum(c => c.TOTALMARGIN) / all.Sum(c => c.TOTALSALES)) * 100
                                                 }).ToList();

                var sales_Name_Responsible = (
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
                                                      from all_sales in new_sales_Responsible
                                                      from sales_name in sales_Name_Responsible
                                                      .Where(o => o.pRECID == all_sales.WORKERSALESRESPONSIBLE)
                                                      select new
                                                      {

                                                          SalesName = sales_name.name,
                                                          Workersalesresponsible = all_sales.WORKERSALESRESPONSIBLE,
                                                          FORECAST = all_sales.FORECAST,
                                                          TOTALSALES = all_sales.TOTALSALES,
                                                          TOTALCOSTSALES = all_sales.TOTALCOSTSALES,
                                                          TOTALMARGIN = all_sales.TOTALMARGIN,
                                                          PROFITPERCENTAGE = all_sales.PROFITPERCENTAGE,
                                                      }
                                                      ).ToList();

                foreach (var s in new_sales_Name_Responsible)
                {
                    Form_Sales_Responsible_Tb a = new Form_Sales_Responsible_Tb();
                    a.Full_Name = s.SalesName.ToString();
                    a.WORKERSALESRESPONSIBLE = s.Workersalesresponsible.ToString();
                    a.Fore_cast = Math.Round(s.FORECAST, 2);
                    a.Total_Sales = Math.Round(s.TOTALSALES, 2);
                    a.Total_CostSales = Math.Round(s.TOTALCOSTSALES, 2);
                    a.Total_Margin = Math.Round(s.TOTALMARGIN, 2);
                    a.Profit_Percentage = Math.Round(s.PROFITPERCENTAGE, 2);
                    list_data.Add(a);
                }


            }
            return Ok(new { data = list_data});
        }
    }

   
}
