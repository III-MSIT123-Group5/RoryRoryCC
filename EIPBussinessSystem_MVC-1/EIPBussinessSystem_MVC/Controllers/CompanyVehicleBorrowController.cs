﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class CompanyVehicleBorrowController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();
        List<string> firstLevelItems = new List<string>()
        {
            "上午","下午"
        };
        List<SecondLevelViewModel> secondLevelItems = new List<SecondLevelViewModel>();

        public CompanyVehicleBorrowController()
        {
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "上午", SecondLevel = "08:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "上午", SecondLevel = "09:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "上午", SecondLevel = "10:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "上午", SecondLevel = "11:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "上午", SecondLevel = "12:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "下午", SecondLevel = "01:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "下午", SecondLevel = "02:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "下午", SecondLevel = "03:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "下午", SecondLevel = "04:00" });
            secondLevelItems.Add(new SecondLevelViewModel() { FirstLevel = "下午", SecondLevel = "05:00" });
        }
        // GET: CompanyVehicleBorrow
        public ActionResult Index()
        {
            var items = (from c in firstLevelItems
                         select new SelectListItem { Text = c, Value = c }).ToList();
            items.Insert(0, new SelectListItem() { Text = "請選擇", Value = "-1" });
            ViewData["FirstLevelItems"] = items;
            var companyVehicleHistories = db.CompanyVehicleHistories.Include(c => c.CompanyVehicle).Include(c => c.Employee);
            return View(companyVehicleHistories);
        }

        [HttpGet]
        public ActionResult ShowSecondDropDownList(string FirstLevel)
        {
            //使用Linq撈出第二層的資料
            var items = (from s in secondLevelItems
                         where s.FirstLevel == FirstLevel
                         select new SelectListItem { Text = s.SecondLevel, Value = s.SecondLevel }).ToList();
            //加入「請選擇」
            items.Insert(0, new SelectListItem() { Text = "請選擇", Value = "-1" });
            ViewData["SecondLevelItems"] = items;
            return View();
        }

        
        public ActionResult Details(int? id)
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
            return View(companyVehicleHistory);
        }

        // GET: CompanyVehicleBorrow/Create
        public ActionResult Create()
        {
            ViewBag.LicenseNumber = new SelectList(db.CompanyVehicles, "LicenseNumber", "brand");
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }

        // POST: CompanyVehicleBorrow/Create
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

        // GET: CompanyVehicleBorrow/Edit/5
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

        // POST: CompanyVehicleBorrow/Edit/5
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

        // GET: CompanyVehicleBorrow/Delete/5
        public ActionResult Delete(int? id)
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
            return View(companyVehicleHistory);
        }

        // POST: CompanyVehicleBorrow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyVehicleHistory companyVehicleHistory = db.CompanyVehicleHistories.Find(id);
            db.CompanyVehicleHistories.Remove(companyVehicleHistory);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Search(DateTime beginTime, DateTime endTime)
        //{
        //    var Nlicence = from p in db.CompanyVehicleHistories
        //                   where (this.datetime1.datetime >= p.StartDateTime && this.dTPEndTime.Value <= p.EndDateTime) || ((this.dTPStartTime.Value >= p.StartDateTime && this.dTPStartTime.Value < p.EndDateTime) && this.dTPEndTime.Value > p.EndDateTime) || (this.dTPStartTime.Value < p.StartDateTime && (this.dTPEndTime.Value > p.StartDateTime && this.dTPEndTime.Value <= p.EndDateTime)) || (this.dTPStartTime.Value < p.StartDateTime && this.dTPEndTime.Value > p.EndDateTime)
        //                   select new { p.LicenseNumber };
        //    return.view();
        //}
        [HttpPost]
        public ActionResult dropdowntiming()
        {
            var selectList = new List<SelectListItem>()
            {
                new SelectListItem{Text="上午",Value="am"},
                new SelectListItem{Text="上午",Value="pm"}
            };
            selectList.Where(q => q.Value == "am").First().Selected = true;
            ViewBag.SelectList = selectList;
            return View();
        }

        
    }
}