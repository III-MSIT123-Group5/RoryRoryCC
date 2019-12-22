
using BusinessSystemMVC_Admin_page_.Views.ReportTimeSystems.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessSystemMVC_Admin_page_.Models
{
    public class ReportTimeSystemsMetadata
    {
        
        public int ReportID { get; set; }

        [Required(ErrorMessageResourceName = "ReportNameEmpty", ErrorMessageResourceType =typeof(Resource1))]
        [Display(Name ="ReportName",ResourceType = typeof(Resource1))]
        [StringLength(10,ErrorMessage ="{0}最多{1}個字")]
        public string ReportName { get; set; }

        
        public int employeeID { get;}

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "StartTime", ResourceType = typeof(Resource1))]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime StartTime { get; set; }

        
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "EndTime", ResourceType = typeof(Resource1))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "EventHours", ResourceType = typeof(Resource1))]
        public double EventHours { get; set; }

        [Display(Name = "EventID", ResourceType = typeof(Resource1))]
        public int EventID { get; set; }


        [Display(Name = "Note", ResourceType = typeof(Resource1))]
        [StringLength(500, ErrorMessage = "{0}最多{1}個字")]
        public string Note { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "ApplyDateTime", ResourceType = typeof(Resource1))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}",ApplyFormatInEditMode =true)]
        public System.DateTime ApplyDateTime { get; set; }


        public Nullable<bool> Discontinue { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Event Event { get; set; }

        

    }
}