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
    
    public partial class CompanyVehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyVehicle()
        {
            this.CompanyVehicleHistories = new HashSet<CompanyVehicleHistory>();
        }
    
        public string LicenseNumber { get; set; }
        public int VehicleYear { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string brand { get; set; }
        public string serial { get; set; }
        public string MaxPassenger { get; set; }
        public int officeID { get; set; }
        public byte[] VehiclePhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyVehicleHistory> CompanyVehicleHistories { get; set; }
        public virtual Office Office { get; set; }
    }
}
