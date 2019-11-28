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
    public class OrderDetailsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();             

        int EmpID = 0;

        // GET: OrderDetails
        [Authorize]
        public ActionResult Index(string searchProductName)
        {
            var userid = User.Identity.GetUserId();
            var account = db.AspNetUsers.Find(userid);

            var empquery = from EM in db.Employees
                           where EM.Account == account.UserName
                           select new { EM.employeeID };

            foreach (var e in empquery)
            {
                EmpID = e.employeeID;
            }

            var report = from RM in this.db.RequisitionMains.AsEnumerable()
                         join OD in this.db.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                         where RM.EmployeeID == EmpID
                         select OD;
            if (!String.IsNullOrEmpty(searchProductName))
            {
                report = report.Where(s => s.ProductName.Contains(searchProductName));
            }
            else
            {
                return View(report.ToList());
            }
            return View(report.ToList());
        }

        // GET: OrderDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID");
            return View();
        }

        // POST: OrderDetails/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDetailID,OrderID,Note,ProductName,UnitPrice,Quantity,TotalPrice")] OrderDetail orderDetail)
        {
            var userid = User.Identity.GetUserId();
            var account = db.AspNetUsers.Find(userid);

            var empquery = from EM in db.Employees
                           where EM.Account == account.UserName
                           select new { EM.employeeID };

            foreach (var e in empquery)
            {
                EmpID = e.employeeID;
            }

            decimal TemporaryUnitPrice = orderDetail.UnitPrice;
            int TemporaryQuantity = orderDetail.Quantity;
            decimal TemporaryTotalPrice = TemporaryUnitPrice * TemporaryQuantity;

            if (ModelState.IsValid)
            {
                if (TemporaryTotalPrice >= 10000)
                {
                    db.OrderDetails.Add(new Models.OrderDetail
                    {
                        ProductName = orderDetail.ProductName,
                        UnitPrice = orderDetail.UnitPrice,
                        Quantity = orderDetail.Quantity,
                        Note = orderDetail.Note,
                        RequisitionMain = (new Models.RequisitionMain
                        {                            
                            ReportID = 2,
                            EmployeeID = EmpID,
                            RequisitionDate = DateTime.Now,
                            Approval = (new Models.Approval
                            {
                                ApprovalProcedureID = 6
                            })
                        })
                    });

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                else if (TemporaryTotalPrice < 10000)
                {
                    db.OrderDetails.Add(new Models.OrderDetail
                    {
                        ProductName = orderDetail.ProductName,
                        UnitPrice = orderDetail.UnitPrice,
                        Quantity = orderDetail.Quantity,
                        Note = orderDetail.Note,
                        RequisitionMain = (new Models.RequisitionMain
                        {
                            ReportID = 2,
                            EmployeeID = EmpID,
                            RequisitionDate = DateTime.Now,
                            Approval = (new Models.Approval
                            {
                                ApprovalProcedureID = 5
                            })
                        })
                    });
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailID,OrderID,Note,ProductName,UnitPrice,Quantity,TotalPrice")] OrderDetail orderDetail)
        {
            var userid = User.Identity.GetUserId();
            var account = db.AspNetUsers.Find(userid);

            var empquery = from EM in db.Employees
                           where EM.Account == account.UserName
                           select new { EM.employeeID };

            foreach (var e in empquery)
            {
                EmpID = e.employeeID;
            }

            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            RequisitionMain requisitionMain = db.RequisitionMains.Find(orderDetail.OrderID);
            Approval approval = db.Approvals.Find(orderDetail.OrderID);
            db.OrderDetails.Remove(orderDetail);
            db.RequisitionMains.Remove(requisitionMain);
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
