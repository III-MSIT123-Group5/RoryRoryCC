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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.BulletinBoards = new HashSet<BulletinBoard>();
            this.Employee1 = new HashSet<Employee>();
            this.Files = new HashSet<File>();
            this.MeetingRoomHistories = new HashSet<MeetingRoomHistory>();
            this.Messages = new HashSet<Message>();
            this.Recipients = new HashSet<Recipient>();
            this.ReportMains = new HashSet<ReportMain>();
            this.SuggestionHistories = new HashSet<SuggestionHistory>();
            this.ReportTimeSystems = new HashSet<ReportTimeSystem>();
        }
    
        public int employeeID { get; set; }
        public string employee_name { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> birth { get; set; }
        public Nullable<System.DateTime> hire_date { get; set; }
        public string account { get; set; }
        public Nullable<int> officeID { get; set; }
        public Nullable<int> departmentID { get; set; }
        public Nullable<int> positionID { get; set; }
        public Nullable<int> managerID { get; set; }
        public Nullable<bool> employed { get; set; }
        public Nullable<int> groupID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BulletinBoard> BulletinBoards { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        public virtual Group Group { get; set; }
        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingRoomHistory> MeetingRoomHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipient> Recipients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportMain> ReportMains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionHistory> SuggestionHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportTimeSystem> ReportTimeSystems { get; set; }
        public virtual Account Account1 { get; set; }
    }
}
