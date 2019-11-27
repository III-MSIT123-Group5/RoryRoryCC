using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;
using EIPBussinessSystem_MVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class BulletinBoardsController : Controller
    {
        private BusinessDataBaseEntities1 db = new BusinessDataBaseEntities1();

        // GET: BulletinBoards
        public ActionResult Index()
        {
            var bulletinBoards = db.BulletinBoards.Include(b => b.Department).Include(b => b.Employee).Include(b => b.Group).Include(b => b.Employee1);
            return View(bulletinBoards.ToList());
        }

        // GET: BulletinBoards/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");

            return View();
        }

        // POST: BulletinBoards/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num,EmployeeID,DepartmentID,GroupID,Content,PostTime")] BulletinBoard bulletinBoard)
        {
            int DID = 0;
            int GID = 0;


            var userid = User.Identity.GetUserId();
            var acc = db.AspNetUsers.Find(userid);
            var empquery = from em in db.Employees
                           where em.Account == acc.UserName
                           select new { em.employeeID };
            int EmpID = 0;
            foreach (var e in empquery)
            {
                EmpID = e.employeeID;
            }

            //var Emp = db.Employees.Find(EmpID);


            var q = from em in this.db.Employees.AsEnumerable()
                     where em.employeeID == EmpID
                     select new { em.GroupID, em.DepartmentID };

            foreach (var n in q)
            {
                DID = Convert.ToInt32(n.DepartmentID);
                GID = Convert.ToInt32(n.GroupID);
            }



            if (ModelState.IsValid)
            {
                db.BulletinBoards.Add(new Models.BulletinBoard
                {
                    EmployeeID = EmpID,
                    GroupID = GID,
                    DepartmentID = DID,
                    Content = bulletinBoard.Content,
                    PostTime = DateTime.Now,

                });

                db.SaveChanges();
                return RedirectToAction("Index");
            }

           ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", bulletinBoard.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", bulletinBoard.GroupID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", bulletinBoard.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", bulletinBoard.GroupID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            return View(bulletinBoard);
        }

        // POST: BulletinBoards/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num,EmployeeID,DepartmentID,GroupID,Content,PostTime")] BulletinBoard bulletinBoard)
        {
            int DID = 0;
            int GID = 0;


            var userid = User.Identity.GetUserId();
            var acc = db.AspNetUsers.Find(userid);
            var empquery = from em in db.Employees
                           where em.Account == acc.UserName
                           select new { em.employeeID };
            int EmpID = 0;
            foreach (var e in empquery)
            {
                EmpID = e.employeeID;
            }

            //var Emp = db.Employees.Find(EmpID);


            var q = from em in this.db.Employees.AsEnumerable()
                    where em.employeeID == EmpID
                    select new { em.GroupID, em.DepartmentID };

            foreach (var n in q)
            {
                DID = Convert.ToInt32(n.DepartmentID);
                GID = Convert.ToInt32(n.GroupID);
            }

            //var q2 = from b in this.db.BulletinBoards
            //         where b.Num ==
            //         select b;
            //new Models.BulletinBoard
            //{
            //    EmployeeID = EmpID,
            //    GroupID = GID,
            //    DepartmentID = DID,
            //    Content = bulletinBoard.Content,
            //    PostTime = DateTime.Now,

            //}

            if (ModelState.IsValid)
            {

                db.Entry(bulletinBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "departmentID", "name", bulletinBoard.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", bulletinBoard.GroupID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", bulletinBoard.EmployeeID);
            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        // POST: BulletinBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            db.BulletinBoards.Remove(bulletinBoard);
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
