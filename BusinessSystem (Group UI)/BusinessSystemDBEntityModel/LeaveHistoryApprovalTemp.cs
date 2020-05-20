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
    
    public partial class LeaveHistoryApprovalTemp
    {
        public int ID { get; set; }
        public int employeeID { get; set; }
        public int leaveID { get; set; }
        public System.DateTime ReleaseTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Appendix { get; set; }
        public Nullable<int> LeaveHours { get; set; }
        public Nullable<int> GroupLeader { get; set; }
        public Nullable<System.DateTime> GroupLeaderSignTime { get; set; }
        public Nullable<int> DepartmentLeader { get; set; }
        public Nullable<System.DateTime> DepartmentLeaderSignTime { get; set; }
        public Nullable<int> GeneralManager { get; set; }
        public Nullable<System.DateTime> GeneralManagerSignTime { get; set; }
        public string Status { get; set; }
        public bool SignState { get; set; }
        public bool Reject { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        public virtual Employee Employee3 { get; set; }
        public virtual Leave Leave { get; set; }
    }
}