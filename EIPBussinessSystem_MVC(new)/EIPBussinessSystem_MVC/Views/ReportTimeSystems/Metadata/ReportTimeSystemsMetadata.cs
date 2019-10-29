using EIPBussinessSystem_MVC.Views.ReportTimeSystems.Metadata;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EIPBussinessSystem_MVC.Models
{
    public class ReportTimeSystemsMetadata
    {
        
        public int ReportID { get; set; }

        [Required(ErrorMessageResourceName = "ReportNameEmpty", ErrorMessageResourceType =typeof(Resource1))]
        [Display(Name ="ReportName",ResourceType = typeof(Resource1))]
        [StringLength(10,ErrorMessage ="{0}最多{1}個字")]
        public string ReportName { get; set; }

        [Display(Name = "EmployeeName")]
        public int employeeID { get;}

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "StartTime")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd tt hh:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime StartTime { get; set; }

        
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "EndTime")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd tt hh:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime EndTime { get; set; }

        
        public double EventHours { get; set; }

        public int EventID { get; set; }
        public string Note { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "送出表單時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd tt hh:mm}",ApplyFormatInEditMode =true)]
        public System.DateTime ApplyDateTime { get; set; }
        public Nullable<bool> Discontinue { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Event Event { get; set; }
    }
}