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
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        public ActionResult Index()
        {
            string person = User.Identity.GetUserId();
            var acc = db.AspNetUsers.Find(person);
            var q = db.Employees.Where(p => p.Account == acc.UserName).Select(p => p);

            if(q == null)
            {
                return RedirectToAction("UnCreate", "Account");
            }

            foreach (var a in q)
            {
                EmployeeDetail.Name = a.EmployeeName;
                EmployeeDetail.EmployeeID = a.employeeID;
                EmployeeDetail.Account = a.Account;
                EmployeeDetail.Gender = a.Gender;
                EmployeeDetail.BirthDay = (DateTime)a.Birth;
                EmployeeDetail.HireDay = (DateTime)a.HireDate;
                EmployeeDetail.OfficeName = a.Office.office_name;
                EmployeeDetail.OfficeID = (int)a.OfficeID;
                EmployeeDetail.DepartmentName = a.Department.name;
                EmployeeDetail.DepartmentID = (int)a.DepartmentID;
                EmployeeDetail.ManagerName = a.Employee2.EmployeeName;
                EmployeeDetail.ManagerID = (int)a.ManagerID;
                EmployeeDetail.Employed = (bool)a.Employed;
                EmployeeDetail.PhotoAdress = a.Photo;
                EmployeeDetail.GroupName = a.Group.GroupName;
                EmployeeDetail.GroupID = (int)a.GroupID;
                EmployeeDetail.PositionName = a.Position.position1;
                EmployeeDetail.PositionID = (int)a.PositionID;
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

        public ActionResult GetEmpID()
        {
            var userid = User.Identity.GetUserId();
            var account = db.AspNetUsers.Find(userid);

            var empquery = from em in db.Employees
                           where em.Account == account.UserName
                           select new
                           {
                               em.employeeID,
                               em.EmployeeName
                           };

            //string EmpName;
            //int EmpID = 0;
            //foreach (var e in empquery)
            //{
            //    EmpID = e.employeeID;
            //    EmpName = e.EmployeeName;
            //}

            var datas = empquery.ToList();

            return Json(new {data = datas }, JsonRequestBehavior.AllowGet);

        }
    }
}