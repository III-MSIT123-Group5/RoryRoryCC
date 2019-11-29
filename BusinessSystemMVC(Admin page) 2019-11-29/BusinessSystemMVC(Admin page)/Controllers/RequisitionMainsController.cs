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
    public class RequisitionMainsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: RequisitionMains
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loaddata()
        {
            var data = from RM in db.RequisitionMains
                       where RM.EmployeeID==1043
                       select new
                       {
                           RM.OrderID,
                           RM.ReportID,
                           RM.EmployeeID,
                           RM.RequisitionDate,
                           RM.ApprovalStatusID
                       };

            var data1 = data.OrderByDescending(a => a.RequisitionDate).ToList();
            return Json(new { data = data1 }, JsonRequestBehavior.AllowGet);
        }    

    // GET: RequisitionMains/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionMain requisitionMain = db.RequisitionMains.Find(id);
            if (requisitionMain == null)
            {
                return HttpNotFound();
            }
            return View(requisitionMain);
        }

        // GET: RequisitionMains/Create
        public ActionResult Create()
        {
            ViewBag.ApprovalStatusID = new SelectList(db.ApprovalStatus, "ApprovalStatusID", "StatusName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.ReportID = new SelectList(db.ReportCategories, "ReportID", "ReportName");
            return View();
        }

        // POST: RequisitionMains/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ReportID,EmployeeID,RequisitionDate,ApprovalStatusID")] RequisitionMain requisitionMain)
        {
            if (ModelState.IsValid)
            {
                db.RequisitionMains.Add(requisitionMain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprovalStatusID = new SelectList(db.ApprovalStatus, "ApprovalStatusID", "StatusName", requisitionMain.ApprovalStatusID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", requisitionMain.EmployeeID);
            ViewBag.ReportID = new SelectList(db.ReportCategories, "ReportID", "ReportName", requisitionMain.ReportID);
            return View(requisitionMain);
        }

        // GET: RequisitionMains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionMain requisitionMain = db.RequisitionMains.Find(id);
            if (requisitionMain == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApprovalStatusID = new SelectList(db.ApprovalStatus, "ApprovalStatusID", "StatusName", requisitionMain.ApprovalStatusID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", requisitionMain.EmployeeID);
            ViewBag.ReportID = new SelectList(db.ReportCategories, "ReportID", "ReportName", requisitionMain.ReportID);
            return View(requisitionMain);
        }

        // POST: RequisitionMains/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ReportID,EmployeeID,RequisitionDate,ApprovalStatusID")] RequisitionMain requisitionMain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitionMain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApprovalStatusID = new SelectList(db.ApprovalStatus, "ApprovalStatusID", "StatusName", requisitionMain.ApprovalStatusID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", requisitionMain.EmployeeID);
            ViewBag.ReportID = new SelectList(db.ReportCategories, "ReportID", "ReportName", requisitionMain.ReportID);
            return View(requisitionMain);
        }

        // GET: RequisitionMains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitionMain requisitionMain = db.RequisitionMains.Find(id);
            if (requisitionMain == null)
            {
                return HttpNotFound();
            }
            return View(requisitionMain);
        }

        // POST: RequisitionMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequisitionMain requisitionMain = db.RequisitionMains.Find(id);
            db.RequisitionMains.Remove(requisitionMain);
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
