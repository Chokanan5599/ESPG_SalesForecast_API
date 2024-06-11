﻿using System.ComponentModel.DataAnnotations;

namespace ESPG_SalesForecast_API.Model
{
    public class ETP_Oc_Team
    {
        public int CHIEF_EXECUTIVE_OFFICER { get; set; }
        public string? DATAAREA { get; set; }
        public int DEPARTMENT_MANAGER { get; set; }
        public int DIRECTOR { get; set; }
        public int EMPLOYEE { get; set; }
        public int ETP_TEAM { get; set; }
        public long MANAGER { get; set; }
        public string? MODIFIEDBY { get; set; }
        public int MODIFIEDTRANSACTIONID { get; set; }
        public DateTime? CREATEDDATETIME { get; set; }
        public string? CREATEDBY { get; set; }
        public int RECVERSION { get; set; }
        public int PARTITION { get; set; }
        [Key]
        public int RECID { get; set; }
        public int SUPERVISOR { get; set; }

    }
}
