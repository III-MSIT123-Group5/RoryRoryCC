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
    
    public partial class CommentMain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentMain()
        {
            this.CommentChilds = new HashSet<CommentChild>();
            this.CommentReplies = new HashSet<CommentReply>();
        }
    
        public int CommentMainID { get; set; }
        public string CommentName { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> SendTime { get; set; }
        public Nullable<int> CommentContentID { get; set; }
        public Nullable<int> ActivityMainID { get; set; }
    
        public virtual ActivitiesMain ActivitiesMain { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentChild> CommentChilds { get; set; }
        public virtual CommentContent CommentContent { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentReply> CommentReplies { get; set; }
    }
}
