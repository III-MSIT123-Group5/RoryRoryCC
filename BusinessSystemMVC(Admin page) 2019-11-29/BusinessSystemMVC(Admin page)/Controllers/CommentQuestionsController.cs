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
        public ActionResult Index(int id = 0)
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

            //var commentQuestions = db.CommentQuestions.Include(c => c.CommentContent);
            //return View(commentQuestions.ToList());
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
            //ViewBag.CommentContentItems = items;
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
                        CommentQuestionID = c.CommentQuestionID,
                        CommentContentID = ccID,

                    });
                    db.SaveChanges();
                    return Json(new { success = true, message = "成功新建調查項目" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "成功修改調查項目" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        //[HttpGet]
        //public ActionResult AddOrEdit2(int id = 0)
        //{
        //    int EmpID = EmployeeDetail.EmployeeID;

        //    var result = from cc in db.CommentContents
        //                 join co in db.CommentOptions
        //                 on cc.CommentOptionID equals co.CommentOptionID
        //                 select new
        //                 {
        //                     cc.CommentOptionID,
        //                     co.CommentOption1,
        //                     cc.CommentContent1,
        //                     cc.CommentContentID
        //                 };

        //    var items = new List<GroupedSelectListItem>();
        //    foreach (var n in result)
        //    {
        //        items.Add(new GroupedSelectListItem()
        //        {
        //            Value = n.CommentContentID.ToString(),
        //            Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
        //            GroupKey = n.CommentOptionID.ToString(),
        //            GroupName = n.CommentOption1

        //        });
        //    }
        //    ViewBag.CommentContentItems = items;
        //    if (id == 0)
        //    {
        //        return View(new CommentQuestion());

        //    }
        //    else
        //    {
        //        using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
        //        {

        //            return View(db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>());
        //        }
        //    }

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddOrEdit2(CommentQuestion c, FormCollection formCollection)
        //{
        //    using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
        //    {
        //            int EmpID = EmployeeDetail.EmployeeID;
        //            int ccID = 102;
        //            ccID = Convert.ToInt32(formCollection["CommentContent"]);

        //            db.CommentQuestions.Add(new CommentQuestion()
        //            {
        //                Question = c.Question,
        //                //CommentQuestionID = c.CommentQuestionID,
        //                CommentContentID = ccID,

        //            });
        //            db.SaveChanges();
        //            return Json(new { success = true, message = "成功新建調查項目" }, JsonRequestBehavior.AllowGet);


        //    }
        //}


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




        public ActionResult Display()
        {
            ViewBag.Message = "編輯分類、主題、調查選項";

            SelectList selectList = new SelectList(this.GetOptions(), "CommentOptionID", "CommentOption1");
            ViewBag.SelectList = selectList;

            return View();
        }


        private IEnumerable<CommentOption> GetOptions()
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var query = db.CommentOptions.OrderBy(x => x.CommentOptionID);
                return query.ToList();
            }
        }


        [HttpPost]
        public JsonResult DisplayContents(int commentOptionID)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            if (commentOptionID != 0)
            {
                var contents = this.GetContents(commentOptionID);
                if (contents.Count() > 0)
                {
                    foreach (var c in contents)
                    {
                        items.Add(new KeyValuePair<string, string>(
                            c.CommentContentID.ToString(),
                            string.Format("{0} {1}", c.CommentContentID, c.CommentContent1)));
                    }
                }
            }
            return this.Json(items);
        }


        private IEnumerable<CommentContent> GetContents(int commentOptionID)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var query = db.CommentContents.Where(x => x.CommentOptionID == commentOptionID).OrderBy(x => x.CommentOptionID);
                return query.ToList();
            }
        }



        [HttpPost]
        public JsonResult DisplayQuestions(string commentContentID)
        {
            //List<string> items = new List<string>();

            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();


            //if (commentContentID != 0)
            int id = 0;

            if (!string.IsNullOrWhiteSpace(commentContentID) && int.TryParse(commentContentID, out id))
            {
                var questions = this.GetQuestions(id);

                if (questions.Count() > 0)
                {
                    foreach (var question in questions)
                    {
                        //items.Add(question.Question);

                        items.Add(new KeyValuePair<string, string>(
                        question.CommentQuestionID.ToString(),
                        question.Question
                        ));
                    }
                }                
            }
            return this.Json(items);
        }


        private IEnumerable<CommentQuestion> GetQuestions(int commentContentID)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var query = db.CommentQuestions.Where(x => x.CommentContentID == commentContentID).OrderBy(x=>x.CommentQuestionID);
                return query.ToList();
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


        //調查分類
        [HttpGet]
        public ActionResult DisplayCommentOptions()
        {

            return View();
        }

        [HttpGet]
        public ActionResult LoadCommentOptions()
        {

            var data = from co in db.CommentOptions
                       select new
                       {
                           co.CommentOptionID,
                           co.CommentOption1
                       };

            var datas = data.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrEditCO(int id = 0)
        {

            if (id == 0)
            {
                return View(new CommentOption());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentOptions.Where(x => x.CommentOptionID == id).FirstOrDefault<CommentOption>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEditCO(CommentOption c)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (c.CommentOptionID == 0)
                {

                    db.CommentOptions.Add(new CommentOption()
                    {
                        //CommentOptionID = c.CommentOptionID,
                        CommentOption1 = c.CommentOption1,

                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpPost]
        public ActionResult DeleteCO(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                CommentOption c = db.CommentOptions.Where(x => x.CommentOptionID == id).FirstOrDefault<CommentOption>();
                db.CommentOptions.Remove(c);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }

        //調查主題
        [HttpGet]
        public ActionResult DisplayCommentContents()
        {
            ViewBag.Message = "編輯分類、主題、調查選項";

            SelectList selectList = new SelectList(this.GetOptions(), "CommentOptionID", "CommentOption1");
            ViewBag.SelectList = selectList;

            return View();
        }

        [HttpGet]
        public ActionResult LoadCommentContents()
        {

            var data = from cc in db.CommentContents
                       join co in db.CommentOptions
                       on cc.CommentOptionID equals co.CommentOptionID
                       select new
                       {
                           cc.CommentContentID,
                           cc.CommentContent1,
                           cc.CommentOptionID,
                           co.CommentOption1
                       };

            var datas = data.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult LoadAndChangeCommentContent(int cid)
        {

            var data = from cc in db.CommentContents
                       join co in db.CommentOptions
                       on cc.CommentOptionID equals co.CommentOptionID
                       where cc.CommentOptionID == cid
                       select new
                       {
                           cc.CommentContentID,
                           cc.CommentContent1,
                           cc.CommentOptionID,
                           co.CommentOption1
                       };

            var datas = data.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEditCC(int id = 0)
        {

            if (id == 0)
            {
                return View(new CommentContent());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentContents.Where(x => x.CommentContentID == id).FirstOrDefault<CommentContent>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEditCC(CommentContent c)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (c.CommentContentID == 0)
                {

                    db.CommentContents.Add(new CommentContent()
                    {
                        CommentOptionID = c.CommentOptionID,
                        CommentContent1 = c.CommentContent1,
                        CommentContentID = c.CommentContentID,

                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpPost]
        public ActionResult DeleteCC(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                CommentContent c = db.CommentContents.Where(x => x.CommentContentID == id).FirstOrDefault<CommentContent>();
                db.CommentContents.Remove(c);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CommentQuestions.Add(commentQuestion);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
        //    return View(commentQuestion);
        //}

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
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
        //    if (commentQuestion == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(commentQuestion);
        //}

        // POST: CommentQuestions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
        //    db.CommentQuestions.Remove(commentQuestion);
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


//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using BusinessSystemMVC_Admin_page_.Models;

//namespace BusinessSystemMVC_Admin_page_.Controllers
//{
//    public class CommentQuestionsController : Controller
//    {
//        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

//        public ActionResult Index()
//        {
//            int EmpID = EmployeeDetail.EmployeeID;

//            var result = from cc in db.CommentContents
//                         join co in db.CommentOptions
//                         on cc.CommentOptionID equals co.CommentOptionID
//                         select new
//                         {
//                             cc.CommentOptionID,
//                             co.CommentOption1,
//                             cc.CommentContent1,
//                             cc.CommentContentID
//                         };

//            var items = new List<GroupedSelectListItem>();

//            foreach (var n in result)
//            {
//                items.Add(new GroupedSelectListItem()
//                {
//                    Value = n.CommentContentID.ToString(),
//                    Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
//                    GroupKey = n.CommentOptionID.ToString(),
//                    GroupName = n.CommentOption1

//                });
//            }

//            ViewBag.CommentContentItems = items;

//            //var commentQuestions = db.CommentQuestions.Include(c => c.CommentContent);
//            //return View(commentQuestions.ToList());
//            return View();
//        }

//        //Get
//        public ActionResult ReadyLoadCommentContent(FormCollection formCollection)
//        {

//            var data = from cq in db.CommentQuestions
//                       join cc in db.CommentContents
//                       on cq.CommentContentID equals cc.CommentContentID
//                       select new
//                       {
//                           cc.CommentContent1,
//                           cq.CommentQuestionID,
//                           cq.Question
//                       };

//            var datas = data.ToList();

//            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
//        }

//        //Get
//        [HttpPost]
//        public ActionResult LoadCommentContent(int cid)
//        {
//            //    int ccid = Convert.ToInt32(formCollection["CommentContent"]);

//            var data = from cq in db.CommentQuestions
//                       join cc in db.CommentContents
//                       on cq.CommentContentID equals cc.CommentContentID
//                       where cq.CommentContentID == cid
//                       select new
//                       {
//                           cq.CommentContentID,
//                           cc.CommentContent1,
//                           cq.CommentQuestionID,
//                           cq.Question
//                       };

//            var datas = data.ToList();
//            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
//        }


//        //Get
//        public ActionResult LoadEmployee()
//        {
//            var q1 = from d in db.Departments
//                     select new { d.name };

//            return Json(q1, JsonRequestBehavior.AllowGet);
//        }

//        //get
//        public ActionResult LoadQuestion()
//        {
//            var q1 = from cc in db.CommentContents
//                     join q in db.CommentQuestions
//                     on cc.CommentContentID equals q.CommentContentID
//                     select new { cc.CommentContentID, q.CommentQuestionID, q.Question };

//            return Json(q1, JsonRequestBehavior.AllowGet);
//        }


//        [HttpGet]
//        public ActionResult AddOrEdit(int id = 0)
//        {


//            //int EmpID = EmployeeDetail.EmployeeID;

//            //var result = from cc in db.CommentContents
//            //             join co in db.CommentOptions
//            //             on cc.CommentOptionID equals co.CommentOptionID
//            //             select new
//            //             {
//            //                 cc.CommentOptionID,
//            //                 co.CommentOption1,
//            //                 cc.CommentContent1,
//            //                 cc.CommentContentID
//            //             };

//            //var items = new List<GroupedSelectListItem>();

//            //foreach (var n in result)
//            //{
//            //    items.Add(new GroupedSelectListItem()
//            //    {
//            //        Value = n.CommentContentID.ToString(),
//            //        Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
//            //        GroupKey = n.CommentOptionID.ToString(),
//            //        GroupName = n.CommentOption1

//            //    });
//            //}

//            //ViewBag.CommentContentItems = items;



//            if (id == 0)
//            {
//                return View(new CommentQuestion());

//            }
//            else
//            {
//                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
//                {

//                    return View(db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>());
//                }
//            }
//        }

//        string test1;
//        public void test(string id)
//        {
//            test1 = id;
//        }

//        [HttpPost]
//        //[ValidateAntiForgeryToken]
//        public ActionResult AddOrEdit(CommentQuestion c,string id)
//        {
//            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
//            {

//                if (c.CommentQuestionID == 0)
//                {

//                    int EmpID = EmployeeDetail.EmployeeID;

//                    //int ccID = 101;

//                    //ccID = Convert.ToInt32(formCollection["CommentContent"]);


//                    db.CommentQuestions.Add(new CommentQuestion()
//                    {
//                        Question = c.Question,
//                        //CommentQuestionID = ,
//                        CommentContentID = Convert.ToInt32(id),

//                    });
//                    db.SaveChanges();

//                    return Json(new { success = true, message = "成功新建調查項目" }, JsonRequestBehavior.AllowGet);
//                }
//                else
//                {
//                    db.Entry(c).State = EntityState.Modified;
//                    db.SaveChanges();

//                    return Json(new { success = true, message = "成功修改調查項目" }, JsonRequestBehavior.AllowGet);
//                }

//            }
//        }







//        [HttpPost]
//        public ActionResult Delete(int id)
//        {
//            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
//            {
//                CommentQuestion c = db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>();
//                db.CommentQuestions.Remove(c);
//                db.SaveChanges();

//                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


//            }

//        }



//        public ActionResult Create(int id = 0)
//        {
//            int EmpID = EmployeeDetail.EmployeeID;

//            var result = from cc in db.CommentContents
//                         join co in db.CommentOptions
//                         on cc.CommentOptionID equals co.CommentOptionID
//                         select new
//                         {
//                             cc.CommentOptionID,
//                             co.CommentOption1,
//                             cc.CommentContent1,
//                             cc.CommentContentID
//                         };

//            var items = new List<GroupedSelectListItem>();

//            foreach (var n in result)
//            {
//                items.Add(new GroupedSelectListItem()
//                {
//                    Value = n.CommentContentID.ToString(),
//                    Text = string.Format("{0} {1}", n.CommentContentID.ToString(), n.CommentContent1),
//                    GroupKey = n.CommentOptionID.ToString(),
//                    GroupName = n.CommentOption1

//                });
//            }

//            ViewBag.CommentContentItems = items;



//            if (id == 0)
//            {
//                return View(new CommentQuestion());

//            }
//            else
//            {
//                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
//                {

//                    return View(db.CommentQuestions.Where(x => x.CommentQuestionID == id).FirstOrDefault<CommentQuestion>());
//                }
//            }


//        }















//        // GET: CommentQuestions/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
//            if (commentQuestion == null)
//            {
//                return HttpNotFound();
//            }
//            return View(commentQuestion);
//        }

//        // GET: CommentQuestions/Create
//        //public ActionResult Create()
//        //{
//        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1");
//        //    return View();
//        //}

//        // POST: CommentQuestions/Create
//        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
//        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Create([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        db.CommentQuestions.Add(commentQuestion);
//        //        db.SaveChanges();
//        //        return RedirectToAction("Index");
//        //    }

//        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
//        //    return View(commentQuestion);
//        //}

//        // GET: CommentQuestions/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
//            if (commentQuestion == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
//            return View(commentQuestion);
//        }

//        // POST: CommentQuestions/Edit/5
//        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
//        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(commentQuestion).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
//            return View(commentQuestion);
//        }

//        // GET: CommentQuestions/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
//            if (commentQuestion == null)
//            {
//                return HttpNotFound();
//            }
//            return View(commentQuestion);
//        }

//        // POST: CommentQuestions/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
//            db.CommentQuestions.Remove(commentQuestion);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        //        protected override void Dispose(bool disposing)
//        //        {
//        //            if (disposing)
//        //            {
//        //                db.Dispose();
//        //            }
//        //            base.Dispose(disposing);
//        //        }
////    }
////}
////        // GET: CommentQuestions
////        public ActionResult Index()
////        {
////            var commentQuestions = db.CommentQuestions.Include(c => c.CommentContent);
////            return View(commentQuestions.ToList());
////        }

////        // GET: CommentQuestions/Details/5
////        public ActionResult Details(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
////            if (commentQuestion == null)
////            {
////                return HttpNotFound();
////            }
////            return View(commentQuestion);
////        }

////        // GET: CommentQuestions/Create
////        public ActionResult Create()
////        {
////            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1");
////            return View();
////        }

////        // POST: CommentQuestions/Create
////        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
////        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Create([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
////        {
////            if (ModelState.IsValid)
////            {
////                db.CommentQuestions.Add(commentQuestion);
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }

////            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
////            return View(commentQuestion);
////        }

////        // GET: CommentQuestions/Edit/5
////        public ActionResult Edit(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
////            if (commentQuestion == null)
////            {
////                return HttpNotFound();
////            }
////            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
////            return View(commentQuestion);
////        }

////        // POST: CommentQuestions/Edit/5
////        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
////        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
////        [HttpPost]
////        [ValidateAntiForgeryToken]
////        public ActionResult Edit([Bind(Include = "CommentContentID,CommentQuestionID,Question")] CommentQuestion commentQuestion)
////        {
////            if (ModelState.IsValid)
////            {
////                db.Entry(commentQuestion).State = EntityState.Modified;
////                db.SaveChanges();
////                return RedirectToAction("Index");
////            }
////            ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentQuestion.CommentContentID);
////            return View(commentQuestion);
////        }

////        // GET: CommentQuestions/Delete/5
////        public ActionResult Delete(int? id)
////        {
////            if (id == null)
////            {
////                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
////            }
////            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
////            if (commentQuestion == null)
////            {
////                return HttpNotFound();
////            }
////            return View(commentQuestion);
////        }

////        // POST: CommentQuestions/Delete/5
////        [HttpPost, ActionName("Delete")]
////        [ValidateAntiForgeryToken]
////        public ActionResult DeleteConfirmed(int id)
////        {
////            CommentQuestion commentQuestion = db.CommentQuestions.Find(id);
////            db.CommentQuestions.Remove(commentQuestion);
////            db.SaveChanges();
////            return RedirectToAction("Index");
////        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
