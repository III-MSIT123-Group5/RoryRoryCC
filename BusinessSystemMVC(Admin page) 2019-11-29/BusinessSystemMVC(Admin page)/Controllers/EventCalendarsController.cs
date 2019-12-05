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
    public class EventCalendarsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: EventCalendars
        public ActionResult Index()
        {
            var eventCalendars = db.EventCalendars.Include(e => e.Department).Include(e => e.Employee);
            return View(eventCalendars.ToList());
        }

        // GET: EventCalendars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            return View(eventCalendar);
        }

        // GET: EventCalendars/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name");
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }

        // POST: EventCalendars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalendarID,employeeID,Subject,DepartmentID,StartTime,EndTime,Location,Description,IsImportant,IsFullday")] EventCalendar eventCalendar)
        {
            if (ModelState.IsValid)
            {
                db.EventCalendars.Add(eventCalendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
            return View(eventCalendar);
        }

        // GET: EventCalendars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
            return View(eventCalendar);
        }

        // POST: EventCalendars/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendarID,employeeID,Subject,DepartmentID,StartTime,EndTime,Location,Description,IsImportant,IsFullday")] EventCalendar eventCalendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventCalendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
            return View(eventCalendar);
        }

        // GET: EventCalendars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            return View(eventCalendar);
        }

        // POST: EventCalendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            db.EventCalendars.Remove(eventCalendar);
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
