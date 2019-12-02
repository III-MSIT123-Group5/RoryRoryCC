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
            foreach (var a in q)
            {
                EmployeeDetail.Name = a.EmployeeName;
                EmployeeDetail.EmployeeID = a.employeeID;
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