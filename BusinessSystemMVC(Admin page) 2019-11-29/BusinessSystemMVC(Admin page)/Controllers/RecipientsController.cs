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
    public class RecipientsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();


        public ActionResult LoadData()
        {
            //顯示
            var recipient = from r in db.Recipients
                            join m in db.Messages on r.MessageID equals m.MessageID
                            where r.EmployeeID == EmployeeDetail.EmployeeID
                            select new
                            {
                                r.EmployeeID,
                                m.Title,
                                m.Data,
                                m.MailingDate
                            };

            var recipients = recipient.ToList();

            return Json(new { data = recipients }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
                return View(new BulletinBoard());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Message m)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                db.Messages.Add(new Message
                {
                    EmployeeID = m.EmployeeID,
                    Title = m.Title,
                    Data = m.Data,
                    MailingDate = DateTime.Now,
                    //Recipients = new Recipients
                    //{
                    //    EmployeeID = 1001
                    //}
                        
                    });
                    db.SaveChanges();

                    return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
           
            }
        }

        // GET: Recipients/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipients recipient = db.Recipients.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }
        

        // GET: Recipients/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipients recipient = db.Recipients.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Recipients recipient = db.Recipients.Find(id);
            db.Recipients.Remove(recipient);
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
