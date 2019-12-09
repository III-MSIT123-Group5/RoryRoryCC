using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using BusinessSystemMVC_Admin_page_.ViewModels;

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
            int ThisYear = DateTime.Now.Year;
            List<int> SYList = new List<int>();
            List<int> SMList = new List<int>();
            List<int> SDList = new List<int>();
            List<int> SHList = new List<int>();
            List<int> EYList = new List<int>();
            List<int> EMList = new List<int>();
            List<int> EDList = new List<int>();
            List<int> EHList = new List<int>();
            for(int i = ThisYear-1 ; i<= ThisYear+1; i++)
            {
                SYList.Add(i);
                EYList.Add(i);
            }
            for (int i = 1 ; i <= 12; i++)
            {
                SMList.Add(i);
                EMList.Add(i);
            }
            for (int i = 1 ; i <= 31; i++)
            {
                SDList.Add(i);
                EDList.Add(i);
            }
            for (int i = 9; i <= 17; i++)
            {
                SHList.Add(i);
                EHList.Add(i);
            }
            ViewBag.leaveID = new SelectList(db.Leaves, "leaveID", "leave_name");
            ViewBag.StartYear = new SelectList(SYList.Select(p => new { SYtxt = p.ToString(), SYval = p }), "SYval", "SYtxt");
            ViewBag.StartMonth = new SelectList(SMList.Select(p => new { SMtxt = p.ToString(), SMval = p }), "SMval", "SMtxt");
            ViewBag.StartDay = new SelectList(SDList.Select(p => new { SDtxt = p.ToString(), SDval = p }), "SDval", "SDtxt");
            ViewBag.StartHour = new SelectList(SHList.Select(p => new { SHtxt = p.ToString(), SHval = p }), "SHval", "SHtxt");
            ViewBag.EndYear = new SelectList(EYList.Select(p => new { EYtxt = p.ToString(), EYval = p }), "EYval", "EYtxt");
            ViewBag.EndMonth = new SelectList(EMList.Select(p => new { EMtxt = p.ToString(), EMval = p }), "EMval", "EMtxt");
            ViewBag.EndDay = new SelectList(EDList.Select(p => new { EDtxt = p.ToString(), EDval = p }), "EDval", "EDtxt");
            ViewBag.EndHour = new SelectList(EHList.Select(p => new { EHtxt = p.ToString(), EHval = p }), "EHval", "EHtxt");

            return View();
        }
        //新增請假
        // POST: LeaveHistoryApprovalTemps/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveHistoryApprovalTempViewModel leaveHistoryApprovalTemp)
        {
            if (ModelState.IsValid)
            {


              
                return RedirectToAction("Index");
            }

           
            return View(leaveHistoryApprovalTemp);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetNewYearTime()
        {
            DateTime dt = DateTime.Now.AddDays(3);
            List<int> L = new List<int>();
          for(int i = dt.Year; i <= dt.Year + 1; i++)
            {
                L.Add(i);
            }
            var q = L.Select(p => new { tx = p.ToString(), va = p });
            return Json(q, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult GetNewMonthTime(int thisYEAR)
        {
            DateTime dt = DateTime.Now.AddDays(3);
            List<int> List = new List<int>();
            if(thisYEAR == dt.Year)
            {
                for (int i = dt.Month; i <= 12; i++)
                {
                    List.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    List.Add(i);
                }
            }
            return Json(List.Select(p => new { Txt = p.ToString(), Val = p }), JsonRequestBehavior.AllowGet);
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
