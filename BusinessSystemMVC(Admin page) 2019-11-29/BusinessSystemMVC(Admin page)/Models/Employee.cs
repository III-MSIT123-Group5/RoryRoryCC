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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.ActivitiesChilds = new HashSet<ActivitiesChild>();
            this.ActivitiesMains = new HashSet<ActivitiesMain>();
            this.BulletinBoards = new HashSet<BulletinBoard>();
            this.BulletinBoards1 = new HashSet<BulletinBoard>();
            this.CommentChilds = new HashSet<CommentChild>();
            this.CommentMains = new HashSet<CommentMain>();
            this.CompanyVehicleHistories = new HashSet<CompanyVehicleHistory>();
            this.Employee1 = new HashSet<Employee>();
            this.EmployeeApprovalTemps = new HashSet<EmployeeApprovalTemp>();
            this.EmployeeApprovalTemps1 = new HashSet<EmployeeApprovalTemp>();
            this.EmployeeApprovalTemps2 = new HashSet<EmployeeApprovalTemp>();
            this.EmployeeApprovalTemps3 = new HashSet<EmployeeApprovalTemp>();
            this.EventCalendars = new HashSet<EventCalendar>();
            this.Files = new HashSet<File>();
            this.LeaveHistories = new HashSet<LeaveHistory>();
            this.LeaveHistoryApprovalTemps = new HashSet<LeaveHistoryApprovalTemp>();
            this.LeaveHistoryApprovalTemps1 = new HashSet<LeaveHistoryApprovalTemp>();
            this.LeaveHistoryApprovalTemps2 = new HashSet<LeaveHistoryApprovalTemp>();
            this.LeaveHistoryApprovalTemps3 = new HashSet<LeaveHistoryApprovalTemp>();
            this.LeaveHistoryApprovalTemps4 = new HashSet<LeaveHistoryApprovalTemp>();
            this.LeaveHistoryApprovalTemps5 = new HashSet<LeaveHistoryApprovalTemp>();
            this.MeetingRoomHistories = new HashSet<MeetingRoomHistory>();
            this.Messages = new HashSet<Message>();
            this.Recipients = new HashSet<Recipient>();
            this.Replies = new HashSet<Reply>();
            this.ReportTimeSystems = new HashSet<ReportTimeSystem>();
            this.RequisitionMains = new HashSet<RequisitionMain>();
            this.SuggestionHistories = new HashSet<SuggestionHistory>();
        }
    
        public int employeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> Birth { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Account { get; set; }
        public Nullable<int> OfficeID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<bool> Employed { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string Photo { get; set; }
        public Nullable<int> SpecialLeaveHours { get; set; }
        public Nullable<int> PersonalLeaveHours { get; set; }
        public Nullable<int> SickLeaveHours { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivitiesChild> ActivitiesChilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivitiesMain> ActivitiesMains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BulletinBoard> BulletinBoards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BulletinBoard> BulletinBoards1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentChild> CommentChilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentMain> CommentMains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyVehicleHistory> CompanyVehicleHistories { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        public virtual Group Group { get; set; }
        public virtual Office Office { get; set; }
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeApprovalTemp> EmployeeApprovalTemps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeApprovalTemp> EmployeeApprovalTemps1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeApprovalTemp> EmployeeApprovalTemps2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeApprovalTemp> EmployeeApprovalTemps3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventCalendar> EventCalendars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistory> LeaveHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeaveHistoryApprovalTemp> LeaveHistoryApprovalTemps5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingRoomHistory> MeetingRoomHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipient> Recipients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportTimeSystem> ReportTimeSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionMain> RequisitionMains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionHistory> SuggestionHistories { get; set; }
    }
}
