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
using Microsoft.AspNet.Identity;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class CommentMainsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: CommentMains
        public ActionResult Index()
        {
            var commentMains = db.CommentMains.Include(c => c.ActivitiesMain).Include(c => c.CommentContent).Include(c => c.Employee);
            return View(commentMains.ToList());
        }

        // GET: CommentMains/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CommentMain commentMain = db.CommentMains.Find(id);
        //    if (commentMain == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(commentMain);
        //}

        //Get //no use
        public ActionResult LoadCommentContent()
        {
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
                          b.Num,
                          emp.Photo
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //Get
        public ActionResult LoadEmployee()
        {
            var q1 = from d in db.Departments
                     select new { d.name,d.departmentID };

            return Json(q1, JsonRequestBehavior.AllowGet);
        }

        //get
        public ActionResult LoadQuestion()
        {
            var q1 = from cc in db.CommentContents
                     join q in db.CommentQuestions
                     on cc.CommentContentID equals q.CommentContentID
                     select new { cc.CommentContentID,q.CommentQuestionID,q.Question};

            return Json(q1, JsonRequestBehavior.AllowGet);
        }

        // GET: CommentMains/Create
        [HttpGet]
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
                return View(new CommentMain());

            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentMains.Where(x => x.CommentMainID == id).FirstOrDefault<CommentMain>());
                }
            }

        }

        public ActionResult ViewContent(int id = 0)
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
                return View(new CommentMain());

            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.CommentMains.Where(x => x.CommentMainID == id).FirstOrDefault<CommentMain>());
                }
            }

        }


        [HttpGet]
        public ActionResult GetDepartmentID(/*int [] array*/)
        {


                var q100 = from emp in db.Employees
                           select new { emp.employeeID,emp.DepartmentID };

                return Json(q100, JsonRequestBehavior.AllowGet);
            
        }
        //string[] array;
        //int count = 0 ;
        //public void test(string a )
        //{
        //    array[count] = a;
        //    count++;
        //}

        //[AllowAnonymous]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CommentMain c, int cid,string cname, string [] array )
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                
                int ccID = 101;

                ccID = cid;

                ArrayList question = new ArrayList();

                var dup = db.CommentQuestions.Where(x => x.CommentContentID == ccID)/*.GroupBy(x => new { x.CommentContentID })*/
                .Select(p => p);
                int countQ = 0;
                countQ = dup.Count();
                //foreach (var x in dup)
                //{
                //}


                var q2 = from cq in db.CommentQuestions
                         where cq.CommentContentID == ccID
                         select new { cq.CommentQuestionID };

                var q3 = q2.ToList();




                if (c.CommentMainID == 0)
                {

                    int EmpID = EmployeeDetail.EmployeeID;



                    db.CommentMains.Add(new CommentMain()
                    {
                        CommentName = cname,
                        SendTime = DateTime.Now,
                        EmployeeID = EmpID, //發布者
                        CommentContentID = ccID,
                        //CommentMainID = c.CommentMainID,
                    });
                    db.SaveChanges();

                    var getid = (from cc in db.CommentMains
                                 select cc.CommentMainID).Max();

                    for (int j = 0; j < array.Count(); j++)
                    {
                        for (int i = 0; i < countQ; i++)
                        {
                    //for (int j = 0; j < array.Count(); j++)
                    //{
                    //    for (int i = 0; i < q3.Count; i++)
                    //    {

                    //        db.CommentChilds.Add(new CommentChild()
                    //        {
                    //            CommentMainID = c.CommentMainID,
                    //            EmployeeID = int.Parse(array[j]), //接收者
                    //            CommentQuestionID = q3[i].CommentQuestionID,

                    //        });

                            db.CommentChilds.Add(new CommentChild()
                            {
                                CommentMainID = getid,
                                EmployeeID = int.Parse(array[j]), //接收者
                                CommentQuestionID = q3[i].CommentQuestionID,

                            });
                            db.SaveChanges();
                        }
                    }

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
        

        public ActionResult LoadData()
        {

            var data = from c in db.CommentMains
                       join emp in db.Employees
                       on c.EmployeeID equals emp.employeeID
                       join ct in db.CommentContents
                       on c.CommentContentID equals ct.CommentContentID
                       select new
                       {
                           c.CommentName,
                           c.SendTime,
                           emp.EmployeeName,
                           c.CommentMainID,
                           ct.CommentContent1,
                           c.CommentContentID
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
           
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
                return View(new CommentMain());
                
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {
                    //ViewBag.CommentContentID = new SelectList(cc, "CommentContentID", "CommentContent1");

                    //ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");

                    return View(db.CommentMains.Where(x => x.CommentMainID == id).FirstOrDefault<CommentMain>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(CommentMain c,FormCollection formCollection)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (c.CommentMainID == 0)
                {

                    int EmpID = EmployeeDetail.EmployeeID;

                    int ccID = 102;

                    ccID = Convert.ToInt32(formCollection["CommentContent"]);

                    db.CommentMains.Add(new CommentMain()
                    {
                        CommentName = c.CommentName,
                        SendTime = DateTime.Now,
                        EmployeeID = EmpID,                        
                        CommentContentID = ccID, 
                        CommentMainID = c.CommentMainID,
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
                CommentMain c = db.CommentMains.Where(x => x.CommentMainID == id).FirstOrDefault<CommentMain>();
                db.CommentMains.Remove(c);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }


        [HttpGet]
        public ActionResult Observe(int id)
        {
            
                return View(new CommentMain() { CommentMainID = id});

            
           
        }


        [HttpGet]
        public ActionResult RateData(int cmid)
        {

            int empid = EmployeeDetail.EmployeeID;

            var report = from cr in db.CommentReplies
                         join cm in db.CommentMains
                         on cr.CommentMainID equals cm.CommentMainID
                         join cc in db.CommentChilds
                         on cr.ChildNum equals cc.ChildNum
                         join cq in db.CommentQuestions
                         on cc.CommentQuestionID equals cq.CommentQuestionID
                         group cr by new {cr.CommentMainID,cr.CommentMain.CommentName,cr.CommentChild.CommentQuestion.CommentQuestionID, cr.CommentChild.CommentQuestion.Question} into n
                         orderby n.Key.CommentQuestionID
                         where n.Key.CommentMainID == cmid
                         select new
                         {
                             
                             n.Key.CommentName,
                             n.Key.CommentQuestionID,
                             n.Key.Question,
                             Average = Math.Round((Double)n.Average(p=>p.Rate),1)

                         };

            var data = report.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        //[HttpGet]
        //public ActionResult ObserveData()
        //{
        //    var report = from cm in db.CommentMains
        //                 join cc in db.CommentChilds
        //                 on cm.CommentMainID equals cc.CommentMainID
        //                 join emp in db.Employees
        //                 on cc.EmployeeID equals emp.employeeID
        //                 join de in db.Departments
        //                 on emp.DepartmentID equals de.departmentID
        //                 join cr in db.CommentReplies
        //                 on cm.CommentMainID equals cr.CommentMainID
        //                 select new
        //                 {
        //                     cm.CommentName,
        //                     de.name, //部門                            
        //                    cr.ReplyNum,
        //                    cr.Rate,
        //                    cc.ChildNum
        //                 };

        //    var data = report.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        // POST: CommentMains/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CommentMainID,CommentName,EmployeeID,SendTime,CommentContentID,ActivityMainID")] CommentMain commentMain)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CommentMains.Add(commentMain);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ActivityMainID = new SelectList(db.ActivitiesMains, "ActivityMainID", "ActivityName", commentMain.ActivityMainID);
        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentMain.CommentContentID);
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentMain.EmployeeID);
        //    return View(commentMain);
        //}

        //// GET: CommentMains/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CommentMain commentMain = db.CommentMains.Find(id);
        //    if (commentMain == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ActivityMainID = new SelectList(db.ActivitiesMains, "ActivityMainID", "ActivityName", commentMain.ActivityMainID);
        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentMain.CommentContentID);
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentMain.EmployeeID);
        //    return View(commentMain);
        //}

        // POST: CommentMains/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CommentMainID,CommentName,EmployeeID,SendTime,CommentContentID,ActivityMainID")] CommentMain commentMain)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(commentMain).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ActivityMainID = new SelectList(db.ActivitiesMains, "ActivityMainID", "ActivityName", commentMain.ActivityMainID);
        //    ViewBag.CommentContentID = new SelectList(db.CommentContents, "CommentContentID", "CommentContent1", commentMain.CommentContentID);
        //    ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", commentMain.EmployeeID);
        //    return View(commentMain);
        //}

        // GET: CommentMains/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CommentMain commentMain = db.CommentMains.Find(id);
        //    if (commentMain == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(commentMain);
        //}

        //// POST: CommentMains/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CommentMain commentMain = db.CommentMains.Find(id);
        //    db.CommentMains.Remove(commentMain);
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
