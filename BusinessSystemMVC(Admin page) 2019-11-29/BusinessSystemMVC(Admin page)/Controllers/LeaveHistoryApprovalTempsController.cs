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
using BusinessSystemMVC_Admin_page_.ViewModels;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class LeaveHistoryApprovalTempsController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: LeaveHistoryApprovalTemps
        public ActionResult Index()
        {
            return View();
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
            var q = db.LeaveHistoryApprovalTemps.Where(p => p.SignState == false && p.Reject == false);
            if (EmployeeDetail.PositionID == 3) //組長
            {
                q = q.Where(p => p.GroupLeader == null && p.Employee.ManagerID == EmployeeDetail.EmployeeID && p.Employee.GroupID == EmployeeDetail.GroupID && p.Employee.DepartmentID == EmployeeDetail.DepartmentID);
            }
            else if (EmployeeDetail.PositionID == 2) //部長
            {
                q = q.Where(p => p.GroupLeader != null && p.DepartmentLeader == null && p.Employee.DepartmentID == EmployeeDetail.DepartmentID);
            }
            else  //總仔
            {
                q = q.Where(p => p.GroupLeader != null && p.DepartmentLeader != null && p.GeneralManager == null);
            }
            var datas = q.Select(p => new { p.Employee.EmployeeName, p.Leave.leave_name, p.Employee.Department.name, p.Employee.Group.GroupName, p.Employee.Position.position1, p.ReleaseTime, p.StartTime, p.EndTime, p.ID }).ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //核准
        [HttpPost]
        [Authorize(Roles = "DepartmentLeader,GroupLeader,GeneralManager")]
        public ActionResult AcceptLeave(int ID)
        {
            var q = db.LeaveHistoryApprovalTemps.Find(ID);
            if (q.SignState == false && q.Reject == false)
            {
                //組長
                if (EmployeeDetail.PositionID == 3 && q.GroupLeader == null && q.Employee.GroupID == EmployeeDetail.GroupID && q.Employee.DepartmentID == EmployeeDetail.DepartmentID)
                {
                    q.GroupLeader = EmployeeDetail.EmployeeID;
                    q.GroupLeaderSignTime = DateTime.Now;
                    q.Status = "待部長簽核";
                    db.SaveChanges();
                }
                //部長
                if (EmployeeDetail.PositionID == 2 && q.GroupLeader != null && q.DepartmentLeader == null && q.Employee.DepartmentID == EmployeeDetail.DepartmentID)
                {
                    q.DepartmentLeader = EmployeeDetail.EmployeeID;
                    q.DepartmentLeaderSignTime = DateTime.Now;
                    q.Status = "待總經理簽核";
                    db.SaveChanges();
                }
                //總仔
                if (EmployeeDetail.PositionID == 1 && q.GroupLeader != null && q.DepartmentLeader != null && q.GeneralManager == null)
                {
                    q.GeneralManager = EmployeeDetail.EmployeeID;
                    q.GeneralManagerSignTime = DateTime.Now;
                    db.SaveChanges();
                }
                //簽核完成(都簽了且為核准)
                if (q.GroupLeader != null && q.DepartmentLeader != null && q.GeneralManager != null)
                {
                    q.SignState = true;
                    q.Reject = false;
                    q.Status = "簽核完成";
                    var addFormalLeave = new LeaveHistory()
                    {
                        employeeID = q.employeeID,
                        leaveID = q.leaveID,
                        ReleaseTime = q.ReleaseTime,
                        StartTime = q.StartTime,
                        EndTime = q.EndTime,
                        Description = q.Description,
                        Appendix = q.Appendix,
                        LeaveHours = q.LeaveHours
                    };
                    //將時數更新到Employee裡
                    var qEmp = db.Employees.Find(q.employeeID);
                    switch (q.leaveID)
                    {
                        case 0:     //特休
                            qEmp.SpecialLeaveHours -= (int)q.LeaveHours;
                            break;
                        case 1:    //事假
                            qEmp.PersonalLeaveHours -= (int)q.LeaveHours;
                            break;
                        case 2:    //病假
                            qEmp.SickLeaveHours -= (int)q.LeaveHours;
                            break;
                    }

                    //存入行事曆Event DB
                    var addEventCalender = new EventCalendar()
                    {
                        employeeID = q.employeeID,
                        Subject = q.Leave.leave_name,
                        DepartmentID = q.Employee.DepartmentID,
                        StartTime = q.StartTime,
                        EndTime = q.EndTime,
                        Location = q.Employee.Office.office_name,
                        Description = q.Description,
                        IsImportant = true,
                        ThemeColor = "#DDDDDD"
                    };
                    db.EventCalendars.Add(addEventCalender);
                    db.LeaveHistories.Add(addFormalLeave);
                    db.SaveChanges();
                }
}
            return Json(new { success = true, message = "簽核成功" }, JsonRequestBehavior.AllowGet);
        }

        //駁回
        [HttpPost]
[Authorize(Roles = "DepartmentLeader,GroupLeader,GeneralManager")]
public ActionResult RejectLeave(int ID)
{
    var q = db.LeaveHistoryApprovalTemps.Find(ID);
    if (q.SignState == false && q.Reject == false)
    {
        //組長
        if (EmployeeDetail.PositionID == 3 && q.Employee.ManagerID == EmployeeDetail.EmployeeID && q.GroupLeader == null && q.Employee.GroupID == EmployeeDetail.GroupID && q.Employee.DepartmentID == EmployeeDetail.DepartmentID)
        {
            q.GroupLeader = EmployeeDetail.EmployeeID;
            q.GroupLeaderSignTime = DateTime.Now;
            q.SignState = false;
            q.Reject = true;
            q.Status = "已遭組長駁回";
            db.SaveChanges();
        }
        //部長
        if (EmployeeDetail.PositionID == 2 && q.GroupLeader != null && q.DepartmentLeader == null && q.Employee.DepartmentID == EmployeeDetail.DepartmentID)
        {
            q.DepartmentLeader = EmployeeDetail.EmployeeID;
            q.DepartmentLeaderSignTime = DateTime.Now;
            q.SignState = false;
            q.Reject = true;
            q.Status = "已遭部長駁回";
            db.SaveChanges();
        }
        //總仔
        if (EmployeeDetail.PositionID == 1 && q.GroupLeader != null && q.DepartmentLeader != null && q.GeneralManager == null)
        {
            q.DepartmentLeader = EmployeeDetail.EmployeeID;
            q.DepartmentLeaderSignTime = DateTime.Now;
            q.SignState = false;
            q.Reject = true;
            q.Status = "已遭部長駁回";
            db.SaveChanges();
        }
    }
    return Json(new { success = true, message = "簽核已駁回" }, JsonRequestBehavior.AllowGet);
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
//載入簽核的假詳細資料
public ActionResult SignLeaveLoadDataDetail(int ID)
{
    return View(db.LeaveHistoryApprovalTemps.Where(p => p.ID == ID).FirstOrDefault());
}

//載入完成簽核的假詳細資料
public ActionResult FinishSignLeaveLoadDataDetail(int ID)
{
    return View(db.LeaveHistoryApprovalTemps.Where(p => p.ID == ID).FirstOrDefault());
}

        //載入申請中的假
        [AllowAnonymous]
[HttpGet]
public ActionResult LeaveLoadData()
{
    var q = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID && p.SignState == false && p.Reject == false).Select(p => new { p.ID, p.Leave.leave_name, p.ReleaseTime, p.StartTime, p.EndTime, p.Status });
    var datas = q.ToList();
    return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
}
//載入完成的假
[AllowAnonymous]
[HttpGet]
public ActionResult FinishLeaveLoadData()
{
    var q = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID && p.SignState == true && p.Reject == false).Select(p => new { p.ID, p.Leave.leave_name, p.ReleaseTime, p.StartTime, p.EndTime, p.Status });
    var datas = q.ToList();
    return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
}
        //載入駁回的假
        [AllowAnonymous]
        [HttpGet]
        public ActionResult RejectLeaveLoadData()
        {
            var q = db.LeaveHistoryApprovalTemps.Where(p => p.employeeID == EmployeeDetail.EmployeeID && p.SignState == false && p.Reject == true).Select(p => new { p.ID, p.Leave.leave_name, p.ReleaseTime, p.StartTime, p.EndTime, p.Status });
            var datas = q.ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
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
        NewLeave.StartTime = new DateTime(VM.StartDate.Year, VM.StartDate.Month, VM.StartDate.Day, VM.StartHour, 0, 0);
        NewLeave.EndTime = new DateTime(VM.EndDate.Year, VM.EndDate.Month, VM.EndDate.Day, VM.EndHour, 0, 0);
        int LeaveHours = Convert.ToInt32((NewLeave.EndTime - NewLeave.StartTime).TotalHours);  //總時數
        var HoursDeRest = LeaveHours;   //請假時數
        var qLeaveList = db.LeaveHistories.Where(p => p.employeeID == EmployeeDetail.EmployeeID && ((NewLeave.StartTime >= p.StartTime && NewLeave.StartTime < p.EndTime) || (NewLeave.EndTime > p.StartTime && NewLeave.EndTime <= p.EndTime))).Select(p => p.employeeID);
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
        int SickL = 0, SpeL = 0, PerL = 0;
        var qhrs = db.LeaveHistoryApprovalTemps.Where(p => p.StartTime.Year == DateTime.Now.Year).Select(p => new { p.leaveID, p.LeaveHours });
        foreach (var hrs in qhrs.Where(p => p.leaveID == 0).Select(p => new { p.LeaveHours }))
        {
            SpeL += hrs.LeaveHours.Value;
        }
        foreach (var hrs in qhrs.Where(p => p.leaveID == 1).Select(p => new { p.LeaveHours }))
        {
            PerL += hrs.LeaveHours.Value;
        }
        foreach (var hrs in qhrs.Where(p => p.leaveID == 2).Select(p => new { p.LeaveHours }))
        {
            SickL += hrs.LeaveHours.Value;
        }
        if ((VM.leaveID == 0 && emp.SpecialLeaveHours + SpeL < HoursDeRest) || (VM.leaveID == 1 && emp.PersonalLeaveHours + PerL < HoursDeRest) || VM.leaveID == 2 && emp.SickLeaveHours + SickL < HoursDeRest)
        {
            return Json(new { fail = true, message = "選擇的假別已無剩餘時數，請再次確認。" }, JsonRequestBehavior.AllowGet);
        }
        //todo 附件上傳
        //if(VM.AppendixFile.First() != null)
        //{
        //    foreach(var file in VM.AppendixFile)
        //    {
        //        string SavePath = $"{Request.PhysicalApplicationPath}\\imgLeaveAppendix\\{Path.GetFileName(file.FileName)}";
        //        file.SaveAs(SavePath);
        //        NewLeave.Appendix += SavePath+",";
        //    }
        //}
        NewLeave.employeeID = EmployeeDetail.EmployeeID;
        NewLeave.leaveID = VM.leaveID;
        NewLeave.ReleaseTime = DateTime.Now;
        NewLeave.Description = VM.Description;
        NewLeave.LeaveHours = HoursDeRest;
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
                if (EmployeeDetail.PositionID == 3)
                    NewLeave.Status = "待部長簽核";
                else   //員工
                    NewLeave.Status = "待組長簽核";
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
