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
    
    public partial class ApprovalProcedure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApprovalProcedure()
        {
            this.Approvals = new HashSet<Approval>();
        }
    
        public int ApprovalProcedureID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public string ApprovalReportName { get; set; }
        public Nullable<bool> ApprovalSupervisor { get; set; }
        public Nullable<bool> ApprovalDirector { get; set; }
        public Nullable<bool> ApprovalGenalManager { get; set; }
        public Nullable<bool> ApprovalFinancialDirector { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Approval> Approvals { get; set; }
    }
}
