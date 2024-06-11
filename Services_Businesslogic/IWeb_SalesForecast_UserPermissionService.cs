using ESPG_SalesForecast_API.Model;
namespace ESPG_SalesForecast_API.Services_Businesslogic
{
    public interface IWeb_SalesForecast_UserPermissionService
    {
        //Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<List<Web_SalesForecast_UserPermission>> GetAllSalesForecast_UserPermission(int? id);

       Task<Web_SalesForecast_UserPermission?> GetSalesForecast_UserPermissionByID(int id);

        Task<Web_SalesForecast_UserPermission?> AddSalesForecast_UserPermission(AddUpdate_Web_SalesForecast_UserPermission obj);

        Task<Web_SalesForecast_UserPermission?> UpdateSalesForecast_UserPermission(int id, AddUpdate_Web_SalesForecast_UserPermission obj);

        Task<bool> DeleteSalesForecast_UserPermissionByID(int id);
        //Task Authenticate(List<AuthenticateRequest> authenticateRequest);

        //Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        //Task<IEnumerable<User>> GetAll();
        //Task<User?> GetById(int id);
        //Task<User?> AddAndUpdateUser(User userObj);



        //----------------Get Company By Login ---------------------//
        //Task<List<Web_SalesForecast_Company>> GetCompany(string txt_email);


    }
}
