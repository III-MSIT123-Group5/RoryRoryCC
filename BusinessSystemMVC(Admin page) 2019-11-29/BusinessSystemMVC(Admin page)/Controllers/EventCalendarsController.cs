using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using Microsoft.AspNet.Identity;

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

        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();

            var data = from ecal in db.EventCalendars
                       join emp in db.Employees
                       on ecal.employeeID equals emp.employeeID
                       join dep in db.Departments
                       on ecal.DepartmentID equals dep.departmentID
                       select ecal;

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.DepartmentID = new SelectList(db.Departments,"DepartmentID", "name");
            if (id == 0)
            {
                return View(new EventCalendar());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.EventCalendars.Where(x => x.CalendarID == id).FirstOrDefault<EventCalendar>());
                }
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(EventCalendar ecal)
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", ecal.employeeID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "name",ecal.DepartmentID);

            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                if (ecal.CalendarID == 0)
                {
                                        
                    db.EventCalendars.Add(new EventCalendar()
                    {
                        employeeID = EmployeeDetail.EmployeeID,
                        Subject = ecal.Subject,
                        DepartmentID =ecal.DepartmentID,
                        StartTime = ecal.StartTime,
                        EndTime = ecal.EndTime,
                        Location = ecal.Location,
                        Description = ecal.Description,
                        IsImportant = ecal.IsImportant,
                        ThemeColor = ecal.ThemeColor

                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    db.Entry(ecal).State = EntityState.Modified;
                    db.SaveChanges();

                    

                    return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
                }

            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                EventCalendar ca = db.EventCalendars.Where(x => x.employeeID == id).FirstOrDefault<EventCalendar>();
                db.EventCalendars.Remove(ca);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }

        [HttpGet]
        public JsonResult Getevent()
        {
            BusinessDataBaseEntities db = new BusinessDataBaseEntities();
            
            var events = db.EventCalendars.AsEnumerable().Select(n=>new {n.CalendarID,n.employeeID, n.Subject,n.DepartmentID,StartTime = n.StartTime.ToString("yyyy-MM-dd hh:ss"),EndTime= n.EndTime.ToString("yyyy-MM-dd hh:ss"),n.Location,n.Description,n.IsImportant,n.ThemeColor }).ToList();
            //return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            return Json(events, JsonRequestBehavior.AllowGet);

        }

        //    // GET: EventCalendars/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name");
        //        ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
        //        return View();
        //    }








        //    // POST: EventCalendars/Create
        //    // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //    // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "CalendarID,employeeID,Subject,DepartmentID,StartTime,EndTime,Location,Description,IsImportant,IsFullday")] EventCalendar eventCalendar)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.EventCalendars.Add(eventCalendar);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
        //        ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
        //        return View(eventCalendar);
        //    }






        //    // GET: EventCalendars/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        EventCalendar eventCalendar = db.EventCalendars.Find(id);
        //        if (eventCalendar == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
        //        ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
        //        return View(eventCalendar);
        //    }

        //    // POST: EventCalendars/Edit/5
        //    // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //    // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "CalendarID,employeeID,Subject,DepartmentID,StartTime,EndTime,Location,Description,IsImportant,IsFullday")] EventCalendar eventCalendar)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(eventCalendar).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", eventCalendar.DepartmentID);
        //        ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", eventCalendar.employeeID);
        //        return View(eventCalendar);
        //    }

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
