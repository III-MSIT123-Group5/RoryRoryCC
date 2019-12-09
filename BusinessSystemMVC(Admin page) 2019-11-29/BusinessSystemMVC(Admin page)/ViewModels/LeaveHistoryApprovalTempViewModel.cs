using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.ViewModels
{
    public class LeaveHistoryApprovalTempViewModel
    {
        [Required]
        public int leaveID { get; set; }
        public string Description { get; set; }
        public string Appendix { get; set; }
        [Required]
        public int StartYear { get; set; }
        [Required]
        public int StartMonth { get; set; }
        [Required]
        public int StartDay { get; set; }
        [Required]
        public int StartHour { get; set; }
        [Required]
        public int EndYear { get; set; }
        [Required]
        public int EndMonth { get; set; }
        [Required]
        public int EndDay { get; set; }
        [Required]
        public int EndHour { get; set; }
    }
}