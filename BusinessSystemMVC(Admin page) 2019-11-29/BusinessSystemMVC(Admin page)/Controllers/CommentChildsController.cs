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

        [HttpGet]
        public ActionResult Test()
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                //var q = (from p in db.CommentChilds
                //         join l in db.CommentReplies on p.CommentMainID equals l.CommentMainID
                //         where p.ChildNum != l.ChildNum && p.EmployeeID == EmployeeDetail.EmployeeID
                //         select new
                //        {
                //            p.CommentMainID,
                //        }).Distinct().ToList();
                var q = db.CommentChilds
                    .Where(x=>x.EmployeeID == EmployeeDetail.EmployeeID)
                    .Where(x => !db.CommentReplies.Any(y => y.CommentChild.ChildNum == x.ChildNum)).Select(z=>z.CommentMainID).Distinct().ToList();

                if (q.Count() != 0)
                {
                    var k = q.Count();
                    return Json(new { len = k }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            
                

            };
        }









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

            int empid = EmployeeDetail.EmployeeID;

            var data = (from cm in db.CommentMains
                        join cc in db.CommentChilds
                        on cm.CommentMainID equals cc.CommentMainID
                        join emp in db.Employees
                        on cm.EmployeeID equals emp.employeeID
                        where cc.EmployeeID == empid 
                        select new
                        {
                            //cc.ChildNum,
                            //cm.CommentContentID,
                            //cm.SendTime,
                            cm.CommentMainID,
                            postperson = emp.EmployeeName,
                            cm.CommentName,
                            //replyperson = cc.EmployeeID,

                        }).Distinct();




            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //id=0
        [HttpGet]
        public ActionResult Reply(int id)
        {

            if (id == 0)
            {
                return View(new CommentChild());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentMains.Where(x => x.CommentMainID == id).FirstOrDefault());
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


        [HttpGet]
        public ActionResult GetQuestions(int id)
        {

            var data = (from cq in db.CommentQuestions
                       join cm in db.CommentMains
                       on cq.CommentContentID equals cm.CommentContentID
                       where cm.CommentMainID == id
                       select new
                       {
                           //cm.CommentMainID,
                           //cm.CommentName,
                           //cq.CommentQuestionID,
                           cq.Question
                       }).Distinct();
        


            //var datas = data.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public ActionResult GetTopics(int id)
        {

            var data = (from cq in db.CommentQuestions
                        join cm in db.CommentMains
                        on cq.CommentContentID equals cm.CommentContentID
                        where cm.CommentMainID == id
                        select new
                        {
                            cm.CommentName,

                        }).Distinct();



            //var datas = data.ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PostComment(string str ,int cid)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                int empid = EmployeeDetail.EmployeeID;

                var q = db.CommentChilds.Where(x=>x.CommentMainID==cid && x.EmployeeID == empid).Select(x => x.ChildNum).ToArray();

                string [] rate = str.Split('&');
                List <int>lastChar = new List<int>();

                for (int j=1;j< rate.Length;j++)
                {
                    lastChar.Add(Convert.ToInt32(rate[j].Substring(rate[j].Length - 1)));
                }



                for (int i=0; i<q.Length;i++)
                {

                    db.CommentReplies.Add(new CommentReply()
                    {

                     ChildNum = q[i],
                     Rate = lastChar[i],
                     ReplyTime = DateTime.Now,
                     CommentMainID = cid,
                     
                     });

                    db.SaveChanges();
                }



             return Json(new { success = true, message = "意見送出成功" }, JsonRequestBehavior.AllowGet);

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
