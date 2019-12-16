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
    public class EmployeeApprovalTempsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: EmployeeApprovalTemps
        public ActionResult Index()
        {
            //var employeeApprovalTemps = db.EmployeeApprovalTemps.Include(e => e.Employee).Include(e => e.Employee1).Include(e => e.Employee2);
            return View(/*employeeApprovalTemps*/);
        }

 


        //HR簽核LoadData
        [HttpGet]
        [Authorize(Roles = "HRLeaders")]
        public ActionResult LoadData()
        {
            // ((p.Employee1.ManagerID == EmployeeDetail.EmployeeID && p.GroupLeaderID ==null )|| (p.Employee2.ManagerID == EmployeeDetail.EmployeeID && p.DepartmentLeaderID==null))
            var q = db.EmployeeApprovalTemps.Where(p => p.SignState == false).Select(p => new { p.EmployeeName, p.Gender, p.Account, p.Department.name, p.Group.GroupName, p.Position.position1, p.EditorTime, p.ID, p.GroupLeaderID, p.DepartmentLeaderID });
            if (EmployeeDetail.PositionID == 3 && EmployeeDetail.GroupID == 2)
            {
                q = q.Where(p => p.GroupLeaderID == null && p.DepartmentLeaderID == null).Select(p => p);
            }
            if (EmployeeDetail.PositionID == 2 && EmployeeDetail.DepartmentID == 3)
            {
                q = q.Where(p => p.GroupLeaderID != null && p.DepartmentLeaderID == null).Select(p => p);
            }

            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "GroupLeader,DepartmentLeader,HRGroup")]
        public ActionResult LoadDataDetail(int ID)
        {
            return View(db.EmployeeApprovalTemps.Where(p => p.ID == ID).FirstOrDefault());
        }

        [HttpPost]
        [Authorize(Roles = "GroupLeader,DepartmentLeader,HRGroup")]
        public ActionResult AcceptRegister(int ID)
        {
            var q = db.EmployeeApprovalTemps.Find(ID);
            //for組長
            if (q.GroupLeaderID == null && q.SignState == false && q.Rejection == false && EmployeeDetail.GroupID == 2 && EmployeeDetail.PositionID == 3)
            {
                q.GroupLeaderID = EmployeeDetail.EmployeeID;
                q.GroupLeaderSignTime = DateTime.Now;
                q.StatusDescript = "待部長簽核";
                db.SaveChanges();
            }

            //for部長
            if (q.GroupLeaderID != null && q.DepartmentLeaderID == null && q.SignState == false && q.Rejection == false && EmployeeDetail.DepartmentID == 3 && EmployeeDetail.PositionID == 2)
            {
                q.DepartmentLeaderID = EmployeeDetail.EmployeeID;
                q.DepartmentLeaderSignTime = DateTime.Now;
                db.SaveChanges();
            }

            //都簽了且為核准
            if (q.SignState == false && q.GroupLeaderID != null && q.DepartmentLeaderID != null && q.Rejection == false)
            {
                q.SignState = true;
                q.Rejection = false;
                q.StatusDescript = "簽核完成";
                var addFormalEmployee = new Employee
                {
                    EmployeeName = q.EmployeeName,
                    Gender = q.Gender,
                    Birth = q.Birth,
                    HireDate = q.HireDate,
                    Account = q.Account,
                    OfficeID = q.OfficeID,
                    DepartmentID = q.DepartmentID,
                    PositionID = q.PositionID,
                    ManagerID = q.ManagerID,
                    Employed = true,
                    GroupID = q.GroupID,
                    Photo = q.Photo,
                    SpecialLeaveHours = 49 , //hours
                    PersonalLeaveHours = 98 ,
                    SickLeaveHours = 210
                };
                db.Employees.Add(addFormalEmployee);                
                db.SaveChanges();
            }
            return Json(new { success = true, message = "簽核成功" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RejectRegister(int ID)
        {
            var q = db.EmployeeApprovalTemps.Find(ID);
            //for組長
            if (q.GroupLeaderID == null && q.SignState == false && q.Rejection == false && EmployeeDetail.GroupID == 2 && EmployeeDetail.PositionID == 3)
            {
                q.GroupLeaderID = EmployeeDetail.EmployeeID;
                q.GroupLeaderSignTime = DateTime.Now;
                q.Rejection = true;
                q.StatusDescript = "已遭組長駁回";
                db.SaveChanges();
            }

            //for部長
            if (q.GroupLeaderID != null && q.DepartmentLeaderID == null && q.SignState == false && q.Rejection == false && EmployeeDetail.DepartmentID == 3 && EmployeeDetail.PositionID == 2)
            {
                q.DepartmentLeaderID = EmployeeDetail.EmployeeID;
                q.DepartmentLeaderSignTime = DateTime.Now;
                q.Rejection = true;
                q.StatusDescript = "已遭部長駁回";
                db.SaveChanges();
            }
            return Json(new { success = true, message = "簽核已駁回" }, JsonRequestBehavior.AllowGet);
        }

        //簽核進度
        [HttpGet]
        [Authorize(Roles = "HRGroup")]
        public ActionResult RegistingLoadData()
        {
            var q = db.EmployeeApprovalTemps.Where(p => p.Editor == EmployeeDetail.EmployeeID && p.Rejection == false).Select(p => new { p.EmployeeName, p.Gender, p.Account, p.Department.name, p.Group.GroupName, p.Position.position1, p.EditorTime, p.StatusDescript });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //Reject項目
        [HttpGet]
        [Authorize(Roles = "HRGroup")]
        public ActionResult RejectLoadData()
        {
            var q = db.EmployeeApprovalTemps.Where(p => p.Editor == EmployeeDetail.EmployeeID && p.Rejection == true).Select(p => new { p.EmployeeName, p.Gender, p.Account, p.Department.name, p.Group.GroupName, p.Position.position1, p.EditorTime, p.StatusDescript, p.ID });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //Reject項目Detail
        [HttpGet]
        [Authorize(Roles = "HRGroup")]
        public ActionResult RejectLoadDataDetail(int ID)
        {
            var q = db.EmployeeApprovalTemps.Find(ID);
            if (q.DepartmentLeaderID == null && q.GroupLeaderID != null)
            {
                q.DepartmentLeaderID = q.GroupLeaderID;
                q.DepartmentLeaderSignTime = q.GroupLeaderSignTime;
            }
            return View(q);
        }

       

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
