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
    public class ApprovalsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: Approvals
        public ActionResult Index()
        {
            var approvals = db.Approvals.Include(a => a.ApprovalProcedure).Include(a => a.RequisitionMain);
            return View(approvals.ToList());
        }

        public ActionResult LoadData()
        {
            var data = from AS in db.Approvals
                       select new
                       {
                           AS.OrderID,
                           AS.FirstSignerID,
                           AS.FirstSignDate,
                           AS.FirstSignStatus,
                           AS.SecondSignerID,
                           AS.SecondSignDate,
                           AS.SecondSignStatus,
                           AS.ThirdSignerID,
                           AS.ThirdSignDate,
                           AS.ThirdSignStatus,
                           AS.FourthSignerID,
                           AS.ForthSignDate,
                           AS.FourthSignStatus
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //id=0
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Approval());
            }
            else
            {
                return View(db.Approvals.Where(x => x.OrderID == id).FirstOrDefault<Approval>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Approval approval)
        {
                if (approval.OrderID == 0)
                {
                    var userid = User.Identity.GetUserId();
                    var account = db.AspNetUsers.Find(userid);

                    var empquery = from em in db.Employees
                                   where em.Account == account.UserName
                                   select new
                                   {
                                       em.employeeID,
                                   };

                    int EmpID = 0;

                    foreach (var e in empquery)
                    {
                        EmpID = e.employeeID;
                    }


                    db.Approvals.Add(new Approval()
                    {
                        OrderID=approval.OrderID,
                        
                        

                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(approval).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
                }

            
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
        public ActionResult Create([Bind(Include = "OrderID,ApprovalProcedureID,FirstSignerID,FirstSignStatus,FirstSignDate,SecondSignerID,SecondSignStatus,SecondSignDate,ThirdSignerID,ThirdSignStatus,ThirdSignDate,FourthSignerID,FourthSignStatus,ForthSignDate")] Approval approval)
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
        public ActionResult Edit([Bind(Include = "OrderID,ApprovalProcedureID,FirstSignerID,FirstSignStatus,FirstSignDate,SecondSignerID,SecondSignStatus,SecondSignDate,ThirdSignerID,ThirdSignStatus,ThirdSignDate,FourthSignerID,FourthSignStatus,ForthSignDate")] Approval approval)
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
