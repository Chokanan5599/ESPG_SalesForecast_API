
using ESPG_SalesForecast_API.Model;
using ESPG_SalesForecast_API.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
//using System.Data;
namespace ESPG_SalesForecast_API.Services_Businesslogic
{
    public class Web_SalesForecast_UserPermissionService : IWeb_SalesForecast_UserPermissionService
    {
        
        private readonly AppSettings _appSettings;
        private readonly TAAX63TEST_DbContext _db;
        public Web_SalesForecast_UserPermissionService(IOptions<AppSettings> appSettings, TAAX63TEST_DbContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }
        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        //public async Task<AuthenticateResponse> Authenticate(string txt_email, string txt_password)
        {
            var user = await _db.Web_SalesForecast_UserPermission.SingleOrDefaultAsync(x => x.Email == model.Email && x.Pass_id == model.Pass_id);
            //var user = await _db.Web_SalesForecast_UserPermission.SingleOrDefaultAsync(a => a.Email == txt_email && a.Pass_id == txt_password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<List<Web_SalesForecast_UserPermission>> GetAllSalesForecast_UserPermission(int? id)
        {
            if (id == null) { return await _db.Web_SalesForecast_UserPermission.ToListAsync(); }

            return await _db.Web_SalesForecast_UserPermission.Where(obj => obj.ID == id).ToListAsync();
         }
        public async Task<Web_SalesForecast_UserPermission?> GetSalesForecast_UserPermissionByID(int id)
        {
            return await _db.Web_SalesForecast_UserPermission.FirstOrDefaultAsync(hero => hero.ID == id);
        }

        public async Task<Web_SalesForecast_UserPermission?> AddSalesForecast_UserPermission(AddUpdate_Web_SalesForecast_UserPermission obj)
        {
            var addsalesForecast_Userpermission = new Web_SalesForecast_UserPermission()
            {
                //ID = obj.ID,
                User_id = obj.User_id,  

                First_Name= obj.First_Name,
                Last_Name = obj.Last_Name,
                Pass_id = obj.Pass_id,
                Email = obj.Email,
                Role = obj.Role,
                //isActive = obj.isActive,
            };

            _db.Web_SalesForecast_UserPermission.Add(addsalesForecast_Userpermission);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addsalesForecast_Userpermission : null;
        }


        public async Task<Web_SalesForecast_UserPermission?> UpdateSalesForecast_UserPermission(int id, AddUpdate_Web_SalesForecast_UserPermission obj)
        {
            var salesForecast_UserPermissionIndex = await _db.Web_SalesForecast_UserPermission.FirstOrDefaultAsync(index => index.ID == id);
            if (salesForecast_UserPermissionIndex != null)
            {
               
                salesForecast_UserPermissionIndex.User_id = obj.User_id;
                salesForecast_UserPermissionIndex.First_Name = obj.First_Name;
                salesForecast_UserPermissionIndex.Last_Name = obj.Last_Name;

                salesForecast_UserPermissionIndex.Pass_id = obj.Pass_id;
                salesForecast_UserPermissionIndex.Email = obj.Email;
                salesForecast_UserPermissionIndex.Role = obj.Role;
                //salesForecast_UserPermissionIndex.isActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? salesForecast_UserPermissionIndex : null;
            }
            return null;
        }

        public async Task<bool> DeleteSalesForecast_UserPermissionByID(int id)
        {
            var hero = await _db.Web_SalesForecast_UserPermission.FirstOrDefaultAsync(index => index.ID == id);
            if (hero != null)
            {
                _db.Web_SalesForecast_UserPermission.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

        // helper methods
       // private async Task<string> generateJwtToken(Web_SalesForecast_UserPermission user)
        private async Task<string> generateJwtToken(Web_SalesForecast_UserPermission user)
        {
            //Generate token that is valid for 1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
                    //Expires = DateTime.UtcNow.AddDays(1),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

    }
}
