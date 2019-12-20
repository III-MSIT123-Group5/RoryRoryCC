using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSystemMVC_Admin_page_.ViewModels
{
    public class CompanyVehicleViewModel
    {
        public string LicenseNumber { get; set; }
        public int VehicleYear { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string brand { get; set; }
        public string serial { get; set; }
        public string MaxPassenger { get; set; }
        public int officeID { get; set; }
        public HttpPostedFileBase PhotoCar { get; set; }
    }
}