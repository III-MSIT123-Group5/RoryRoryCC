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
    
    public partial class CommentQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommentQuestion()
        {
            this.CommentChilds = new HashSet<CommentChild>();
        }
    
        public Nullable<int> CommentContentID { get; set; }
        public int CommentQuestionID { get; set; }
        public string Question { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentChild> CommentChilds { get; set; }
        public virtual CommentContent CommentContent { get; set; }
    }
}
