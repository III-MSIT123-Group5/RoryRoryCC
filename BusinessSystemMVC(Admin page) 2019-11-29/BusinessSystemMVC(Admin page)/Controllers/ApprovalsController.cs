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
    public class ApprovalsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: Approvals
        public ActionResult Index()
        {
            var approvals = db.Approvals.Include(a => a.ApprovalProcedure).Include(a => a.RequisitionMain);
            return View(approvals.ToList());
        }

        // GET: Approvals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // GET: Approvals/Create
        public ActionResult Create()
        {
            ViewBag.ApprovalProcedureID = new SelectList(db.ApprovalProcedures, "ApprovalProcedureID", "ApprovalReportName");
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID");
            return View();
        }

        // POST: Approvals/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ApprovalProcedureID,FirstSignerID,FirstSignerName,FirstSignStatus,FirstSignDate,SecondSignerID,SecondSignerName,SecondSignStatus,SecondSignDate,ThirdSignerID,ThirdSignerName,ThirdSignStatus,ThirdSignDate,FourthSignerID,FourthSignerName,FourthSignStatus,ForthSignDate")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Approvals.Add(approval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprovalProcedureID = new SelectList(db.ApprovalProcedures, "ApprovalProcedureID", "ApprovalReportName", approval.ApprovalProcedureID);
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", approval.OrderID);
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApprovalProcedureID = new SelectList(db.ApprovalProcedures, "ApprovalProcedureID", "ApprovalReportName", approval.ApprovalProcedureID);
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", approval.OrderID);
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ApprovalProcedureID,FirstSignerID,FirstSignerName,FirstSignStatus,FirstSignDate,SecondSignerID,SecondSignerName,SecondSignStatus,SecondSignDate,ThirdSignerID,ThirdSignerName,ThirdSignStatus,ThirdSignDate,FourthSignerID,FourthSignerName,FourthSignStatus,ForthSignDate")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApprovalProcedureID = new SelectList(db.ApprovalProcedures, "ApprovalProcedureID", "ApprovalReportName", approval.ApprovalProcedureID);
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", approval.OrderID);
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Approval approval = db.Approvals.Find(id);
            db.Approvals.Remove(approval);
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
