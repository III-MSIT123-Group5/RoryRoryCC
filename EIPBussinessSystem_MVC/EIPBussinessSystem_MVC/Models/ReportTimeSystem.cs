//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIPBussinessSystem_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReportTimeSystem
    {
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public int employeeID { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public double EventHours { get; set; }
        public int EventID { get; set; }
        public string Note { get; set; }
        public System.DateTime ApplyDateTime { get; set; }
        public Nullable<bool> Discontinue { get; set; }
    }
}
