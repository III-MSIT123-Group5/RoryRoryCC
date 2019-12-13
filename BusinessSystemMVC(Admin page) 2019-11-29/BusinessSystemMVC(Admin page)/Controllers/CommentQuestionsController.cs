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
    public class CommentQuestionsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: CommentQuestions
        public ActionResult Index()
        {
            var commentQuestions = db.CommentQuestions.Include(c => c.CommentContent);
            return View(commentQuestions.ToList());
        }

        //Get
        public ActionResult ReadyLoadCommentContent(FormCollection formCollection)
        {

            var data = from cq in db.CommentQuestions
                       join cc in db.CommentContents
                       on cq.CommentContentID equals cc.CommentContentID
                       select new
                       {
                           cc.CommentContent1,
                           cq.CommentQuestionID,
                           cq.Question
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //Get
        [HttpPost]
        public ActionResult LoadCommentContent(/*FormCollection formCollection*/int cid)
        {
            //    int ccid = Convert.ToInt32(formCollection["CommentContent"]);
        
            var data = from cq in db.CommentQuestions
                       join cc in db.CommentContents 
                       on cq.CommentContentID equals cc.CommentContentID
                       where cq.CommentContentID == cid
                       select new
                       {
                           cq.CommentContentID,
                           cc.CommentContent1,
                           cq.CommentQuestionID,
                           cq.Question
                       };

            var datas = data.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LoadCommentContent(FormCollection formCollection,int cid)
        //{
        //    //int ccid = Convert.ToInt32(formCollection["CommentContent"]);

        //    var data = from cq in db.CommentQuestions
        //               join cc in db.CommentContents
        //               on cq.CommentContentID equals cc.CommentContentID
        //               where cq.CommentContentID == cid
        //               select new
        //               {
        //                   cc.CommentContentID,
        //                   cc.CommentContent1,
        //                   cq.CommentQuestionID,
        //                   cq.Question
        //               };

        //    var datas = data.ToList();

        //    return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        //}

        //Get
        public ActionResult LoadEmployee()
        {
            var q1 = from d in db.Departments
                     select new { d.name };

            return Json(q1, JsonRequestBehavior.AllowGet);
        }

        //get
        public ActionResult LoadQuestion()
        {
            var q1 = from cc in db.CommentContents
                     join q in db.CommentQuestions
                     on cc.CommentContentID equals q.CommentContentID
                     select new { cc.CommentContentID, q.CommentQuestionID, q.Question };

            return Json(q1, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {


            int EmpID = EmployeeDetail.EmployeeID;

            var result = from cc in db.CommentContents
                         join co in db.CommentOptions
                         on cc.CommentOptionID equals co.CommentOptionID
                         select new
                         {
                             cc.CommentOptionID,
                             co.CommentOption1,
                             cc.CommentContent1,
                             cc.CommentContentID
                         };

            var items = new List<GroupedSelectListItem>();

            foreach (var n in result)
            {
                items.Add(new GroupedSelectListItem()
                {
                    Value = n.CommentContentID.ToString(),
                    Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
                    GroupKey = n.CommentOptionID.ToString(),
                    GroupName = n.CommentOption1

                });
            }

            ViewBag.CommentContentItems = items;



            if (id == 0)
            {
                return View(new CommentQuestion());

            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {
                    //ViewBag.CommentContentID = new SelectList(cc, "CommentContentID", "CommentContent1");

                    //ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");

                    return View(db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CommentQuestion c, FormCollection formCollection)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (c.CommentQuestionID == 0)
                {

                    int EmpID = EmployeeDetail.EmployeeID;

                    int ccID = 102;

                    ccID = Convert.ToInt32(formCollection["CommentContent"]);

                    db.CommentQuestions.Add(new CommentQuestion()
                    {
                        Question = c.Question,
                        //CommentQuestionID = c.CommentQuestionID,
                        CommentContentID = ccID,

                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "調查發布成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "調查修改成功" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                CommentQuestion c = db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>();
                db.CommentQuestions.Remove(c);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }



        public ActionResult Create(int id = 0)
        {
            int EmpID = EmployeeDetail.EmployeeID;

            var result = from cc in db.CommentContents
                         join co in db.CommentOptions
                         on cc.CommentOptionID equals co.CommentOptionID
                         select new
                         {
                             cc.CommentOptionID,
                             co.CommentOption1,
                             cc.CommentContent1,
                             cc.CommentContentID
                         };

            var items = new List<GroupedSelectListItem>();

            foreach (var n in result)
            {
                items.Add(new GroupedSelectListItem()
                {
                    Value = n.CommentContentID.ToString(),
                    Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
                    GroupKey = n.CommentOptionID.ToString(),
                    GroupName = n.CommentOption1

                });
            }

            ViewBag.CommentContentItems = items;



            if (id == 0)
            {
                return View(new CommentQuestion());

            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>());
                }
            }


        }















        // GET: CommentQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
            if (commentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(commentQuestion);
        }

        // GET: CommentQuestions/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1");
        //    return View();
        //}

        // POST: CommentQuestions/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.CommentQuestions.Add(commentQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
            return View(commentQuestion);
        }

        // GET: CommentQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
            if (commentQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
            return View(commentQuestion);
        }

        // POST: CommentQuestions/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
            return View(commentQuestion);
        }

        // GET: CommentQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
            if (commentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(commentQuestion);
        }

        // POST: CommentQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
            db.CommentQuestions.Remove(commentQuestion);
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
