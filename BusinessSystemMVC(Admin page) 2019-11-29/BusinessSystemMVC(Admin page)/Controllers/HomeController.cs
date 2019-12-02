using BusinessSystemMVC_Admin_page_.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class HomeController : Controller
    {
        BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        public ActionResult Index()
        {
            string person = User.Identity.GetUserId();
            var acc = db.AspNetUsers.Find(person);
            var q = db.Employees.Where(p => p.Account == acc.UserName).Select(p => p);
            foreach (var a in q)
            {
                EmployeeDetail.Name = a.EmployeeName;
                EmployeeDetail.EmployeeID = a.employeeID;
                EmployeeDetail.Account = a.Account;
                EmployeeDetail.Gender = a.Gender;
                EmployeeDetail.BirthDay = (DateTime)a.Birth;
                EmployeeDetail.HireDay = (DateTime)a.HireDate;
                EmployeeDetail.OfficeName = a.Office.office_name;
                EmployeeDetail.DepartmentName = a.Department.name;
                EmployeeDetail.ManagerName = a.Employee2.EmployeeName;
                EmployeeDetail.Employed = (bool)a.Employed;
                EmployeeDetail.PhotoAdress = a.Photo;
                EmployeeDetail.GroupName = a.Group.GroupName;
                EmployeeDetail.PositionName = a.Position.position1;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}