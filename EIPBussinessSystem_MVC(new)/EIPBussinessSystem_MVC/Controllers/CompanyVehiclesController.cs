using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;

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
        public ActionResult Delete(string id)
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

        // POST: CompanyVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CompanyVehicle companyVehicle = db.CompanyVehicles.Find(id);
            db.CompanyVehicles.Remove(companyVehicle);
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
        public FileResult ShowPhoto(string LicenceNumber)
        {
            byte[] content = db.CompanyVehicles.Find(LicenceNumber).VehiclePhoto;
            return File(content, "image/jpeg");
        }
    }
}
