using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIPBussinessSystem_MVC.ViewModels
{
    public class CreateBulletinBoardsViewModel
    {

        [Display(Name = "貼文內容")]
        public string Content { get; set; }

        [Display(Name = "發文時間")]
        public DateTime PostTime { get; set; }

    }
}