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
    public class CompanyVehicleHistoriesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: CompanyVehicleHistories
        public ActionResult Index()
        {
            var companyVehicleHistories = db.CompanyVehicleHistories.Include(c => c.CompanyVehicle).Include(c => c.Employee);
            return View(companyVehicleHistories.ToList());
        }
        public ActionResult test1()
        {
            var items = from p in db.CompanyVehicleHistories
                        select new
                        {
                            p.employeeID,
                            p.LicenseNumber,
                            p.StartDateTime,
                            p.EndDateTime
                        };
            var jsonitems = Json(items);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();

            var data = from b in db.CompanyVehicleHistories
                       where b.employeeID == EmployeeDetail.EmployeeID
                       select new
                       {
                           b.VehicleHistoryID,
                           b.LicenseNumber,
                           b.StartDateTime,
                           b.EndDateTime,
                           b.purpose,
                           b.employeeID
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        //id=0
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            
            if (id == 0)
            {
                return View(new CompanyVehicleHistory());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CompanyVehicleHistories.Where(x => x.VehicleHistoryID == id).FirstOrDefault<CompanyVehicleHistory>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CompanyVehicleHistory b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if(b.VehicleHistoryID == 0)
                {

                }
                else
                {
                    db.Entry(b).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);

                //var saveCars = new BusinessSystemMVC_Admin_page_.Models.CompanyVehicleHistory
                //{
                //    VehicleHistoryID = b.VehicleHistoryID,
                //    StartDateTime = b.StartDateTime,
                //    EndDateTime = b.EndDateTime,
                //    employeeID = b.employeeID,
                //    purpose = b.purpose
                //};
                //return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        






        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                CompanyVehicleHistory b = db.CompanyVehicleHistories.Where(x => x.VehicleHistoryID == id).FirstOrDefault<CompanyVehicleHistory>();
                db.CompanyVehicleHistories.Remove(b);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }







        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    CompanyVehicleHistory companyVehicleHistory = db.CompanyVehicleHistories.Find(id);
        //    if (companyVehicleHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyVehicleHistory);
        //}

        // GET: CompanyVehicleHistories/Create
        public ActionResult Create()
        {
            ViewBag.LicenseNumber = new SelectList(db.CompanyVehicles, "LicenseNumber", "brand");
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }

        // POST: CompanyVehicleHistories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleHistoryID,LicenseNumber,StartDateTime,EndDateTime,employeeID,purpose")] CompanyVehicleHistory companyVehicleHistory)
        {
            if (ModelState.IsValid)
            {
                db.CompanyVehicleHistories.Add(companyVehicleHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LicenseNumber = new SelectList(db.CompanyVehicles, "LicenseNumber", "brand", companyVehicleHistory.LicenseNumber);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", companyVehicleHistory.employeeID);
            return View(companyVehicleHistory);
        }

        // GET: CompanyVehicleHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyVehicleHistory companyVehicleHistory = db.CompanyVehicleHistories.Find(id);
            if (companyVehicleHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.LicenseNumber = new SelectList(db.CompanyVehicles, "LicenseNumber", "brand", companyVehicleHistory.LicenseNumber);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", companyVehicleHistory.employeeID);
            return View(companyVehicleHistory);
        }

        // POST: CompanyVehicleHistories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleHistoryID,LicenseNumber,StartDateTime,EndDateTime,employeeID,purpose")] CompanyVehicleHistory companyVehicleHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyVehicleHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LicenseNumber = new SelectList(db.CompanyVehicles, "LicenseNumber", "brand", companyVehicleHistory.LicenseNumber);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", companyVehicleHistory.employeeID);
            return View(companyVehicleHistory);
        }

        // GET: CompanyVehicleHistories/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyVehicleHistory companyVehicleHistory = db.CompanyVehicleHistories.Find(id);
        //    if (companyVehicleHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyVehicleHistory);
        //}

        //POST: CompanyVehicleHistories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CompanyVehicleHistory companyVehicleHistory = db.CompanyVehicleHistories.Find(id);
        //    db.CompanyVehicleHistories.Remove(companyVehicleHistory);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
