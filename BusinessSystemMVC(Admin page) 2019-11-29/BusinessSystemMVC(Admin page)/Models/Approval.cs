//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessSystemMVC_Admin_page_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Approval
    {
        public int OrderID { get; set; }
        public Nullable<int> ApprovalProcedureID { get; set; }
        public Nullable<int> FirstSignerID { get; set; }
        public string FirstSignerName { get; set; }
        public string FirstSignStatus { get; set; }
        public Nullable<System.DateTime> FirstSignDate { get; set; }
        public Nullable<int> SecondSignerID { get; set; }
        public string SecondSignerName { get; set; }
        public string SecondSignStatus { get; set; }
        public Nullable<System.DateTime> SecondSignDate { get; set; }
        public Nullable<int> ThirdSignerID { get; set; }
        public string ThirdSignerName { get; set; }
        public string ThirdSignStatus { get; set; }
        public Nullable<System.DateTime> ThirdSignDate { get; set; }
        public Nullable<int> FourthSignerID { get; set; }
        public string FourthSignerName { get; set; }
        public string FourthSignStatus { get; set; }
        public Nullable<System.DateTime> ForthSignDate { get; set; }
    
        public virtual ApprovalProcedure ApprovalProcedure { get; set; }
        public virtual RequisitionMain RequisitionMain { get; set; }
    }
}
