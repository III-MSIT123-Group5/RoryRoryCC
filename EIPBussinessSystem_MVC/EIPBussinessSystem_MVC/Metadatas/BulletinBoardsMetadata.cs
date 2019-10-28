using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIPBussinessSystem_MVC.Metadatas
{
    public class BulletinBoardsMetadata
    {
    
       [Display(Name = "貼文內容")]
       public string Content { get; set; }

       //[Display(Name = "張貼時間")]
       //public DateTime PostTime { get; set; }
    }
}