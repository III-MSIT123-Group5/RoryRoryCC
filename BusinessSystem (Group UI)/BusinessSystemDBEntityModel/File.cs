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
    
    public partial class File
    {
        public long FileID { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime UploadDate { get; set; }
        public string Data { get; set; }
        public string Extension { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
