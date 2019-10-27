﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;
using PagedList;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class OrderDetailsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();
        
        public ActionResult Index(string searching)
        {
            var ProductName = from OD in db.OrderDetails
                              select OD;
            if (!String.IsNullOrEmpty(searching))
            {
                ProductName = ProductName.Where(s => s.ProductName.Contains(searching));
            }
            return View(ProductName.ToList());
        }

        //public ActionResult Index(String orderdetailGenre, String SearchString)
        //{
        //    var genreList = new List<String>();
        //    var genreQry = from o in db.OrderDetails
        //                   orderby o.ProductName
        //                   select o.ProductName;
        //    genreList.AddRange(genreQry.Distinct());
        //    ViewBag.orderdetailGenre = new SelectList(genreList);

        //    var orderdetail = from OD in db.OrderDetails
        //                      select OD;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        orderdetail = orderdetail.Where(s => s.ProductName.Contains(SearchString));
        //    }
        //    if (!String.IsNullOrEmpty(orderdetailGenre))
        //    {
        //        orderdetail = orderdetail.Where(x => x.ProductName == orderdetailGenre);
        //    }
        //    return View(orderdetail);
        //}

        //// GET: OrderDetails
        //public ActionResult Index()
        //{           
        //    var report = from RM in this.db.RequisitionMains
        //                 join OD in this.db.OrderDetails on RM.OrderID equals OD.OrderID
        //                 where RM.EmployeeID == 1032
        //                 select OD;
        //    return View(report.ToList());
        //}

        // GET: OrderDetails/Details/5
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
            if (ModelState.IsValid)
            {
                var report = from RM in this.db.RequisitionMains
                             join OD in this.db.OrderDetails on RM.OrderID equals OD.OrderID
                             where RM.EmployeeID == 1032
                             select OD;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
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
            db.OrderDetails.Remove(orderDetail);
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
