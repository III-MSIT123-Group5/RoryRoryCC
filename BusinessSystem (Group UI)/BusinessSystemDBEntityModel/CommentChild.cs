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
    
    public partial class CommentChild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentChild()
        {
            this.CommentReplies = new HashSet<CommentReply>();
            this.CommentReplies1 = new HashSet<CommentReply>();
        }
    
        public Nullable<int> CommentMainID { get; set; }
        public int ChildNum { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> CommentQuestionID { get; set; }
    
        public virtual CommentMain CommentMain { get; set; }
        public virtual CommentQuestion CommentQuestion { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentReply> CommentReplies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentReply> CommentReplies1 { get; set; }
    }
}
