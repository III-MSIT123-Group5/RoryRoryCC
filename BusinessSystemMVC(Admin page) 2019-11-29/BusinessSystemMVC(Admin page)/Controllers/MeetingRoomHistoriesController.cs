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
    public class MeetingRoomHistoriesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: MeetingRoomHistories
        public ActionResult Index()
        {
            var meetingRoomHistories = db.MeetingRoomHistories.Include(m => m.Employee).Include(m => m.MeetingRoom);
            return View(meetingRoomHistories.ToList());
        }


        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();

            var data = from b in db.MeetingRoomHistories
                       where b.employeeID == EmployeeDetail.EmployeeID
                       select new
                       {
                           b.MeetingRoomID,
                           b.meetingID,
                           meetName = b.MeetingRoom.meetingName,
                           address = b.MeetingRoom.RoomAddress,
                           b.start_date_time,
                           b.end_date_time,
                           empName = b.Employee.EmployeeName
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        //id=0
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                return View(new MeetingRoomHistory());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.MeetingRoomHistories.Where(x => x.MeetingRoomID == id).FirstOrDefault<MeetingRoomHistory>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(MeetingRoomHistory b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (b.MeetingRoomID == 0)
                {

                }
                else
                {
                    db.Entry(b).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);

                //var saveCars = new BusinessSystemMVC_Admin_page_.Models.CompanyVehicleHistory
                //{
                //    VehicleHistoryID = b.VehicleHistoryID,
                //    StartDateTime = b.StartDateTime,
                //    EndDateTime = b.EndDateTime,
                //    employeeID = b.employeeID,
                //    purpose = b.purpose
                //};
                //return Json(new { success = true, message = "修改成功" }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                MeetingRoomHistory b = db.MeetingRoomHistories.Where(x => x.MeetingRoomID == id).FirstOrDefault<MeetingRoomHistory>();
                db.MeetingRoomHistories.Remove(b);
                db.SaveChanges();

                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);


            }

        }






















        // GET: MeetingRoomHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRoomHistory meetingRoomHistory = db.MeetingRoomHistories.Find(id);
            if (meetingRoomHistory == null)
            {
                return HttpNotFound();
            }
            return View(meetingRoomHistory);
        }

        // GET: MeetingRoomHistories/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName");
            ViewBag.meetingID = new SelectList(db.MeetingRooms, "meetingID", "meetingName");
            return View();
        }

        // POST: MeetingRoomHistories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingRoomID,meetingID,start_date_time,end_date_time,employeeID")] MeetingRoomHistory meetingRoomHistory)
        {
            if (ModelState.IsValid)
            {
                db.MeetingRoomHistories.Add(meetingRoomHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", meetingRoomHistory.employeeID);
            ViewBag.meetingID = new SelectList(db.MeetingRooms, "meetingID", "meetingName", meetingRoomHistory.meetingID);
            return View(meetingRoomHistory);
        }

        // GET: MeetingRoomHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRoomHistory meetingRoomHistory = db.MeetingRoomHistories.Find(id);
            if (meetingRoomHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", meetingRoomHistory.employeeID);
            ViewBag.meetingID = new SelectList(db.MeetingRooms, "meetingID", "meetingName", meetingRoomHistory.meetingID);
            return View(meetingRoomHistory);
        }

        // POST: MeetingRoomHistories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingRoomID,meetingID,start_date_time,end_date_time,employeeID")] MeetingRoomHistory meetingRoomHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingRoomHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", meetingRoomHistory.employeeID);
            ViewBag.meetingID = new SelectList(db.MeetingRooms, "meetingID", "meetingName", meetingRoomHistory.meetingID);
            return View(meetingRoomHistory);
        }

        // GET: MeetingRoomHistories/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MeetingRoomHistory meetingRoomHistory = db.MeetingRoomHistories.Find(id);
        //    if (meetingRoomHistory == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(meetingRoomHistory);
        //}

        //// POST: MeetingRoomHistories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MeetingRoomHistory meetingRoomHistory = db.MeetingRoomHistories.Find(id);
        //    db.MeetingRoomHistories.Remove(meetingRoomHistory);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
