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
    
    public partial class ApprovalOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApprovalOrder()
        {
            this.ApprovalChilds = new HashSet<ApprovalChild>();
        }
    
        public Nullable<int> ReportID { get; set; }
        public Nullable<int> ApprovalCategoryID { get; set; }
        public int ApprovalStageID { get; set; }
        public string ApprovalOrder1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApprovalChild> ApprovalChilds { get; set; }
        public virtual ReportMain ReportMain { get; set; }
    }
}
