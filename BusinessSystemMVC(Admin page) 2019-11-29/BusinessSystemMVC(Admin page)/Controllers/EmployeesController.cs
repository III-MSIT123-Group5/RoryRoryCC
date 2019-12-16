using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class EmployeesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: Employees
        public ActionResult Index()
        {
           return View();
        }

        //編輯Employee LoadData
        [HttpGet]
        [Authorize(Roles = "HRGroup")]
        public ActionResult EditLoadData()
        {
            var datas = db.Employees.Where(p => p.employeeID != 1022).Select(p => new { p.employeeID, p.EmployeeName, p.Account, p.Department.name, p.Group.GroupName, p.Position.position1, ManagerName = p.Employee2.EmployeeName }).ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //todo編輯Employee EditLoadDataDetail
        [HttpGet]
        [AllowAnonymous]
        public ActionResult EditLoadDataDetail(int ID)
        {
            var q = db.Employees.Where(p => p.employeeID == ID).FirstOrDefault();
            return View();
        }

    }
}
