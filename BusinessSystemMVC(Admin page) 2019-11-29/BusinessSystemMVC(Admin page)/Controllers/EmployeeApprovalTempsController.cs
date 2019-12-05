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
    public class EmployeeApprovalTempsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: EmployeeApprovalTemps
        public ActionResult Index()
        {
            //var employeeApprovalTemps = db.EmployeeApprovalTemps.Include(e => e.Employee).Include(e => e.Employee1).Include(e => e.Employee2);
            return View(/*employeeApprovalTemps*/);
        }

        [HttpGet]
        [Authorize(Roles = "GroupLeader,DepartmentLeader,HRGroup")]
        public ActionResult LoadData()
        {
            var q = db.EmployeeApprovalTemps.Where(p => p.SignState == false && ((p.Employee1.ManagerID == EmployeeDetail.EmployeeID && p.GroupLeaderID ==null )|| (p.Employee2.ManagerID == EmployeeDetail.EmployeeID && p.DepartmentLeaderID==null))).Select(p => new { p.EmployeeName, p.Gender, p.Account, p.Department.name, p.Group.GroupName, p.Position.position1, p.EditorTime, p.ID });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "GroupLeader,DepartmentLeader,HRGroup")]
        public ActionResult LoadDataDetail(int ID)
        {
            return View(db.EmployeeApprovalTemps.Where(p=>p.ID == ID).FirstOrDefault<EmployeeApprovalTemp>());
        }

        //[HttpGet]
        //[Authorize(Roles = "GroupLeader,DepartmentLeader,HRGroup")]
        //public ActionResult AcceptRegister(int ID)
        //{
        //    var q = db.EmployeeApprovalTemps.Where(p => p.ID == ID).FirstOrDefault();
        //    if(q.GroupLeaderID == null && q.SignState ==false &&q.Rejection == false && EmployeeDetail.GroupName== "人資組" && EmployeeDetail.PositionName== "組長")
        //    {
        //        q.GroupLeaderID = EmployeeDetail.EmployeeID;
        //        q.GroupLeaderSignTime = DateTime.Now;
        //        db.SaveChanges();
        //    }

        //    if (q.GroupLeaderID != null && q.DepartmentLeaderID ==null && q.SignState == false && q.Rejection == false && EmployeeDetail.DepartmentName == "行政部" && EmployeeDetail.PositionName == "部長")
        //    {
        //        q.DepartmentLeaderID = EmployeeDetail.EmployeeID;
        //        q.DepartmentLeaderSignTime = DateTime.Now;
        //        db.SaveChanges();
        //    }

        //    if (q.SignState == false && q.GroupLeaderID !=null && q.DepartmentLeaderID !=null && q.Rejection ==false)
        //    {
        //        q.SignState = true;
        //        q.Rejection = false;
        //        var addFormalEmployee = new Employee
        //        {
        //            EmployeeName = q.EmployeeName,
        //            Gender = q.Gender,
        //            Birth = q.Birth,
        //            HireDate = q.HireDate,
        //            Account = q.Account,
        //            OfficeID = q.OfficeID,
        //            DepartmentID = q.DepartmentID,
        //            PositionID = q.PositionID,
        //            ManagerID = q.ManagerID,
        //            Employed = true,
        //            GroupID = q.GroupID,
        //            Photo = q.Photo
        //        };
        //        db.Employees.Add(addFormalEmployee);
        //        db.SaveChanges();
        //    }            

        //    return 
        //}


        // GET: EmployeeApprovalTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApprovalTemp employeeApprovalTemp = db.EmployeeApprovalTemps.Find(id);
            if (employeeApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(employeeApprovalTemp);
        }

        // GET: EmployeeApprovalTemps/Create
        public ActionResult Create()
        {
            ViewBag.Editor = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.GroupLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.DepartmentLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }

        // POST: EmployeeApprovalTemps/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeName,Gender,Birth,HireDate,Account,OfficeID,DepartmentID,PositionID,ManagerID,Employed,GroupID,Photo,CreateOrUpdate,Editor,EditorTime,GroupLeaderID,GroupLeaderSignTime,DepartmentLeaderID,DepartmentLeaderSignTime,SignState")] EmployeeApprovalTemp employeeApprovalTemp)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeApprovalTemps.Add(employeeApprovalTemp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Editor = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.Editor);
            ViewBag.GroupLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.GroupLeaderID);
            ViewBag.DepartmentLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.DepartmentLeaderID);
            return View(employeeApprovalTemp);
        }

        // GET: EmployeeApprovalTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApprovalTemp employeeApprovalTemp = db.EmployeeApprovalTemps.Find(id);
            if (employeeApprovalTemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Editor = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.Editor);
            ViewBag.GroupLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.GroupLeaderID);
            ViewBag.DepartmentLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.DepartmentLeaderID);
            return View(employeeApprovalTemp);
        }

        // POST: EmployeeApprovalTemps/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeName,Gender,Birth,HireDate,Account,OfficeID,DepartmentID,PositionID,ManagerID,Employed,GroupID,Photo,CreateOrUpdate,Editor,EditorTime,GroupLeaderID,GroupLeaderSignTime,DepartmentLeaderID,DepartmentLeaderSignTime,SignState")] EmployeeApprovalTemp employeeApprovalTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeApprovalTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Editor = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.Editor);
            ViewBag.GroupLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.GroupLeaderID);
            ViewBag.DepartmentLeaderID = new SelectList(db.Employees, "employeeID", "EmployeeName", employeeApprovalTemp.DepartmentLeaderID);
            return View(employeeApprovalTemp);
        }

        // GET: EmployeeApprovalTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApprovalTemp employeeApprovalTemp = db.EmployeeApprovalTemps.Find(id);
            if (employeeApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(employeeApprovalTemp);
        }

        // POST: EmployeeApprovalTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeApprovalTemp employeeApprovalTemp = db.EmployeeApprovalTemps.Find(id);
            db.EmployeeApprovalTemps.Remove(employeeApprovalTemp);
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
