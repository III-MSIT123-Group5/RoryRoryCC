using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.ViewModels
{
    public class CompanyVehicleViewModel
    {
        public string LiNM { get; set; }
        public int Vyear { get; set; }
        public DateTime Purtime { get; set; }
        public string brand1 { get; set; }
        public string serial { get; set; }
        public string MaxPassenger { get; set; }
        public int officeID { get; set; }
        //public HttpPostedFileBase PhotoCar { get; set; }

    }
}