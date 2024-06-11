using System.ComponentModel;

namespace ESPG_SalesForecast_API.Model
{
    public class AuthenticateRequest
    {
        //[DefaultValue("System")]
        //public required string Email { get; set; }

        //[DefaultValue("System")]
        //public required string Pass_id { get; set; }
        //[DefaultValue("System")]
        //public required string Company { get; set; }
        [DefaultValue("System")]
        public string Email { get; set; }

        [DefaultValue("System")]
        public string Pass_id { get; set; }
        [DefaultValue("System")]
        public string Company { get; set; }
    }
}