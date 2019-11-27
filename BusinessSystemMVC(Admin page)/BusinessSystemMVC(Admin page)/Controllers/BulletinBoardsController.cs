using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class BulletinBoardsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: BulletinBoards
        public ActionResult Index()
        {
            var bulletinBoards = db.BulletinBoards.Include(b => b.Department).Include(b => b.Employee).Include(b => b.Group).Include(b => b.Employee1);
            return View(bulletinBoards.ToList());
        }

        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();
           
                var data = from b in db.BulletinBoards
                           join emp in db.Employees
                           on b.EmployeeID equals emp.employeeID
                           join d in db.Departments
                           on b.DepartmentID equals d.departmentID
                           select new
                           {
                               b.Content,
                               b.PostTime,
                               d.name,
                               emp.EmployeeName,
                               
                           };

                //var datas = data.OrderBy(o => o.PostTime).ToList();

                //return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
                return Json(data, JsonRequestBehavior.AllowGet );
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
            if (ModelState.IsValid)
            {
                db.BulletinBoards.Add(bulletinBoard);
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
