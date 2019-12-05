using BusinessSystemMVC_Admin_page_.Models;
using System;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
                            on r.Message.EmployeeID equals emp.employeeID
                            join m in db.Messages
                            on r.MessageID equals m.MessageID
                            where r.EmployeeID == EmployeeDetail.EmployeeID && r.Status.Equals("true")
                            select new
                            {
                                r.RecipientID,
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
                    EmployeeID = r.EmployeeID,
                    Status = "true",

                    Message = (new Message
                    {
                        EmployeeID = EmployeeDetail.EmployeeID,
                        Title = r.Message.Title,
                        Data = r.Message.Data,
                        MailingDate = DateTime.Now,
                        Status = "true"
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {


                var recipient = db.Recipients.Where(r => r.RecipientID == id && r.Status.Equals("true")).FirstOrDefault();
                recipient.Status = "false";
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);
            }
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
