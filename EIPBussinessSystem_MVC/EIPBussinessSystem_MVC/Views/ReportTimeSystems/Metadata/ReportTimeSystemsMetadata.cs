using EIPBussinessSystem_MVC.Views.ReportTimeSystems.Metadata;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EIPBussinessSystem_MVC.Models
{
    public class ReportTimeSystemsMetadata
    {
        
        public int ReportID { get; set; }

        [Required(ErrorMessageResourceName = "ReportNameEmpty", ErrorMessageResourceType =typeof(Resource1),AllowEmptyStrings =false)]
        [Display(Name ="ReportName",ResourceType = typeof(Resource1))]
        [StringLength(10,ErrorMessage ="{0}最多{1}個字")]
        public string ReportName { get; set; }

        [Display(Name = "EmployeeName")]
        public int employeeID { get;}

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "開始時間")]
        [DisplayFormat(DataFormatString ="{yyyy-MM-dd hh:mm}")]
        public System.DateTime StartTime { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "結束時間")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd hh:mm}")]
        public System.DateTime EndTime { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "結束時間")]
        [DisplayFormat(DataFormatString = "{2:f}")]
        public double EventHours { get; set; }

        public int EventID { get; set; }
        public string Note { get; set; }
        public System.DateTime ApplyDateTime { get; set; }
        public Nullable<bool> Discontinue { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Event Event { get; set; }
    }
}