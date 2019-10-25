using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class ReportTimeSystemsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: ReportTimeSystems
        public ActionResult Index()
        {
            //var reportTimeSystems = db.ReportTimeSystems.Include(r => r.Employee).Include(r => r.Event);
            var reportTimeSystems = from RTS in db.ReportTimeSystems
                                    join emp in db.Employees
                                    on RTS.employeeID equals emp.employeeID
                                    join eve in db.Events
                                    on RTS.EventID equals eve.EventID
                                    where RTS.Discontinue == true //&& RTS.employeeID == ClassEmployee.LoginEmployeeID
                                    select RTS;


            return View(reportTimeSystems);
        }

        // GET: ReportTimeSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTimeSystem reportTimeSystem = db.ReportTimeSystems.Find(id);
            if (reportTimeSystem == null)
            {
                return HttpNotFound();
            }
            return View(reportTimeSystem);
        }

        // GET: ReportTimeSystems/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: ReportTimeSystems/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,ReportName,employeeID,StartTime,EndTime,EventHours,EventID,Note,ApplyDateTime,Discontinue")] ReportTimeSystem reportTimeSystem)
        {
            if (ModelState.IsValid)
            {
                db.ReportTimeSystems.Add(reportTimeSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", reportTimeSystem.employeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reportTimeSystem.EventID);
            return View(reportTimeSystem);
        }

        // GET: ReportTimeSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTimeSystem reportTimeSystem = db.ReportTimeSystems.Find(id);
            if (reportTimeSystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", reportTimeSystem.employeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reportTimeSystem.EventID);
            return View(reportTimeSystem);
        }

        // POST: ReportTimeSystems/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,ReportName,employeeID,StartTime,EndTime,EventHours,EventID,Note,ApplyDateTime,Discontinue")] ReportTimeSystem reportTimeSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportTimeSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", reportTimeSystem.employeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reportTimeSystem.EventID);
            return View(reportTimeSystem);
        }

        // GET: ReportTimeSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportTimeSystem reportTimeSystem = db.ReportTimeSystems.Find(id);
            if (reportTimeSystem == null)
            {
                return HttpNotFound();
            }
            return View(reportTimeSystem);
        }

        // POST: ReportTimeSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportTimeSystem reportTimeSystem = db.ReportTimeSystems.Find(id);
            db.ReportTimeSystems.Remove(reportTimeSystem);
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
