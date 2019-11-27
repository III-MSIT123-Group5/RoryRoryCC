using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using BusinessSystemMVC_Admin_page_.ViewModels;
using Microsoft.AspNet.Identity;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class BulletinBoardsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();


        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }


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
                           b.Num

                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }

    
    //id=0
    [HttpGet]
    public ActionResult AddOrEdit(int? id)
    {
        var userid = User.Identity.GetUserId();
        var account = db.AspNetUsers.Find(userid);


        int UserID = Convert.ToInt32(userid);


        if (id == 0)
        {
            return View(new BulletinBoard());
        }
        else
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var bb = db.BulletinBoards.FirstOrDefault(x => x.Num == id.Value);
                var emp = db.Employees.FirstOrDefault(x => x.employeeID == UserID);

                BulletinBoardEmployeeViewModel vm = new BulletinBoardEmployeeViewModel();
                vm.BulletinBoardData = bb;
                vm.EmployeesCollection = emp;

                return View(vm);

                //return View(db.BulletinBoards.Where(x => x.Num == id).FirstOrDefault<BulletinBoard>());
            }
        }

    }

    [HttpPost]
    public ActionResult AddOrEdit(BulletinBoard b)
    {
        using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
        {
            if (b.EmployeeID == 0)
            {
                db.BulletinBoards.Add(b);
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
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
        {
            BulletinBoard b = db.BulletinBoards.Where(x => x.Num == id).FirstOrDefault<BulletinBoard>();
            db.BulletinBoards.Remove(b);
            db.SaveChanges();

            return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


        }

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
    //public ActionResult Delete(long? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
    //    if (bulletinBoard == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(bulletinBoard);
    //}

    //// POST: BulletinBoards/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public ActionResult DeleteConfirmed(long id)
    //{
    //    BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
    //    db.BulletinBoards.Remove(bulletinBoard);
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

