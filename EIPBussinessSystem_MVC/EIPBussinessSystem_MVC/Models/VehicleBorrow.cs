using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIPBussinessSystem_MVC.Models
{

    
    public class VehicleBorrow
    {
        [Required(ErrorMessage ="State required")]
        public SelectList vehicle { get; set; }
        public SelectList vehicletime { get; set; }
    }
}