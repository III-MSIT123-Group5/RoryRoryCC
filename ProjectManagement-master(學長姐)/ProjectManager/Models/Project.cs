//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.Document = new HashSet<Document>();
            this.Meeting = new HashSet<Meeting>();
            this.ProjectMembers = new HashSet<ProjectMembers>();
            this.Tasks = new HashSet<Tasks>();
            this.Department2 = new HashSet<Department>();
        }
    
        public string ProjectID { get; set; }
        public System.Guid ProjectGUID { get; set; }
        public Nullable<System.Guid> RequiredDeptGUID { get; set; }
        public Nullable<System.Guid> RequiredDeptPMGUID { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> EstStartDate { get; set; }
        public Nullable<System.DateTime> EstEndDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.Guid InChargeDeptGUID { get; set; }
        public Nullable<System.Guid> InChargeDeptPMGUID { get; set; }
        public Nullable<int> ProjectStatusID { get; set; }
        public Nullable<int> ProjectCategoryID { get; set; }
        public Nullable<System.Guid> ProjectSupervisorGUID { get; set; }
        public Nullable<bool> IsGeneralManagerConcerned { get; set; }
        public Nullable<int> ProjectBudget { get; set; }
        public string Description { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Department Department1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Document { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Department2 { get; set; }
    }
}
