using ESPG_SalesForecast_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ESPG_SalesForecast_API.Entity
{
 
    public class TAAX63TEST_DbContext : DbContext
    {
        public TAAX63TEST_DbContext(DbContextOptions<TAAX63TEST_DbContext> options) : base(options)
        {
        }

        public DbSet<Web_SalesForecast_UserPermission> Web_SalesForecast_UserPermission { get; set; }
        public DbSet<Web_SalesForecast_Company> Web_SalesForecast_Company { get; set; }
        public DbSet<SysUserInfo> SysUserInfo { get; set; }
        public DbSet<Form_Fill> Form_Fill { get; set; }
        public DbSet<DirpersonName> DirpersonName { get; set; }
        public DbSet<HCM_Worker> HCMWORKER { get; set; }
        public DbSet<DirpersonUser> DirpersonUser { get; set; }
        public DbSet<ETP_Oc_Team> ETP_Oc_Team { get; set; }
        public DbSet<ETP_Import_Sales_File_History> ETP_ImportSalesFileHistory { get; set; }
        public DbSet<ETP_Import_Sales_History> ETP_ImportSalesHistory { get; set; }
        public DbSet<Form_Sales_Responsible_Tb> Form_Sales_Responsible_Tb { get; set; }
        public DbSet<Form_Sales_Forecast_List_Tb> Form_Sales_Forecast_List_Tb { get; set; }
        public DbSet<Sales_Quotation_Table> SALESQUOTATIONTABLE { get; set; }
        public DbSet<Sales_Table> SALESTABLE { get; set; }
        public DbSet<Form_Related_Info> Form_Related_Info { get; set; }
        public DbSet<Cust_Table> CUSTTABLE { get; set; }

        //public DbSet<ReceID> ReceID { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Web_SalesForecast_UserPermission>().HasKey(x => x.ID);

            // Inserting record in OurHero table
            //modelBuilder.Entity<Web_SalesForecast_UserPermission>().HasData(
            //    new Web_SalesForecast_UserPermission
            //    {
            //        Id = 1,
            //        FirstName = "System",
            //        LastName = "",
            //        isActive = true,
            //    }
            //);
        }
    }
}
