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
    
    public partial class CommentChild
    {
        public Nullable<int> CommentMainID { get; set; }
        public int Num { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> CommentQuestionID { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<System.DateTime> ReplyTime { get; set; }
    
        public virtual CommentQuestion CommentQuestion { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
