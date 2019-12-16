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
    public class ReportTimeSystemsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: ReportTimeSystems
        public ActionResult Index()
        {
            var reportTimeSystems = db.ReportTimeSystems.Include(e => e.Event).Include(e => e.Employee);

            return View(reportTimeSystems);
        }

        public ActionResult LoadData()
        {
            var datas = db.ReportTimeSystems.AsEnumerable().Select(n => new
            {
                n.ReportID,
                n.ReportName,
                n.employeeID,
                ApplyDateTime=n.ApplyDateTime.ToString("yyyy-MM-dd hh:ss"),
                StartTime = n.StartTime.ToString("yyyy-MM-dd hh:ss"),
                EndTime = n.EndTime.ToString("yyyy-MM-dd hh:ss"),
                n.EventHours,
                n.EventID,
                n.Note,
                n.Discontinue
            }).Where(n => n.employeeID == EmployeeDetail.EmployeeID).ToList();
            //var data = from r in db.ReportTimeSystems
            //           join emp in db.Employees
            //           on r.employeeID equals emp.employeeID
            //           join eve in db.Events
            //           on r.EventID equals eve.EventID
            //           where r.employeeID == EmployeeDetail.EmployeeID
            //           select new {
            //               ReportName = r.ReportName,
            //               employeeID = r.employeeID,
            //               ApplyDateTime = DateTime.Now,
            //               StartTime = r.StartTime,
            //               EndTime = r.EndTime,
            //               EventHours = r.EventHours,
            //               EventID = r.EventID,
            //               Note = r.Note,
            //               Discontinue = r.Discontinue

            //           };

            //var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.eventID = new SelectList(db.Events, "eventID", "EventName");
            if (id == 0)
            {
                return View(new ReportTimeSystem());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.ReportTimeSystems.Where(x => x.ReportID == id).FirstOrDefault<ReportTimeSystem>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(ReportTimeSystem r)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (r.ReportID == 0)
                {

                    db.ReportTimeSystems.Add(new ReportTimeSystem()
                    {
                        ReportName = r.ReportName,
                        employeeID = EmployeeDetail.EmployeeID,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        EventHours = (r.EndTime - r.StartTime).Hours,
                        EventID = r.EventID,
                        Note = r.Note,
                        ApplyDateTime = new DateTime(),
                        Discontinue = true
                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(r).State = EntityState.Modified;
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
                ReportTimeSystem r = db.ReportTimeSystems.Where(x => x.ReportID == id).FirstOrDefault<ReportTimeSystem>();
                db.ReportTimeSystems.Remove(r);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

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
