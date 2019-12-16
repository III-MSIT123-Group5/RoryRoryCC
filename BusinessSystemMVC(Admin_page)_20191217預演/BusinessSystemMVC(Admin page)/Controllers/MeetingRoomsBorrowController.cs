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
    public class MeetingRoomsBorrowController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: MeetingRooms1
        public ActionResult Index()
        {
            var meetingRooms = db.MeetingRooms.Include(m => m.Office);
            return View(meetingRooms.ToList());
        }


        [AllowAnonymous]
        public void Post1(DateTime dtS, DateTime dtE, string LNid)
        {
            var saveMeetingRoom = new BusinessSystemMVC_Admin_page_.Models.MeetingRoomHistory
            {
                start_date_time = dtS,
                end_date_time = dtE,
                employeeID = EmployeeDetail.EmployeeID,
                meetingID = LNid,
            };
            db.MeetingRoomHistories.Add(saveMeetingRoom);
            db.SaveChanges();
        }

        public ActionResult Finded1()
        {
            var Canuse = from c in db.MeetingRooms
                         select new
                         {
                             c.meetingID,
                             c.meetingName,
                             c.officeID,
                             officeName = c.Office.office_name,
                             c.max_member,
                             c.RoomAddress
                         };
            return Json(Canuse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Finded()
        {
            var items = from p in db.MeetingRoomHistories
                        select new
                        {
                            p.meetingID,
                            p.start_date_time,
                            p.end_date_time
                        };
            var jsonitems = Json(items);
            return Json(items, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getchange([Bind(Include = "LicenseNumber,StartDateTime,EndDateTime,purpose")]CompanyVehicleHistory companyVehicleHistory)
        {
            if (ModelState.IsValid)
            {
                db.CompanyVehicleHistories.Add(companyVehicleHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyVehicleHistory);
        }















        // GET: MeetingRooms1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            if (meetingRoom == null)
            {
                return HttpNotFound();
            }
            return View(meetingRoom);
        }

        // GET: MeetingRooms1/Create
        public ActionResult Create()
        {
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name");
            return View();
        }

        // POST: MeetingRooms1/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "meetingID,meetingName,officeID,max_member,RoomAddress")] MeetingRoom meetingRoom)
        {
            if (ModelState.IsValid)
            {
                db.MeetingRooms.Add(meetingRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", meetingRoom.officeID);
            return View(meetingRoom);
        }

        // GET: MeetingRooms1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            if (meetingRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", meetingRoom.officeID);
            return View(meetingRoom);
        }

        // POST: MeetingRooms1/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "meetingID,meetingName,officeID,max_member,RoomAddress")] MeetingRoom meetingRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name", meetingRoom.officeID);
            return View(meetingRoom);
        }

        // GET: MeetingRooms1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            if (meetingRoom == null)
            {
                return HttpNotFound();
            }
            return View(meetingRoom);
        }

        // POST: MeetingRooms1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
            db.MeetingRooms.Remove(meetingRoom);
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
