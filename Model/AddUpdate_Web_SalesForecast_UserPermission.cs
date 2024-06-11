namespace ESPG_SalesForecast_API.Model
{
    public class AddUpdate_Web_SalesForecast_UserPermission
    {
        //public required string First_Name { get; set; }
        //public string Last_Name { get; set; } = string.Empty;
        //public int ID { get; set; }

                
        public int User_id { get; set; }

        public string? Pass_id { get; set; }

        public required string First_Name { get; set; }

        public string? Last_Name { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }
    }
}
