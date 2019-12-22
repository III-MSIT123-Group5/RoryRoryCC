using BusinessSystemMVC_Admin_page_.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            return View();
        }
        public ActionResult MessageIndex()
        {
            return View();
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
                            //join Dep in db.Departments
                            //on emp.DepartmentID equals Dep.departmentID
                            where r.EmployeeID == EmployeeDetail.EmployeeID && r.Status.Equals("true")
                            select new
                            {
                                r.RecipientID,
                                emp.EmployeeName,
                                m.Title,
                                m.Data,
                                m.MailingDate,
                                //Dep.name
                            };

            var recipients = recipient.ToList();

            return Json(new { data = recipients }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MessageLoadData()
        {
            //顯示
            var recipient = from r in db.Recipients
                            join emp in db.Employees
                            on r.EmployeeID equals emp.employeeID
                            join m in db.Messages
                            on r.MessageID equals m.MessageID
                            //join Dep in db.Departments
                            //on emp.DepartmentID equals  Dep.departmentID
                            where r.Message.EmployeeID == EmployeeDetail.EmployeeID && r.Message.Status.Equals("true")
                            select new
                            {
                                m.MessageID,
                                emp.EmployeeName,
                                m.Title,
                                m.Data,
                                m.MailingDate,
                                //Dep.name
                            };

            var recipients = recipient.ToList();

            return Json(new { data = recipients }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            SelectList selectList = new SelectList(this.GetDepartments(), "departmentID", "name");
            ViewBag.SelectList = selectList;
            return View(new Recipient());
        }

        private IEnumerable<Department> GetDepartments()
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var query = db.Departments.OrderBy(x => x.departmentID);
                return query.ToList();
            }
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


        [HttpPost]
        public JsonResult GetEmployee(int departmentID)
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(departmentID.ToString()))
            {
                var query = db.Employees.Where(x => x.DepartmentID==(departmentID)).ToList();
                if (query.Count() > 0)
                {
                    foreach (var Employee in query)
                    {
                        items.Add(new KeyValuePair<string, string>(
                            Employee.employeeID.ToString(), Employee.EmployeeName));
                    }
                }
            }
            return this.Json(items);
        }

        [HttpPost]
        public JsonResult AddDepartment()
        {
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();

            foreach(var item in (SelectList)ViewBag.SelectList)
            {
                items.Add(new KeyValuePair<string, string>(
                           item.Value,item.Text));
            }

                
            
            return this.Json(items);
        }



        //// GET: Recipients/Details/5
        //public ActionResult Details(int? id)
        //{
        //    var recipient = from r in db.Recipients
        //                    join emp in db.Employees
        //                    on r.Message.EmployeeID equals emp.employeeID
        //                    join m in db.Messages
        //                    on r.MessageID equals m.MessageID
        //                    join Dep in db.Departments
        //                    on emp.DepartmentID equals Dep.departmentID
        //                    where r.EmployeeID == EmployeeDetail.EmployeeID && r.Status.Equals("true")
        //                    select new
        //                    {
        //                        r.RecipientID,
        //                        emp.EmployeeName,
        //                        m.Title,
        //                        m.Data,
        //                        m.MailingDate,
        //                        Dep.name
        //                    };

        //    var recipients = recipient.FirstOrDefault();
        //    return View(recipients);
        //}


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

        // GET: Recipients/Delete/5
        [HttpPost]
        public ActionResult DeleteMessage(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                var message = db.Messages.Where(m => m.MessageID == id && m.Status.Equals("true")).FirstOrDefault();
                message.Status = "false";
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
