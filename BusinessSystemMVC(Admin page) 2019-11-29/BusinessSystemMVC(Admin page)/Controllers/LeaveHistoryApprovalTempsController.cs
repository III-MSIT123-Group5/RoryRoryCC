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
    public class LeaveHistoryApprovalTempsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: LeaveHistoryApprovalTemps
        public ActionResult Index()
        {
            //var leaveHistoryApprovalTemps = db.LeaveHistoryApprovalTemps.Include(l => l.Employee).Include(l => l.Employee1).Include(l => l.Employee2).Include(l => l.Employee3).Include(l => l.Employee4).Include(l => l.Employee5);
            return View(/*leaveHistoryApprovalTemps*/);
        }

        //載入申請中的假
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LeaveLoadData()
        {
            var q = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID).Select(p => new { p.ID  , p.Leave.leave_name , p.ReleaseTime,p.StartTime,p.EndTime,p.Status });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }


        // GET: LeaveHistoryApprovalTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(leaveHistoryApprovalTemp);
        }

        //新增請假
        // GET: LeaveHistoryApprovalTemps/Create
        public ActionResult Create()
        {


            ViewBag.leaveID = new SelectList(db.Leaves, "leaveID", "leave_name");

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.HREmployee = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.HRGroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }
        //新增請假
        // POST: LeaveHistoryApprovalTemps/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveHistoryApprovalTemp leaveHistoryApprovalTemp)
        {
            if (ModelState.IsValid)
            {


                db.LeaveHistoryApprovalTemps.Add(leaveHistoryApprovalTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.employeeID);
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.DepartmentLeader);
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GeneralManager);
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GroupLeader);
            ViewBag.HREmployee = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HREmployee);
            ViewBag.HRGroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HRGroupLeader);
            return View(leaveHistoryApprovalTemp);
        }

        // GET: LeaveHistoryApprovalTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.employeeID);
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.DepartmentLeader);
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GeneralManager);
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GroupLeader);
            ViewBag.HREmployee = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HREmployee);
            ViewBag.HRGroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HRGroupLeader);
            return View(leaveHistoryApprovalTemp);
        }

        // POST: LeaveHistoryApprovalTemps/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,employeeID,leaveID,StartTime,EndTime,Description,Appendix,GroupLeader,GroupLeaderSignTime,DepartmentLeader,DepartmentLeaderSignTime,GeneralManager,GeneralManagerSignTime,HREmployee,HREmployeeSignTime,HRGroupLeader,HRGroupLeaderSignTime,Status,SignState,Reject")] LeaveHistoryApprovalTemp leaveHistoryApprovalTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveHistoryApprovalTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.employeeID);
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.DepartmentLeader);
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GeneralManager);
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GroupLeader);
            ViewBag.HREmployee = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HREmployee);
            ViewBag.HRGroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.HRGroupLeader);
            return View(leaveHistoryApprovalTemp);
        }

        // GET: LeaveHistoryApprovalTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(leaveHistoryApprovalTemp);
        }

        // POST: LeaveHistoryApprovalTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            db.LeaveHistoryApprovalTemps.Remove(leaveHistoryApprovalTemp);
            db.SaveChanges();
            return RedirectToAction("Index");
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
