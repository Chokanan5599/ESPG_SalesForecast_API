namespace ESPG_SalesForecast_API.Model
{
    public class SysUserInfo
    {
        public string ID { get; set; } = string.Empty;
        public int DOCUHANDLINGACTIVE { get; set; }
        public int DOCUTOOLBARBUTTONACTIVE { get; set; }
        public int HELPMARKEMPTYLINKS { get; set; }
        public string HELPTHEME { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public int COMPILERTARGET { get; set; }
        public string LANGUAGE { get; set; } = string.Empty;
        public int SQMUSERGUID { get; set; }
        public int SQMENABLED { get; set; }
        public string DEFAULTCOUNTRYREGION { get; set; } = string.Empty;
        public int EVENTPOLLFREQUENCY { get; set; }
        public int EVENTPOPUPLINKDESTINATION { get; set; }
        public int EVENTPOPUPDISPLAYWHEN { get; set; }
        public int EVENTEMAILALERTSWHEN { get; set; }
        public int EVENTPOPUPS { get; set; }
        public int EVENTWORKFLOWTASKSINEMAIL { get; set; }
        public int WORKFLOWLINEITEMNOTIFICATIONFORMAT { get; set; }
        public int EVENTWORKFLOWTASKSINCLIENT { get; set; }
        public int EVENTWORKFLOWSHOWPOPUP { get; set; }
        public int RECVERSION { get; set; }
        public int PARTITION { get; set; }
        public int RECID { get; set; }
        public int CONFIRMLARGESTATICEXCELEXPORT { get; set; }
        public string ECL_PROJECTVERSION { get; set; } = string.Empty;
       
        public string ECL_CURPROJNAME { get; set; } = string.Empty;
    }
}
