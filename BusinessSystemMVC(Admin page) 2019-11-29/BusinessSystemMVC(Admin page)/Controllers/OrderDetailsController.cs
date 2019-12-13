using System;
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
                                select new { EM1.ManagerID };

                int? Signer1ID = 0;

                foreach (var e in empquery1)
                {
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
                         where EGA.employeeID == 1013
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
                            EmployeeID = EmployeeDetail.EmployeeID,
                            RequisitionDate = DateTime.Now,
                            Price = TemporaryTotalPrice,
                            ApprovalStatusID = 2,
                            ApprovaStatus = "審核中",
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
                                FourthSignerID = 1013,
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
                            EmployeeID = EmployeeDetail.EmployeeID,
                            RequisitionDate = DateTime.Now,
                            Price = TemporaryTotalPrice,
                            ApprovalStatusID = 2,
                            ApprovaStatus = "審核中",
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
                                FourthSignerID = 1013,
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

        //簽核流程查詢--------------------------------------------------------------------------------------------------------

        [HttpGet]
        public ActionResult LoadDataSignProgress()
        {
            var data = from OD in db.OrderDetails.AsEnumerable()
                       join RM in db.RequisitionMains.AsEnumerable() on OD.OrderID equals RM.OrderID
                       join AS in db.ApprovalStatus.AsEnumerable() on RM.ApprovalStatusID equals AS.ApprovalStatusID
                       join A in db.Approvals.AsEnumerable() on RM.OrderID equals A.OrderID
                       where RM.EmployeeID == EmployeeDetail.EmployeeID
                       select new
                       {
                           OD.ProductName,
                           OD.UnitPrice,
                           OD.Quantity,
                           OD.TotalPrice,
                           RM.ApprovaStatus,
                           AS.StatusName,
                           A.OrderID,
                           A.FirstSignerID,
                           A.FirstSignDate,
                           A.FirstSignStatus,
                           A.SecondSignerID,
                           A.SecondSignDate,
                           A.SecondSignStatus,
                           A.ThirdSignerID,
                           A.ThirdSignDate,
                           A.ThirdSignStatus,
                           A.FourthSignerID,
                           A.ForthSignDate,
                           A.FourthSignStatus
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DetailSignProgress(int? id)
        {
            return View(db.OrderDetails.Where(x => x.OrderID == id).FirstOrDefault<OrderDetail>());
        }

        //簽核---------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult IndexSign()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadDataSign()
        {
            var report = from OD in db.OrderDetails.AsEnumerable()
                         join RM in db.RequisitionMains.AsEnumerable() on OD.OrderID equals RM.OrderID
                         join A in db.Approvals.AsEnumerable() on RM.OrderID equals A.OrderID
                         where A.FirstSignerID == EmployeeDetail.EmployeeID || A.SecondSignerID == EmployeeDetail.EmployeeID || A.ThirdSignerID == EmployeeDetail.EmployeeID || A.FourthSignerID == EmployeeDetail.EmployeeID
                         select new
                         {
                             OD.ProductName,
                             OD.UnitPrice,
                             OD.Quantity,
                             OD.TotalPrice,
                             OD.Note,
                             A.OrderID,
                             A.FirstSignerID,
                             A.FirstSignerName,
                             A.FirstSignStatus,
                             A.SecondSignerID,
                             A.SecondSignerName,
                             A.SecondSignStatus,
                             A.ThirdSignerID,
                             A.ThirdSignerName,
                             A.ThirdSignStatus,
                             A.FourthSignerID,
                             A.FourthSignerName,
                             A.FourthSignStatus
                         };

            //查詢第三層簽核狀態(已簽核、免簽核)
            var ThirdSign = from A in db.Approvals
                            select new { A.ThirdSignStatus };

            string SignStatus = "";

            foreach (var e in ThirdSign)
            {
                SignStatus = e.ThirdSignStatus;
            }

            if (EmployeeDetail.PositionID == 3 && EmployeeDetail.GroupID == 1)
            {
                //第三層已簽核、免簽核
                if (!(SignStatus == "駁回簽核"))
                {
                    report = report.Where(x => x.SecondSignStatus == "已審核" && x.FourthSignStatus == "未審核" && x.FourthSignerID == EmployeeDetail.EmployeeID).Select(x => x);
                }
            }
            else if (EmployeeDetail.PositionID == 3)
            {
                report = report.Where(x => x.FirstSignStatus == "未審核" && x.FirstSignerID == EmployeeDetail.EmployeeID).Select(x => x);
            }
            else if (EmployeeDetail.PositionID == 2)
            {
                report = report.Where(x => x.FirstSignStatus == "已審核" && x.SecondSignStatus == "未審核" && x.SecondSignerID == EmployeeDetail.EmployeeID).Select(x => x);
            }
            else if (EmployeeDetail.PositionID == 1)
            {
                report = report.Where(x => x.SecondSignStatus == "已審核" && x.ThirdSignStatus == "未審核" && x.ThirdSignerID == EmployeeDetail.EmployeeID).Select(x => x);
            }

            var datas = report.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ApprovalSubmit(int? id)
        {
            var requisition = db.RequisitionMains.Find(id);
            var approval = db.Approvals.Find(id);

            if (approval.FirstSignerID == EmployeeDetail.EmployeeID)
            {
                approval.FirstSignDate = DateTime.Now;
                approval.FirstSignStatus = "已審核";
            }

            if (approval.SecondSignerID == EmployeeDetail.EmployeeID && approval.FirstSignStatus == "已審核")
            {
                approval.SecondSignDate = DateTime.Now;
                approval.SecondSignStatus = "已審核";
            }

            if (approval.ThirdSignerID == EmployeeDetail.EmployeeID && approval.SecondSignStatus == "已審核")
            {
                approval.ThirdSignDate = DateTime.Now;
                approval.ThirdSignStatus = "已審核";
            }

            if (approval.FourthSignerID == EmployeeDetail.EmployeeID && approval.SecondSignStatus == "已審核" && approval.ThirdSignStatus == "已審核" || approval.ThirdSignStatus == "免審核")
            {
                requisition.ApprovalStatusID = 3;
                requisition.ApprovaStatus = "審核完成";
                approval.ForthSignDate = DateTime.Now;
                approval.FourthSignStatus = "已審核";
            }

            db.SaveChanges();

            return Json(new { success = true, message = "簽核成功" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ApprovalReject(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                return View(db.RequisitionMains.Where(x => x.OrderID == id).FirstOrDefault<RequisitionMain>());
            }
        }

        [HttpPost]
        public ActionResult ApprovalReject(RequisitionMain requisitionMain)
        {
            if (requisitionMain.OrderID == 0)
            {
                return View();
            }
            else
            {
                var approval = db.Approvals.Find(requisitionMain.OrderID);
                if (approval.FirstSignerID == EmployeeDetail.EmployeeID)
                {
                    requisitionMain.ApprovalStatusID = 1;
                    approval.FirstSignDate = DateTime.Now;
                    approval.FirstSignStatus = "駁回簽核";
                }

                if (approval.SecondSignerID == EmployeeDetail.EmployeeID && approval.FirstSignStatus == "已審核")
                {
                    requisitionMain.ApprovalStatusID = 1;
                    approval.SecondSignDate = DateTime.Now;
                    approval.SecondSignStatus = "駁回簽核";
                }

                if (approval.ThirdSignerID == EmployeeDetail.EmployeeID && approval.SecondSignStatus == "已審核")
                {
                    requisitionMain.ApprovalStatusID = 1;
                    approval.ThirdSignDate = DateTime.Now;
                    approval.ThirdSignStatus = "駁回簽核";
                }

                if (approval.FourthSignerID == EmployeeDetail.EmployeeID && approval.ThirdSignStatus == "已審核")
                {
                    requisitionMain.ApprovalStatusID = 1;
                    approval.ForthSignDate = DateTime.Now;
                    approval.FourthSignStatus = "駁回簽核";
                }

                db.Entry(requisitionMain).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, message = "填寫成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult ApprovalReject(int? id)
        //{
        //    var approval = db.Approvals.Find(id);

        //    if (approval.FirstSignerID == EmployeeDetail.EmployeeID)
        //    {
        //        approval.FirstSignDate = DateTime.Now;
        //        approval.FirstSignStatus = "駁回簽核";
        //    }

        //    if (approval.SecondSignerID == EmployeeDetail.EmployeeID && approval.FirstSignStatus == "已審核")
        //    {
        //        approval.SecondSignDate = DateTime.Now;
        //        approval.SecondSignStatus = "駁回簽核";
        //    }

        //    if (approval.ThirdSignerID == EmployeeDetail.EmployeeID && approval.SecondSignStatus == "已審核")
        //    {
        //        approval.ThirdSignDate = DateTime.Now;
        //        approval.ThirdSignStatus = "駁回簽核";
        //    }

        //    if (approval.FourthSignerID == EmployeeDetail.EmployeeID && approval.ThirdSignStatus == "已審核")
        //    {
        //        approval.ForthSignDate = DateTime.Now;
        //        approval.FourthSignStatus = "駁回簽核";
        //    }

        //    db.SaveChanges();

        //    return Json(new { success = true, message = "簽核成功" }, JsonRequestBehavior.AllowGet);
        //}

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