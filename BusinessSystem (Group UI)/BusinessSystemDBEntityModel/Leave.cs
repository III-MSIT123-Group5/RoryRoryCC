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
    
    public partial class Leave
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Leave()
        {
            this.LeaveHistories = new HashSet<LeaveHistory>();
            this.LeaveHistoryApprovalTemps = new HashSet<LeaveHistoryApprovalTemp>();
        }
    
        public int leaveID { get; set; }
        public string leave_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistory> LeaveHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps { get; set; }
    }
}
