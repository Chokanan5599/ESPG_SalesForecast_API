using System.ComponentModel;
using System.Text.Json.Serialization;
namespace ESPG_SalesForecast_API.Model
{
    public class Web_SalesForecast_UserPermission
    {
        public int ID { get; set; }

        public int User_id { get; set; }
         [JsonIgnore]
        
        public   string? Pass_id { get; set; }

        public  string First_Name { get; set; }

        public string? Last_Name { get; set; }
        
        public  string? Email { get; set; }

        public string? Role { get; set; }

       
    }
}
