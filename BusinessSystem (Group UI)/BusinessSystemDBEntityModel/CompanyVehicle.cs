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
    
    public partial class CompanyVehicle
    {
        public string license_number { get; set; }
        public string brand { get; set; }
        public string serial { get; set; }
        public string max_passenger { get; set; }
        public Nullable<int> officeID { get; set; }
    
        public virtual Office Office { get; set; }
    }
}