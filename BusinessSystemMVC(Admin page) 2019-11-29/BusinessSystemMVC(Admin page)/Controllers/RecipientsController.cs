using BusinessSystemMVC_Admin_page_.Models;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class RecipientsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: Recipients
        public ActionResult Index()
        {
            var recipients = db.Recipients.Include(r => r.Employee).Include(r => r.Message);
            return View(recipients.ToList());
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public ActionResult LoadData()
        {
            //顯示
            var recipient = from r in db.Recipients
                            join emp in db.Employees
                            on r.EmployeeID equals emp.employeeID
                            join m in db.Messages 
                            on r.MessageID equals m.MessageID
                            where r.EmployeeID == EmployeeDetail.EmployeeID
                            select new
                            {
                                m.MessageID,
                                emp.EmployeeName,
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
            return View(new Recipient());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Recipient r)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                db.Recipients.Add(new Recipient
                {
                    EmployeeID = EmployeeDetail.EmployeeID,
                    Status = "0",

                    Message = (new Message
                    {
                        EmployeeID = r.Message.EmployeeID,
                        Title = r.Message.Title,
                        Data = r.Message.Data,
                        MailingDate = DateTime.Now,
                        Status="0"
                    })

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
            Recipient recipient = db.Recipients.Find(id);
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
            Recipient recipient = db.Recipients.Find(id);
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
            Recipient recipient = db.Recipients.Find(id);
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
