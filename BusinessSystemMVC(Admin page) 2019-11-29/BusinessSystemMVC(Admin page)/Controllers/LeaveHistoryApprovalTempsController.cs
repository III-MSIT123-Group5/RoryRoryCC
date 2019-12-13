using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using BusinessSystemMVC_Admin_page_.ViewModels;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class LeaveHistoryApprovalTempsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: LeaveHistoryApprovalTemps
        public ActionResult Index()
        {
            //var leaveHistoryApprovalTemps = db.LeaveHistoryApprovalTemps.Include(l => l.Employee).Include(l => l.Employee1).Include(l => l.Employee2).Include(l => l.Employee3).Include(l => l.Employee4).Include(l => l.Employee5);
            return View(/*leaveHistoryApprovalTemps*/);
        }

        //請假簽核
        public ActionResult LeaveSigntureIndex()
        {
            return View();
        }

        //請假簽核LoadData
        [Authorize(Roles = "DepartmentLeader,GroupLeader,GeneralManager")]
        [HttpGet]
        public ActionResult LeaveSigntureLoadData()
        {
            var q = db.LeaveHistoryApprovalTemps.Where(p => p.SignState == false && p.Reject == false).Select(p=> p   );
            //.Select(p => new { p.Employee.EmployeeName, p.Leave.leave_name, p.Employee.Department.name, p.Employee.Group.GroupName, p.Employee.Position.position1, p.ReleaseTime, p.StartTime, p.EndTime, p.ID })
             if(EmployeeDetail.PositionID == 3)
            {
                q.Where(p => p.GroupLeader == null && p.Employee.ManagerID == EmployeeDetail.EmployeeID).Select(p => new { p.Employee.EmployeeName, p.Leave.leave_name, p.Employee.Department.name, p.Employee.Group.GroupName, p.Employee.Position.position1, p.ReleaseTime, p.StartTime, p.EndTime, p.ID });
            }



            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //取消申請
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CancelLeave(int ID)
        {
            db.LeaveHistoryApprovalTemps.Remove(db.LeaveHistoryApprovalTemps.Where(p => p.ID == ID).FirstOrDefault());
            db.SaveChanges();
            return Json(new { success = true, message = "成功取消申請！" }, JsonRequestBehavior.AllowGet);
        }

        //載入申請中的假詳細資料
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LeaveLoadDataDetail(int ID)
        {
            return View(db.LeaveHistoryApprovalTemps.Where(p => p.ID == ID).FirstOrDefault());
        }

        //載入申請中的假
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LeaveLoadData()
        {
            var q = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID).Select(p => new { p.ID, p.Leave.leave_name, p.ReleaseTime, p.StartTime, p.EndTime, p.Status });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }


        // GET: LeaveHistoryApprovalTemps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(leaveHistoryApprovalTemp);
        }

        //新增請假
        // GET: LeaveHistoryApprovalTemps/Create
        public ActionResult Create()
        {
            int ThisYear = DateTime.Now.Year;
            List<int> SYList = new List<int>();
            List<int> SMList = new List<int>();
            List<int> SDList = new List<int>();
            List<int> SHList = new List<int>();
            List<int> EYList = new List<int>();
            List<int> EMList = new List<int>();
            List<int> EDList = new List<int>();
            List<int> EHList = new List<int>();
            for (int i = ThisYear - 1; i <= ThisYear + 1; i++)
            {
                SYList.Add(i);
                EYList.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                SMList.Add(i);
                EMList.Add(i);
            }
            for (int i = 1; i <= 31; i++)
            {
                SDList.Add(i);
                EDList.Add(i);
            }
            for (int i = 9; i < 12; i++)
            {
                SHList.Add(i);
            }
            for (int i = 13; i < 17; i++)
            {
                SHList.Add(i);
            }
            for (int i = 10; i <= 12; i++)
            {
                EHList.Add(i);
            }
            for (int i = 14; i <= 17; i++)
            {
                EHList.Add(i);
            }
            ViewBag.leaveID = new SelectList(db.Leaves, "leaveID", "leave_name");
            ViewBag.StartYear = new SelectList(SYList.Select(p => new { SYtxt = p.ToString(), SYval = p }), "SYval", "SYtxt");
            ViewBag.StartMonth = new SelectList(SMList.Select(p => new { SMtxt = p.ToString(), SMval = p }), "SMval", "SMtxt");
            ViewBag.StartDay = new SelectList(SDList.Select(p => new { SDtxt = p.ToString(), SDval = p }), "SDval", "SDtxt");
            ViewBag.StartHour = new SelectList(SHList.Select(p => new { SHtxt = p.ToString(), SHval = p }), "SHval", "SHtxt");
            ViewBag.EndYear = new SelectList(EYList.Select(p => new { EYtxt = p.ToString(), EYval = p }), "EYval", "EYtxt");
            ViewBag.EndMonth = new SelectList(EMList.Select(p => new { EMtxt = p.ToString(), EMval = p }), "EMval", "EMtxt");
            ViewBag.EndDay = new SelectList(EDList.Select(p => new { EDtxt = p.ToString(), EDval = p }), "EDval", "EDtxt");
            ViewBag.EndHour = new SelectList(EHList.Select(p => new { EHtxt = p.ToString(), EHval = p }), "EHval", "EHtxt");
            return View();
        }
        //新增請假
        // POST: LeaveHistoryApprovalTemps/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(LeaveHistoryApprovalTempViewModel VM)
        {
            if (ModelState.IsValid)
            {
                var emp = db.Employees.Find(EmployeeDetail.EmployeeID);
                var NewLeave = new LeaveHistoryApprovalTemp();
                NewLeave.StartTime = new DateTime(VM.StartYear, VM.StartMonth, VM.StartDay, VM.StartHour, 0, 0);
                NewLeave.EndTime = new DateTime(VM.EndYear, VM.EndMonth, VM.EndDay, VM.EndHour, 0, 0);
                int  LeaveHours = Convert.ToInt32((NewLeave.EndTime - NewLeave.StartTime).TotalHours);  //總時數
                var HoursDeRest = LeaveHours;   //請假時數
                var qLeaveList = db.LeaveHistories.Where(p => p.employeeID == EmployeeDetail.EmployeeID && ((NewLeave.StartTime >= p.StartTime && NewLeave.StartTime < p.EndTime) || (NewLeave.EndTime > p.StartTime && NewLeave.EndTime <= p.EndTime))).Select(p=>p.employeeID);
                var qLeaveTemp = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID && ((NewLeave.StartTime >= p.StartTime && NewLeave.StartTime < p.EndTime) || (NewLeave.EndTime > p.StartTime && NewLeave.EndTime <= p.EndTime))).Select(p => p.employeeID);
                if (qLeaveList.Any() || qLeaveTemp.Any())  //驗證請假日期衝突   *popup要開著
                {
                    return Json(new { fail = true, message = "選擇的日期已請假或己申請，請再次確認。" }, JsonRequestBehavior.AllowGet);
                }
                if (LeaveHours < 0)   //驗證日期   *popup要開著
                {
                    return Json(new { fail = true, message = "日期選擇無效，結束日期不可大於起始日期。" }, JsonRequestBehavior.AllowGet);
                }
                //======時數邏輯>>>>>>>>>>>>>
                if (VM.StartHour < 12 && VM.EndHour > 13)
                {
                    if (LeaveHours >= 24)
                    {
                        HoursDeRest = LeaveHours / 24 * 7 + LeaveHours % 24 - 1;
                    }
                    else
                    {
                        HoursDeRest--;
                    }
                }
                else if (VM.StartHour > 12 && VM.EndHour <= 17)
                {
                    if (LeaveHours >= 24)
                    {
                        HoursDeRest = LeaveHours / 24 * 7 + LeaveHours % 24;
                    }
                }
                else
                {
                    if (LeaveHours >= 24)
                    {
                        HoursDeRest = LeaveHours / 24 * 7 + LeaveHours % 24;
                    }
                }
                //======時數邏輯<<<<<<<<<<<<<<<
                NewLeave.employeeID = EmployeeDetail.EmployeeID;
                NewLeave.leaveID = VM.leaveID;
                NewLeave.ReleaseTime = DateTime.Now;
                NewLeave.Description = VM.Description;
                NewLeave.Appendix = VM.Appendix;
                NewLeave.SignState = false;
                NewLeave.Reject = false;
                if (EmployeeDetail.PositionID == 2)  //部長
                {
                    NewLeave.GroupLeader = 1022;
                    NewLeave.GroupLeaderSignTime = NewLeave.ReleaseTime;
                    NewLeave.DepartmentLeader = 1022;
                    NewLeave.DepartmentLeaderSignTime = NewLeave.ReleaseTime;
                    NewLeave.Status = "待總經理簽核";
                }
                else if (EmployeeDetail.PositionID == 4 || EmployeeDetail.PositionID == 3) //員工或組長
                {
                    if (EmployeeDetail.PositionID == 3) //組長
                    {
                        NewLeave.GroupLeader = 1022;
                        NewLeave.GroupLeaderSignTime = NewLeave.ReleaseTime;
                    }
                    if (HoursDeRest < 21)  //小於三天(21小時) GM無須簽核
                    {
                        NewLeave.GeneralManager = 1022;
                        NewLeave.GeneralManagerSignTime = NewLeave.ReleaseTime;
                        if (EmployeeDetail.PositionID == 3)
                            NewLeave.Status = "待部長簽核";
                        else   //員工
                            NewLeave.Status = "待組長簽核";
                    }
                    else
                    {
                        NewLeave.Status = "待總經理簽核";
                    }
                }
                else   //總經理
                {
                    NewLeave.GroupLeader = 1022;
                    NewLeave.GroupLeaderSignTime = NewLeave.ReleaseTime;
                    NewLeave.DepartmentLeader = 1022;
                    NewLeave.DepartmentLeaderSignTime = NewLeave.ReleaseTime;
                    NewLeave.GeneralManager = EmployeeDetail.EmployeeID;
                    NewLeave.GeneralManagerSignTime = NewLeave.ReleaseTime;
                    NewLeave.Status = "簽核完成";
                }
                db.LeaveHistoryApprovalTemps.Add(NewLeave);
                db.SaveChanges();
                return Json(new { success = true, message = "成功送出申請！" }, JsonRequestBehavior.AllowGet);
            }
            return View(VM);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetNewYearTime()
        {
            DateTime dt = DateTime.Now.AddDays(3);
            List<int> L = new List<int>();
            for (int i = dt.Year; i <= dt.Year + 1; i++)
            {
                L.Add(i);
            }
            var q = L.Select(p => new { tx = p.ToString(), va = p });
            return Json(q, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public ActionResult GetNewMonthTime(int thisYEAR)
        {
            DateTime dt = DateTime.Now.AddDays(3);
            List<int> List = new List<int>();
            if (thisYEAR == dt.Year)
            {
                for (int i = dt.Month; i <= 12; i++)
                {
                    List.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    List.Add(i);
                }
            }
            return Json(List.Select(p => new { Tx = p.ToString(), Va = p }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public int GetNewDayTime(int thisYEAR, int thisMONTH)
        {
            DateTime dt = DateTime.Now.AddDays(3);
            int data = 1;
            if (thisYEAR == dt.Year && thisMONTH == dt.Month)
            {
                data = dt.Day;
            }
            return data;
        }


        // GET: LeaveHistoryApprovalTemps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.employeeID);
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.DepartmentLeader);
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GeneralManager);
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GroupLeader);
            return View(leaveHistoryApprovalTemp);
        }

        // POST: LeaveHistoryApprovalTemps/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,employeeID,leaveID,StartTime,EndTime,Description,Appendix,GroupLeader,GroupLeaderSignTime,DepartmentLeader,DepartmentLeaderSignTime,GeneralManager,GeneralManagerSignTime,HREmployee,HREmployeeSignTime,HRGroupLeader,HRGroupLeaderSignTime,Status,SignState,Reject")] LeaveHistoryApprovalTemp leaveHistoryApprovalTemp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveHistoryApprovalTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.employeeID);
            ViewBag.DepartmentLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.DepartmentLeader);
            ViewBag.GeneralManager = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GeneralManager);
            ViewBag.GroupLeader = new SelectList(db.Employees, "employeeID", "EmployeeName", leaveHistoryApprovalTemp.GroupLeader);
            return View(leaveHistoryApprovalTemp);
        }

        // GET: LeaveHistoryApprovalTemps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            if (leaveHistoryApprovalTemp == null)
            {
                return HttpNotFound();
            }
            return View(leaveHistoryApprovalTemp);
        }

        // POST: LeaveHistoryApprovalTemps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveHistoryApprovalTemp leaveHistoryApprovalTemp = db.LeaveHistoryApprovalTemps.Find(id);
            db.LeaveHistoryApprovalTemps.Remove(leaveHistoryApprovalTemp);
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
