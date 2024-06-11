using ESPG_SalesForecast_API.Entity;
using ESPG_SalesForecast_API.Helpers;
using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Services_Businesslogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESPG_SalesForecast_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Form_Fill_DateController : ControllerBase
    {
        string fToken;
        private readonly TAAX63TEST_DbContext _db;
        private readonly IWeb_SalesForecast_UserPermissionService _SalesForecast_UserPermissionService;
        public Form_Fill_DateController(TAAX63TEST_DbContext db, IWeb_SalesForecast_UserPermissionService salesForcastService)
        {
            _db = db;
            _SalesForecast_UserPermissionService = salesForcastService;
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] int? id = null)
        //{
        //    return Ok(_SalesForecast_UserPermissionService.GetAllSalesForecast_UserPermission(id));
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var salesFore_Cast = _SalesForecast_UserPermissionService.GetSalesForecast_UserPermissionByID(id);
        //    if (salesFore_Cast == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(salesFore_Cast);
        //}
        //[HttpPost]
        //public IActionResult Post(AddUpdate_Web_SalesForecast_UserPermission Object)
        //{
        //    var salesFore_Cast = _SalesForecast_UserPermissionService.AddSalesForecast_UserPermission(Object);

        //    if (salesFore_Cast == null)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(new
        //    {
        //        message = "Super Hero Created Successfully!!!",
        //        id = salesFore_Cast!.ID,
        //    });
        //}
        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Put([FromRoute] int id, [FromBody] AddUpdate_Web_SalesForecast_UserPermission Object)
        //{
        //    var salesFore_Cast = _SalesForecast_UserPermissionService.UpdateSalesForecast_UserPermission(id, Object);
        //    if (salesFore_Cast == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(new
        //    {
        //        message = "Super Hero Updated Successfully!!!",
        //        id = salesFore_Cast!.ID
        //    });
        //}
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id = null)
        {
            var salesFore_Cast = await _SalesForecast_UserPermissionService.GetAllSalesForecast_UserPermission(id);
            return Ok(salesFore_Cast);
        }

        [HttpGet("{id}")]
        //[Route("{id}")] // /api/OurHero/:id
        public async Task<IActionResult> Get(int id)
        {
            var salesFore_Cast = await _SalesForecast_UserPermissionService.GetSalesForecast_UserPermissionByID(id);
            if (salesFore_Cast == null)
            {
                return NotFound();
            }
            return Ok(salesFore_Cast);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdate_Web_SalesForecast_UserPermission Object)
        {
            var salesFore_Cast = await _SalesForecast_UserPermissionService.AddSalesForecast_UserPermission(Object);

            if (salesFore_Cast == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = salesFore_Cast!.ID
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdate_Web_SalesForecast_UserPermission Object)
        {
            var salesFore_Cast = await _SalesForecast_UserPermissionService.UpdateSalesForecast_UserPermission(id, Object);
            if (salesFore_Cast == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Updated Successfully!!!",
                id = salesFore_Cast!.ID
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _SalesForecast_UserPermissionService.DeleteSalesForecast_UserPermissionByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }


        [HttpGet]
        [Authorize]
        [Route("Form_Fill_Date")]
        public async Task<IActionResult> Get_Form_Fill_Date(string user_Id, string _class, string company, string foreCast_user_Id)
        {
            //List<TAAX63TEST_DbContext> user_Fill_Date = new List<TAAX63TEST_DbContext>();
            List<Form_Fill> list_data_Form = new List<Form_Fill>();
            try { 
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
                if (_class == "Admin")
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
                return new OkObjectResult(new { data = list_data_Form });
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
