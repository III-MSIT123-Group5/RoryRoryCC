using EIPBussinessSystem_MVC.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIPBussinessSystem_MVC.Metadatas
{
    public class BulletinBoardsMetadata
    {

        public long Num { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resource1), ErrorMessageResourceName = "ProductNameEmpty")]

        [Display(Name = "EmployeeID", ResourceType = typeof(Resource1))]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "DepartmentID", ResourceType = typeof(Resource1))]
        public Nullable<int> DepartmentID { get; set; }

        [Display(Name = "GroupID", ResourceType = typeof(Resource1))]
        public Nullable<int> GroupID { get; set; }

        [Display(Name = "貼文內容", ResourceType = typeof(Resource1))]
        public string Content { get; set; }

        [Display(Name = "發文時間", ResourceType = typeof(Resource1))]
        public Nullable<System.DateTime> PostTime { get; set; }

        [Display(Name = "部門名稱", ResourceType = typeof(Resource1))]
        public string name { get; set; }

        [Display(Name = "組別名稱", ResourceType = typeof(Resource1))]
        public string GroupName { get; set; }
    }
}