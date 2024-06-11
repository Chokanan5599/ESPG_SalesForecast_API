using ESPG_SalesForecast_API.Model;

namespace ESPG_SalesForecast_API.Model
{
    public class AuthenticateResponse
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int User_id { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Web_SalesForecast_UserPermission user, string token)
        {
            ID = user.ID;
            First_Name = user.First_Name;
            Last_Name = user.Last_Name;
            User_id = user.User_id;
            Token = token;
        }
    }
}