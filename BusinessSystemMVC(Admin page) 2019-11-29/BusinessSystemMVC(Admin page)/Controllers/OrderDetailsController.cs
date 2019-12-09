﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Office.Interop.Excel;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class OrderDetailsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        int EmpID = 0;

        // GET: OrderDetails
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData()
        {
            var report = from RM in this.db.RequisitionMains.AsEnumerable()
                         join OD in this.db.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                         where RM.EmployeeID == EmployeeDetail.EmployeeID
                         orderby RM.RequisitionDate descending
                         select new
                         {
                             RM.EmployeeID,
                             RM.RequisitionDate,
                             OD.ProductName,
                             OD.UnitPrice,
                             OD.Quantity,
                             OD.TotalPrice,
                             OD.Note,
                             OD.OrderDetailID,
                             OD.OrderID
                         };

            var datas = report.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }

        //id=0
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new OrderDetail());
            }
            else
            {
                return View(db.OrderDetails.Where(x => x.OrderDetailID == id).FirstOrDefault<OrderDetail>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(OrderDetail orderDetail)
        {
            if (orderDetail.OrderDetailID == 0)
            {
                var userid = User.Identity.GetUserId();
                var account = db.AspNetUsers.Find(userid);

                //找登入員工的第一層上司ID(組長)
                var empquery1 = from EM1 in db.Employees
                                where EM1.Account == account.UserName
                                select new { EM1.employeeID, EM1.ManagerID };

                int? Signer1ID = 0;

                foreach (var e in empquery1)
                {
                    EmpID = e.employeeID;
                    Signer1ID = e.ManagerID;

                }

                //找登入員工的第二層上司ID(部長)
                var empquery2 = from EM2 in db.Employees
                                where EM2.employeeID == Signer1ID
                                select new { EM2.EmployeeName, EM2.ManagerID };

                int? Signer2ID = 0;
                string Signer1Name = "";

                foreach (var e in empquery2)
                {
                    Signer1Name = e.EmployeeName;
                    Signer2ID = e.ManagerID;
                }

                var empquery3 = from EM3 in db.Employees
                                where EM3.employeeID == Signer2ID
                                select new { EM3.EmployeeName };

                string Signer2Name = "";

                foreach (var e in empquery3)
                {
                    Signer2Name = e.EmployeeName;
                }

                var GM = from EGM in db.Employees
                         where EGM.employeeID == 1004
                         select new { EGM.EmployeeName };

                string Signer3Name = "";

                foreach (var e in GM)
                {
                    Signer3Name = e.EmployeeName;
                }

                var GA = from EGA in db.Employees
                         where EGA.employeeID == 1008
                         select new { EGA.EmployeeName };

                string Signer4Name = "";

                foreach (var e in GA)
                {
                    Signer4Name = e.EmployeeName;
                }

                decimal TemporaryUnitPrice = orderDetail.UnitPrice;
                int TemporaryQuantity = orderDetail.Quantity;
                decimal TemporaryTotalPrice = TemporaryUnitPrice * TemporaryQuantity;

                if (TemporaryTotalPrice < 10000)
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
                            Price = TemporaryTotalPrice,
                            Approval = (new Models.Approval
                            {
                                ApprovalProcedureID = 5,
                                FirstSignerID = Signer1ID,
                                FirstSignerName = Signer1Name,
                                FirstSignStatus = "未審核",
                                SecondSignerID = Signer2ID,
                                SecondSignerName = Signer2Name,
                                SecondSignStatus = "未審核",
                                ThirdSignerID = null,
                                ThirdSignerName = "-----",
                                ThirdSignStatus = "免審核",
                                FourthSignerID = 1008,
                                FourthSignerName = Signer4Name,
                                FourthSignStatus = "未審核"
                            })
                        })
                    });
                }

                else if (TemporaryTotalPrice >= 10000)
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
                            Price = TemporaryTotalPrice,
                            Approval = (new Models.Approval
                            {
                                ApprovalProcedureID = 6,
                                FirstSignerID = Signer1ID,
                                FirstSignerName = Signer1Name,
                                FirstSignStatus = "未審核",
                                SecondSignerID = Signer2ID,
                                SecondSignerName = Signer2Name,
                                SecondSignStatus = "未審核",
                                ThirdSignerID = 1004,
                                ThirdSignerName = Signer3Name,
                                ThirdSignStatus = "未審核",
                                FourthSignerID = 1008,
                                FourthSignerName = Signer4Name,
                                FourthSignStatus = "未審核"
                            })
                        })
                    });
                }

                db.SaveChanges();

                return Json(new { success = true, message = "新增成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            RequisitionMain requisitionMain = db.RequisitionMains.Find(orderDetail.OrderID);
            Approval approval = db.Approvals.Find(orderDetail.OrderID);

            db.OrderDetails.Remove(orderDetail);
            db.RequisitionMains.Remove(requisitionMain);
            db.Approvals.Remove(approval);

            db.SaveChanges();

            return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Export(int? id)
        {
            var report = from RM in this.db.RequisitionMains.AsEnumerable()
                         join OD in this.db.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
                         where OD.OrderDetailID == id
                         select new
                         {
                             OD.OrderID,
                             OD.ProductName,
                             OD.UnitPrice,
                             OD.Quantity,
                             OD.TotalPrice,
                             OD.Note
                         };

            Application application = new Application();
            Workbook workbook = application.Workbooks.Add(Missing.Value);
            Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Cells[1, 1] = "OrderID";
            worksheet.Cells[1, 2] = "ProductName";
            worksheet.Cells[1, 3] = "UnitPrice";
            worksheet.Cells[1, 4] = "Quantity";
            worksheet.Cells[1, 5] = "TotalPrice";
            worksheet.Cells[1, 6] = "Note";

            int row = 2;
            foreach (var e in report)
            {
                worksheet.Cells[row, 1] = e.OrderID;
                worksheet.Cells[row, 2] = e.ProductName;
                worksheet.Cells[row, 3] = e.UnitPrice;
                worksheet.Cells[row, 4] = e.Quantity;
                worksheet.Cells[row, 5] = e.TotalPrice;
                worksheet.Cells[row, 6] = e.Note;
                row++;
            }

            workbook.SaveAs("D:\\ExportToExcel.xls");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            application.Quit();
            Marshal.FinalReleaseComObject(application);

            return Json(new { success = true, message = "下載成功" }, JsonRequestBehavior.AllowGet);
        }

        //簽核流程查詢

        [HttpGet]
        public ActionResult LoadDataSignProgress()
        {
            var data = from OD in db.OrderDetails.AsEnumerable()
                       join RM in db.RequisitionMains.AsEnumerable() on OD.OrderID equals RM.OrderID
                       join AS in db.Approvals.AsEnumerable() on RM.OrderID equals AS.OrderID
                       where RM.EmployeeID == EmployeeDetail.EmployeeID
                       select new
                       {
                           OD.ProductName,
                           OD.UnitPrice,
                           OD.Quantity,
                           OD.TotalPrice,
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

        [HttpGet]
        public ActionResult DetailSignProgress(int? id)
        {
            return View(db.OrderDetails.Where(x => x.OrderID == id).FirstOrDefault<OrderDetail>());
        }

        //簽核

        [HttpGet]
        public ActionResult IndexSign()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadDataSign()
        {
            var data = from OD in db.OrderDetails.AsEnumerable()
                       join RM in db.RequisitionMains.AsEnumerable() on OD.OrderID equals RM.OrderID
                       join AS in db.Approvals.AsEnumerable() on RM.OrderID equals AS.OrderID
                       where AS.FirstSignerID == EmployeeDetail.EmployeeID || AS.SecondSignerID == EmployeeDetail.EmployeeID || AS.ThirdSignerID == EmployeeDetail.EmployeeID || AS.FourthSignerID == EmployeeDetail.EmployeeID
                       select new
                       {
                           OD.ProductName,
                           OD.UnitPrice,
                           OD.Quantity,
                           OD.TotalPrice,
                           OD.Note,
                           AS.OrderID,
                           AS.FirstSignerName,                           
                           AS.FirstSignStatus,
                           AS.SecondSignerName,
                           AS.SecondSignStatus,
                           AS.ThirdSignerName,
                           AS.ThirdSignStatus,
                           AS.FourthSignerName,
                           AS.FourthSignStatus
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEditSign(int id = 0)
        {
            if (id == 0)
            {
                return View(new OrderDetail());
            }
            else
            {
                return View(db.OrderDetails.Where(x => x.OrderID == id).FirstOrDefault<OrderDetail>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEditSign(BulletinBoard b)
        {
            if (b.Num == 0)
            {
                db.BulletinBoards.Add(new BulletinBoard()
                {


                });
                db.SaveChanges();

                return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //--------------------------------------------------------------------------------------------------------

        //public ActionResult Index(string searchProductName)
        //{
        //    var userid = User.Identity.GetUserId();
        //    var account = db.AspNetUsers.Find(userid);

        //    var empquery = from EM in db.Employees
        //                   where EM.Account == account.UserName
        //                   select new { EM.employeeID };

        //    foreach (var e in empquery)
        //    {
        //        EmpID = e.employeeID;
        //    }

        //    var report = from RM in this.db.RequisitionMains.AsEnumerable()
        //                 join OD in this.db.OrderDetails.AsEnumerable() on RM.OrderID equals OD.OrderID
        //                 where RM.EmployeeID == EmpID
        //                 select OD;
        //    if (!String.IsNullOrEmpty(searchProductName))
        //    {
        //        report = report.Where(s => s.ProductName.Contains(searchProductName));
        //    }
        //    else
        //    {
        //        return View(report.ToList());
        //    }
        //    return View(report.ToList());
        //}

        //// GET: OrderDetails/Details/5
        //[Authorize]
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = db.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orderDetail);
        //}

        //// GET: OrderDetails/Create
        //[Authorize]
        //public ActionResult Create()
        //{
        //    ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID");
        //    return View();
        //}

        //// POST: OrderDetails/Create
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderDetailID,OrderID,Note,ProductName,UnitPrice,Quantity,TotalPrice")] OrderDetail orderDetail)
        //{
        //    var userid = User.Identity.GetUserId();
        //    var account = db.AspNetUsers.Find(userid);

        //    //找登入員工的第一層上司ID(組長)
        //    var empquery1 = from EM1 in db.Employees
        //                    where EM1.Account == account.UserName
        //                    select new { EM1.employeeID, EM1.ManagerID };

        //    int? Signer1ID = 0;

        //    foreach (var e in empquery1)
        //    {
        //        EmpID = e.employeeID;
        //        Signer1ID = e.ManagerID;
        //    }

        //    //找登入員工的第二層上司ID(部長)
        //    var empquery2 = from EM2 in db.Employees
        //                    where EM2.employeeID == Signer1ID
        //                    select new { EM2.ManagerID };

        //    int? Signer2ID = 0;

        //    foreach (var e in empquery2)
        //    {
        //        Signer2ID = e.ManagerID;
        //    }

        //    decimal TemporaryUnitPrice = orderDetail.UnitPrice;
        //    int TemporaryQuantity = orderDetail.Quantity;
        //    decimal TemporaryTotalPrice = TemporaryUnitPrice * TemporaryQuantity;

        //    if (ModelState.IsValid)
        //    {
        //        if (TemporaryTotalPrice < 10000)
        //        {
        //            db.OrderDetails.Add(new Models.OrderDetail
        //            {
        //                ProductName = orderDetail.ProductName,
        //                UnitPrice = orderDetail.UnitPrice,
        //                Quantity = orderDetail.Quantity,
        //                Note = orderDetail.Note,
        //                RequisitionMain = (new Models.RequisitionMain
        //                {
        //                    ReportID = 2,
        //                    EmployeeID = EmpID,
        //                    RequisitionDate = DateTime.Now,
        //                    Price = TemporaryTotalPrice,
        //                    Approval = (new Models.Approval
        //                    {
        //                        ApprovalProcedureID = 5,
        //                        FirstSignerID = Signer1ID,
        //                        FirstSignStatus = "未審核",
        //                        SecondSignerID = Signer2ID,
        //                        SecondSignStatus = "未審核",
        //                        ThirdSignerID = null,
        //                        ThirdSignStatus = "免審核",
        //                        FourthSignerID = 1008,
        //                        FourthSignStatus = "未審核"
        //                    })
        //                })
        //            });
        //        }

        //        else if (TemporaryTotalPrice >= 10000)
        //        {
        //            db.OrderDetails.Add(new Models.OrderDetail
        //            {
        //                ProductName = orderDetail.ProductName,
        //                UnitPrice = orderDetail.UnitPrice,
        //                Quantity = orderDetail.Quantity,
        //                Note = orderDetail.Note,
        //                RequisitionMain = (new Models.RequisitionMain
        //                {
        //                    ReportID = 2,
        //                    EmployeeID = EmpID,
        //                    RequisitionDate = DateTime.Now,
        //                    Price = TemporaryTotalPrice,
        //                    Approval = (new Models.Approval
        //                    {
        //                        ApprovalProcedureID = 6,
        //                        FirstSignerID = Signer1ID,
        //                        FirstSignStatus = "未審核",
        //                        SecondSignerID = Signer2ID,
        //                        SecondSignStatus = "未審核",
        //                        ThirdSignerID = 1004,
        //                        ThirdSignStatus = "未審核",
        //                        FourthSignerID = 1008,
        //                        FourthSignStatus = "未審核"
        //                    })
        //                })
        //            });

        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
        //    return View(orderDetail);
        //}

        //// GET: OrderDetails/Edit/5
        //[Authorize]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = db.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
        //    return View(orderDetail);
        //}

        //// POST: OrderDetails/Edit/5
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrderDetailID,OrderID,Note,ProductName,UnitPrice,Quantity,TotalPrice")] OrderDetail orderDetail)
        //{
        //    var userid = User.Identity.GetUserId();
        //    var account = db.AspNetUsers.Find(userid);

        //    var empquery = from EM in db.Employees
        //                   where EM.Account == account.UserName
        //                   select new { EM.employeeID };

        //    foreach (var e in empquery)
        //    {
        //        EmpID = e.employeeID;
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(orderDetail).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.OrderID = new SelectList(db.RequisitionMains, "OrderID", "OrderID", orderDetail.OrderID);
        //    return View(orderDetail);
        //}

        //// GET: OrderDetails/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    OrderDetail orderDetail = db.OrderDetails.Find(id);
        //    if (orderDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(orderDetail);
        //}

        //// POST: OrderDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    OrderDetail orderDetail = db.OrderDetails.Find(id);
        //    RequisitionMain requisitionMain = db.RequisitionMains.Find(orderDetail.OrderID);
        //    Approval approval = db.Approvals.Find(orderDetail.OrderID);
        //    db.OrderDetails.Remove(orderDetail);
        //    db.RequisitionMains.Remove(requisitionMain);
        //    db.Approvals.Remove(approval);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}