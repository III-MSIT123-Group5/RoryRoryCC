using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class MeetingRoomsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: MeetingRooms
        public ActionResult Index()
        {
            var meetingRooms = db.MeetingRooms.Include(m => m.Office);
            return View(meetingRooms.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            //var UserID = User.Identity.GetUserId();
            //var Acc = db.AspNetUsers.Find(UserID);
            //var Empquery = db.Employees.Where(f => f.Account.Equals(Acc.UserName)).Select(f => new { f.employeeID });
            //int EmpID = 0;
            //foreach (var e in Empquery)
            //{
            //    EmpID = e.employeeID;
            //}

            if (files.First() != null)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    string SourceFilename = Path.GetFileName(file.FileName);
                    string TargetFilename = Path.Combine(Server.MapPath(
                        "~/Uploads"), SourceFilename);
                    file.SaveAs(TargetFilename);


                    db.Files.Add(new BusinessSystemMVC_Admin_page_.Models.File
                    {
                        FileName = SourceFilename,
                        Data = TargetFilename,
                        FileSize = file.ContentLength.ToString(),
                        EmployeeID = EmployeeDetail.EmployeeID,
                        /* LoginID,*/
                        UploadDate = DateTime.Now,
                        Extension = Path.GetExtension(file.FileName)
                    });
                    //儲存修改
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

















        public ActionResult LoadData()
        {//.OrderBy(b => b.PostTime).ToList();

            var data = from m in db.MeetingRooms
                       select new
                       {
                           m.meetingID,
                           m.officeID,
                           m.max_member,
                           m.RoomAddress,
                           m.meetingName
                       };

            var datas = data.ToList();

            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        //id=0

        [HttpGet]
        public ActionResult AddOrEdit(string id)
        {

            if (id == null)
            {
                return View(new MeetingRoom());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.MeetingRooms.Where(x => x.meetingID == id).FirstOrDefault<MeetingRoom>());
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(MeetingRoom b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();

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




        [HttpGet]
        public ActionResult AddOrEdit2(string id)
        {

            if (id == null)
            {
                return View(new MeetingRoom());
            }
            else
            {
                using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
                {

                    return View(db.MeetingRooms.Where(x => x.meetingID == id).FirstOrDefault<MeetingRoom>());
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit2(MeetingRoom b)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                db.MeetingRooms.Add(new MeetingRoom()
                {
                    meetingID = b.meetingID,
                    officeID = b.officeID,
                    max_member = b.max_member,
                    meetingName = b.meetingName,
                    RoomAddress = b.RoomAddress
                });
                db.SaveChanges();

                return Json(new { success = true, message = "發布成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(string id )
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                MeetingRoom b = db.MeetingRooms.Where(x => x.meetingID == id).FirstOrDefault<MeetingRoom>();
                db.MeetingRooms.Remove(b);
                db.SaveChanges();
                return Json(new { success = true, message = "刪除成功" }, JsonRequestBehavior.AllowGet);
            }

        }






















        // GET: MeetingRooms/Details/5
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

        // GET: MeetingRooms/Create
        public ActionResult Create()
        {
            ViewBag.officeID = new SelectList(db.Offices, "officeID", "office_name");
            return View();
        }

        // POST: MeetingRooms/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "meetingID,officeID,max_member")] MeetingRoom meetingRoom)
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

        // GET: MeetingRooms/Edit/5
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

        // POST: MeetingRooms/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "meetingID,officeID,max_member")] MeetingRoom meetingRoom)
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

        // GET: MeetingRooms/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
        //    if (meetingRoom == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(meetingRoom);
        //}

        //// POST: MeetingRooms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    MeetingRoom meetingRoom = db.MeetingRooms.Find(id);
        //    db.MeetingRooms.Remove(meetingRoom);
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
