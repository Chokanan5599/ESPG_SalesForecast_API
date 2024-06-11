using ESPG_SalesForecast_API.Entity;
using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Services_Businesslogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ESPG_SalesForecast_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IWeb_SalesForecast_UserPermissionService _userPermission;
        private readonly TAAX63TEST_DbContext _db;
        //private readonly AuthenticateRequest _authenticateRequest;
        private string userName;
        private string toKen;


        public LoginController(
            TAAX63TEST_DbContext db,
            //AuthenticateRequest authenticateRequest,
            IWeb_SalesForecast_UserPermissionService userPermission
            )
        {
            _db = db;
            _userPermission = userPermission;
            //_authenticateRequest = authenticateRequest;
        }
        [HttpGet]
        [Route("Company")]
        public async Task<IActionResult> GetCompany(string txt_email)
        {

            if (txt_email == null) { return NotFound(); }

            var set_Role = _db.Web_SalesForecast_UserPermission.Where(a => a.Email == txt_email).Select(a => new { a.Role }).FirstOrDefault();
            
            if (set_Role == null)
            {
                return NotFound();
                //return Ok("NG");
            }
            var company = (from a in _db.Web_SalesForecast_UserPermission

                           join b in _db.Web_SalesForecast_Company
                           on a.User_id equals b.User_id into tb_1
                           from Result1 in tb_1.DefaultIfEmpty()

                           join c in _db.SysUserInfo
                           on a.Email equals c.EMAIL into tb_2
                           from Result2 in tb_2.DefaultIfEmpty()

                           where a.Email == txt_email
                           select new
                           {
                               login_User_id = a.User_id,
                               Company_Name = Result1.Company_Name,
                               foreCast_User_id = Result2.ID,
                               user_Type = a.Role
                           }).ToList();
           
            return Ok(new { data1 = company, data2 = set_Role });
        }

        //[HttpPost]
        [HttpGet]
        [Route("Signin")]
        public async Task<IActionResult> GetLogin(string txt_email, string txt_password, string txt_selected)
        {
            AuthenticateRequest a_Model = new AuthenticateRequest();
            a_Model.Email = txt_email;
            a_Model.Pass_id = txt_password;
            var response = await _userPermission.Authenticate(a_Model);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var user = (from a in _db.Web_SalesForecast_UserPermission

                        join b in _db.Web_SalesForecast_Company on a.User_id equals b.User_id into tb_1
                        from Result1 in tb_1.DefaultIfEmpty()

                        join b in _db.SysUserInfo on a.Email equals b.EMAIL into tb_2
                        from Result2 in tb_2.DefaultIfEmpty()

                        //where a.Email == model.Email
                        where a.Email == txt_email
                        select new
                        {
                            login_User_id = a.User_id,
                            Role = a.Role,
                            Company_Name = Result1.Company_Name,
                            foreCast_User_id = Result2.ID
                        }).FirstOrDefault();
            return Ok(new { data = user , token = response });
        }
        

        //public async Task<IActionResult> GetLogin(AuthenticateRequest model)
        //public async Task<IActionResult> GetLogin([FromBody] AuthenticateRequest model)
        ////public async Task<IActionResult> GetLogin(AuthenticateRequest model)
        //{
        //    var response = await _userPermission.Authenticate(model);
        //    if (response == null) {
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    }

        //    var user = (from a in _db.Web_SalesForecast_UserPermission

        //                join b in _db.Web_SalesForecast_Company on a.User_id equals b.User_id into tb_1
        //                from Result1 in tb_1.DefaultIfEmpty()

        //                join b in _db.SysUserInfo on a.Email equals b.EMAIL into tb_2
        //                from Result2 in tb_2.DefaultIfEmpty()

        //                where a.Email == model.Email
        //                //where a.Email == txt_email
        //                select new
        //                {
        //                    login_User_id = a.User_id,
        //                    Role = a.Role,
        //                    Company_Name = Result1.Company_Name,
        //                    foreCast_User_id = Result2.ID
        //                }).FirstOrDefault();
        //    //userName = HttpContext.Session.GetString("UserName");
        //    //ViewData["UserName"] = userName;
        //    try { 
        //        //HttpContext.Session.SetString("UserName", user.foreCast_User_id);
        //        //return Ok(new { data1 = user , data2 = response } );
        //        return Ok(response);
        //    }
        //    catch (Exception ex) {
        //        throw ex; 
        //    }
        //}
    }
}
