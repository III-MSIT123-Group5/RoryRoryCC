//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessSystemDBEntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequisitionMain
    {
        public string ReportID { get; set; }
        public int RequisitionID { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string Note { get; set; }
    
        public virtual ReportMain ReportMain { get; set; }
        public virtual RequisitionChild RequisitionChild { get; set; }
    }
}