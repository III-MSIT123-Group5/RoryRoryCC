using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using BusinessSystemMVC_Admin_page_.ViewModels;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class CompanyVehiclesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: CompanyVehicles
        public ActionResult Index()
        {
            var companyVehicles = db.CompanyVehicles.Include(c => c.Office);
            return View(companyVehicles.ToList());
        }





        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();

            var data = from b in db.CompanyVehicles
                       select new
                       {
                           b.VehiclePhoto2,
                           b.VehicleYear,
                           b.LicenseNumber,
                           b.PurchaseDate,
                           b.brand,
                           b.serial,
                           b.MaxPassenger,
                           officename = b.Office.office_name
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        //id=0

        [HttpGet]
        public ActionResult AddOrEdit(string id)
        {

            if (id == null)
            {
                return View(new CompanyVehicle());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CompanyVehicles.Where(x => x.LicenseNumber == id).FirstOrDefault<CompanyVehicle>());
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CompanyVehicle b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

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

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string SourceFilename = Path.GetFileName(file.FileName);
                string saveDir = "\\CarUpload\\";
                //根目錄
                string appPath = Request.PhysicalApplicationPath;
                //完整路徑(包含檔名)
                string savePath = appPath + saveDir + SourceFilename;
                file.SaveAs(savePath);
                db.CompanyVehicles.Add(new BusinessSystemMVC_Admin_page_.Models.CompanyVehicle
                {

                    VehiclePhoto2 = savePath,

                });
                //儲存修改
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult AddOrEdit2(string id)
        {

            if (id == null)
            {
                return View(new CompanyVehicle());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CompanyVehicles.Where(x => x.LicenseNumber == id).FirstOrDefault<CompanyVehicle>());
                }
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddOrEdit3( HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        string SourceFilename = Path.GetFileName(file.FileName);
        //        string saveDir = "\\CarUpload\\";
        //        //根目錄
        //        string appPath = Request.PhysicalApplicationPath;
        //        //完整路徑(包含檔名)
        //        string savePath = appPath + saveDir + SourceFilename;
        //        file.SaveAs(savePath);
        //        SavePath = savePath;
        //    }
        //    return View();
        //}


        //string SavePath;
        //[HttpGet]
        //public ActionResult AddOrEdit3()
        //{
        //    var b = from d in db.CompanyVehicles
        //            select new
        //            {
        //                d.VehiclePhoto2
        //            };
        //        return View(b);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddOrEdit3( HttpPostedFileBase file)
        //{
        //    string SourceFilename = Path.GetFileName(file.FileName);
        //    string saveDir = "\\CarUpload\\";
        //    //根目錄
        //    string appPath = Request.PhysicalApplicationPath;
        //    //完整路徑(包含檔名)
        //    string savePath = appPath + saveDir + SourceFilename;
        //    file.SaveAs(savePath);
        //    SavePath = savePath;
        //    return Json(new { success = true, message = SavePath }, JsonRequestBehavior.AllowGet);
        //}

        //string SavePath;



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public void AddOrEdit3(CompanyVehicleViewModel b)
        //{
        //    string SourceFilename = Path.GetFileName(b.PhotoCar.FileName);
        //    string appPath = Request.PhysicalApplicationPath;
        //    string saveDir = "\\CarUpload\\";
        //    string savePath = appPath + saveDir + SourceFilename;
        //    string SavePath = savePath;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit2(CompanyVehicle b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                db.CompanyVehicles.Add(new CompanyVehicle()
                {
                    LicenseNumber = b.LicenseNumber,
                    VehicleYear = b.VehicleYear,
                    PurchaseDate = b.PurchaseDate,
                    brand = b.brand,
                    serial = b.serial,
                    MaxPassenger = b.MaxPassenger,
                    officeID = b.officeID
                    //VehiclePhoto2 = SavePath
                });
                db.SaveChanges();
                return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public ActionResult Delete(string id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                CompanyVehicle b = db.CompanyVehicles.Where(x => x.LicenseNumber == id).FirstOrDefault<CompanyVehicle>();
                db.CompanyVehicles.Remove(b);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);
            }

        }





















        // GET: CompanyVehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyVehicle companyVehicle = db.CompanyVehicles.Find(id);
            if (companyVehicle == null)
            {
                return HttpNotFound();
            }
            return View(companyVehicle);
        }

        // GET: CompanyVehicles/Create
        public ActionResult Create()
        {
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name");
            return View();
        }

        // POST: CompanyVehicles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LicenseNumber,VehicleYear,PurchaseDate,brand,serial,MaxPassenger,officeID,VehiclePhoto")] CompanyVehicle companyVehicle)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files["File1"].ContentLength != 0)
                {
                    byte[] data = null;
                    using (BinaryReader br = new BinaryReader(Request.Files["File1"].InputStream))
                    {
                        data = br.ReadBytes(Request.Files["File1"].ContentLength);
                    }
                    companyVehicle.VehiclePhoto = data;
                }
                db.CompanyVehicles.Add(companyVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //{
            //    db.CompanyVehicles.Add(companyVehicle);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", companyVehicle.officeID);
            return View(companyVehicle);
        }

        // GET: CompanyVehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyVehicle companyVehicle = db.CompanyVehicles.Find(id);
            if (companyVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", companyVehicle.officeID);
            return View(companyVehicle);
        }

        // POST: CompanyVehicles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LicenseNumber,VehicleYear,PurchaseDate,brand,serial,MaxPassenger,officeID,VehiclePhoto")] CompanyVehicle companyVehicle)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files["File1"].ContentLength != 0)
                {
                    byte[] data = null;
                    using (BinaryReader br = new BinaryReader(Request.Files["File1"].InputStream))
                    {
                        data = br.ReadBytes(Request.Files["File1"].ContentLength);
                    }
                    companyVehicle.VehiclePhoto = data;

                }
                else
                {
                    CompanyVehicle c = db.CompanyVehicles.Find(companyVehicle.LicenseNumber);
                    c.LicenseNumber = companyVehicle.LicenseNumber;
                    c.VehicleYear = companyVehicle.VehicleYear;
                    c.PurchaseDate = companyVehicle.PurchaseDate;
                    c.brand = companyVehicle.brand;
                    c.MaxPassenger = companyVehicle.MaxPassenger;
                    c.officeID = companyVehicle.officeID;
                    companyVehicle = c;
                }

                db.Entry(companyVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", companyVehicle.officeID);
            return View(companyVehicle);
        }

        // GET: CompanyVehicles/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyVehicle companyVehicle = db.CompanyVehicles.Find(id);
        //    if (companyVehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyVehicle);
        //}

        //// POST: CompanyVehicles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    CompanyVehicle companyVehicle = db.CompanyVehicles.Find(id);
        //    db.CompanyVehicles.Remove(companyVehicle);
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
        public FileResult ShowPhoto(string LicenceNumber)
        {
            byte[] content = db.CompanyVehicles.Find(LicenceNumber).VehiclePhoto;
            return File(content, "image/jpeg");
        }
    }
}
