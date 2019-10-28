using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIPBussinessSystem_MVC.Models
{
    public class BulletinBoardsViewModel
    {

        public long Num { get; set; }

        [Display(Name = "員工編號")]
        public Nullable<int> EmployeeID { get; set; }


        public Nullable<int> DepartmentID { get; set; }


        public Nullable<int> GroupID { get; set; }

        [Display(Name = "貼文內容")]
        public string Content { get; set; }

        [Display(Name = "發文時間")]
        public Nullable<System.DateTime> PostTime { get; set; }


    }
}