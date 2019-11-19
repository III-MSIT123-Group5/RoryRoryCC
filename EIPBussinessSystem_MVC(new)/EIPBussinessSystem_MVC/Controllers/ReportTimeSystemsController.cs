using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class ReportTimeSystemsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: ReportTimeSystems
        public ActionResult Index()
        {
            //var UserID = User.Identity.GetUserId();
            //var Acc = db.AspNetUsers.Find(UserID);
            //var Empquery = db.Employees.Where(f => f.Account.Equals(Acc.UserName)).Select(f => new { f.employeeID });
            //int EmpID = 0;
            //foreach (var e in Empquery)
            //{
            //    EmpID = e.employeeID;
            //}
            //var reportTimeSystems = db.ReportTimeSystems.Include(r => r.Employee).Include(r => r.Event);
            var reportTimeSystems = from RTS in db.ReportTimeSystems
                                    join emp in db.Employees
                                    on RTS.employeeID equals emp.employeeID
                                    join eve in db.Events
                                    on RTS.EventID equals eve.EventID
                                    orderby RTS.ReportID
                                    where RTS.Discontinue == true && RTS.employeeID == 1032
                                    select RTS;
            reportTimeSystems = reportTimeSystems.OrderByDescending(rt => rt.ReportID);

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
        public ActionResult Create(/*[Bind(Include = "ReportID,ReportName,employeeID,StartTime,EndTime,EventID,Note")] */ReportTimeSystem reportTimeSystem)
        {
            if (ModelState.IsValid)
            {
                var UserID = User.Identity.GetUserId();
                var Acc = db.AspNetUsers.Find(UserID);
                var Empquery = db.Employees.Where(f => f.Account.Equals(Acc.UserName)).Select(f => new { f.employeeID });
                int EmpID = 0;
                foreach (var e in Empquery)
                {
                    EmpID = e.employeeID;
                }

                db.ReportTimeSystems.Add(new Models.ReportTimeSystem
                {
                    ReportName = reportTimeSystem.ReportName,
                    employeeID = EmpID,
                    ApplyDateTime = DateTime.Now,
                    StartTime = reportTimeSystem.StartTime,
                    EndTime = reportTimeSystem.EndTime,
                    EventHours = (reportTimeSystem.EndTime - reportTimeSystem.StartTime).Hours,
                    EventID = reportTimeSystem.EventID,
                    Note = reportTimeSystem.Note,
                    Discontinue = true
                });
                db.SaveChanges();


            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", reportTimeSystem.employeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reportTimeSystem.EventID);
            /*return View(reportTimeSystem);*/
            return RedirectToAction("Index");
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
        public ActionResult Edit([Bind(Include = "ReportID,ReportName,employeeID,StartTime,EndTime,EventID,Note")]ReportTimeSystem reportTimeSystem)
        {
            var q = (reportTimeSystem.EndTime.Subtract(reportTimeSystem.StartTime)).TotalHours;
            var UserID = User.Identity.GetUserId();
            var Acc = db.AspNetUsers.Find(UserID);
            var Empquery = db.Employees.Where(f => f.Account.Equals(Acc.UserName)).Select(f => new { f.employeeID });
            //int EmpID = 0;
            //foreach (var e in Empquery)
            //{
            //    EmpID = e.employeeID;
            //}

            if (ModelState.IsValid)
            {
                reportTimeSystem.employeeID = 1032;
                reportTimeSystem.EventHours = q;
                reportTimeSystem.Discontinue = true;
                reportTimeSystem.ApplyDateTime = DateTime.Now;

                db.Entry(reportTimeSystem).State = EntityState.Modified;
                db.SaveChanges();
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", reportTimeSystem.employeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", reportTimeSystem.EventID);
            //return View(reportTimeSystem);
            return RedirectToAction("Index");
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
