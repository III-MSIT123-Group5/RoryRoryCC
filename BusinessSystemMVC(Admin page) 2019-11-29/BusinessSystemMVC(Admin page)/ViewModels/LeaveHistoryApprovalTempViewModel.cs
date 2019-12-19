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
        public IEnumerable<HttpPostedFileBase> AppendixFile { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int StartHour { get; set; }
        [Required]
        public int EndHour { get; set; }
    }
}