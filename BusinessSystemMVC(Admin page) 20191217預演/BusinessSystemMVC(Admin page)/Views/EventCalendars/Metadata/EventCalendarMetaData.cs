using BusinessSystemMVC_Admin_page_.Views.EventCalendars.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.Models
{
    public class EventCalendarMetaData
    {
        public int CalendarID { get; set; }
                
        public int employeeID { get; set; }

        [Required(ErrorMessageResourceName = "Subject", ErrorMessageResourceType = typeof(Resource1))]
        [Display(Name = "Subject", ResourceType = typeof(Resource1))]
        [StringLength(10, ErrorMessage = "{0}最多{1}個字")]
        public string Subject { get; set; }

        [Display(Name = "DepartmentID", ResourceType = typeof(Resource1))]
        public Nullable<int> DepartmentID { get; set; }


        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm aa}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "StartTime", ResourceType = typeof(Resource1))]
        public System.DateTime StartTime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm aa}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "請輸入{0}")]
        [Display(Name = "EndTime", ResourceType = typeof(Resource1))]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "Location", ResourceType = typeof(Resource1))]
        [StringLength(10, ErrorMessage = "{0}最多{1}個字")]
        public string Location { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resource1))]
        [StringLength(10, ErrorMessage = "{0}最多{1}個字")]
        public string Description { get; set; }

        [Display(Name = "IsImportant", ResourceType = typeof(Resource1))]
        public bool IsImportant { get; set; }

        [Display(Name = "ThemeColor", ResourceType = typeof(Resource1))]
        public string ThemeColor { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }

    }
}

