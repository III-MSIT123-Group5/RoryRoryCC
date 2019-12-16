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
    public class CommentChildsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: CommentChilds
        public ActionResult Index()
        {
            var commentChilds = db.CommentChilds.Include(c => c.CommentMain).Include(c => c.CommentQuestion).Include(c => c.Employee);
            return View(commentChilds.ToList());
        }

        // GET: CommentChilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentChild commentChild = db.CommentChilds.Find(id);
            if (commentChild == null)
            {
                return HttpNotFound();
            }
            return View(commentChild);
        }

        public ActionResult LoadData()
        {
            var data = from cm in db.CommentMains
                       join cc in db.CommentChilds
                       on cm.CommentMainID equals cc.CommentMainID
                       select new
                       {
                           cc.Num,
                           cm.CommentMainID,
                           postperson = cm.EmployeeID,
                           cm.CommentName,
                           replyperson = cc.EmployeeID,
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }

        //id=0
        [HttpGet]
        public ActionResult Reply(int id = 0)
        {


            //var data = from cc in db.CommentChilds
            //           join cm in db.CommentMains
            //           on cc.CommentMainID equals cm.CommentMainID
            //           select new
            //           {
            //               cm.CommentMainID,
            //               postperson = cm.EmployeeID,
            //               cm.CommentName,
            //               replyperson = cc.EmployeeID,
            //           };



            if (id == 0)
            {
                return View(new CommentChild());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentChilds.Where(x => x.Num == id).FirstOrDefault<CommentChild>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply(CommentChild c)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                    //var data = from cc in db.CommentChilds
                    //           join cm in db.CommentMains
                    //           on cc.CommentMainID equals cm.CommentMainID
                    //           select new
                    //           {
                    //               cm.CommentMainID,
                    //               postperson = cm.EmployeeID,
                    //               cm.CommentName,
                    //               replyperson = cc.EmployeeID,
                    //           };

                    int empid = EmployeeDetail.EmployeeID;

                

                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "已送出回覆" }, JsonRequestBehavior.AllowGet);
                

            }
        }



        // GET: CommentChilds/Create
        public ActionResult Create()
        {
            ViewBag.CommentMainID = new SelectList(db.CommentMains, "CommentMainID", "CommentName");
            ViewBag.CommentQuestionID = new SelectList(db.CommentQuestions, "CommentQuestionID", "Question");
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            return View();
        }

        // POST: CommentChilds/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentMainID,Num,EmployeeID,CommentQuestionID,Rate,ReplyTime")] CommentChild commentChild)
        {
            if (ModelState.IsValid)
            {
                db.CommentChilds.Add(commentChild);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentMainID = new SelectList(db.CommentMains, "CommentMainID", "CommentName", commentChild.CommentMainID);
            ViewBag.CommentQuestionID = new SelectList(db.CommentQuestions, "CommentQuestionID", "Question", commentChild.CommentQuestionID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentChild.EmployeeID);
            return View(commentChild);
        }

        // GET: CommentChilds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentChild commentChild = db.CommentChilds.Find(id);
            if (commentChild == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentMainID = new SelectList(db.CommentMains, "CommentMainID", "CommentName", commentChild.CommentMainID);
            ViewBag.CommentQuestionID = new SelectList(db.CommentQuestions, "CommentQuestionID", "Question", commentChild.CommentQuestionID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentChild.EmployeeID);
            return View(commentChild);
        }

        // POST: CommentChilds/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentMainID,Num,EmployeeID,CommentQuestionID,Rate,ReplyTime")] CommentChild commentChild)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentChild).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentMainID = new SelectList(db.CommentMains, "CommentMainID", "CommentName", commentChild.CommentMainID);
            ViewBag.CommentQuestionID = new SelectList(db.CommentQuestions, "CommentQuestionID", "Question", commentChild.CommentQuestionID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentChild.EmployeeID);
            return View(commentChild);
        }

        // GET: CommentChilds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentChild commentChild = db.CommentChilds.Find(id);
            if (commentChild == null)
            {
                return HttpNotFound();
            }
            return View(commentChild);
        }

        // POST: CommentChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentChild commentChild = db.CommentChilds.Find(id);
            db.CommentChilds.Remove(commentChild);
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
