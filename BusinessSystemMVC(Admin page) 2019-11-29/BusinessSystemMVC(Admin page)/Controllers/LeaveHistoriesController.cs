﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using Microsoft.Office.Interop.Excel;

namespace BusinessSystemMVC_Admin_page_.Controllers
{
    public class LeaveHistoriesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        // GET: LeaveHistories
        public ActionResult Index()
        {            
            return View();
        }

        //請假記錄LoadData
        [HttpGet]
        [Authorize(Roles = "DepartmentLeader")]
        public ActionResult LeaveHistoryLoadData()   
        {
            var datas = db.LeaveHistories.Where(p=>p.Employee.DepartmentID == EmployeeDetail.DepartmentID ).Select(p=>new { p.Employee.EmployeeName ,p.Leave.leave_name,p.Employee.Group.GroupName,p.Employee.Position.position1,p.ReleaseTime,p.StartTime,p.EndTime,p.LeaveHours}).ToList();
            return Json(new { data = datas }, JsonRequestBehavior.AllowGet);
        }

        //匯出年度請假記錄到Excel
        public ActionResult ExportExcel()
        {
            var qLev = db.LeaveHistories.Where(p => p.Employee.DepartmentID == EmployeeDetail.DepartmentID).OrderBy(p => p.employeeID).ToList();
            var qLevByLeaveID = (from c in db.LeaveHistories
                       group c by c.leaveID into g
                       orderby g.Key
                       select new { LeaveID = g.Key, Count = g.Count(), Group = g }).ToList();

            Application application = new Application();
            Workbook workbook = application.Workbooks.Add(Missing.Value);
            Worksheet worksheet = workbook.ActiveSheet;

            //標題--------------------------------
            worksheet.Cells[1, 1] = "年度：";
            worksheet.Cells[1, 2] = DateTime.Now.Year;
            worksheet.Cells[1, 3] = "部門：";
            worksheet.Cells[1, 4] = EmployeeDetail.DepartmentName;
            worksheet.Cells[3, 1] = "人員姓名";
            worksheet.Cells[3, 2] = "組別";
            worksheet.Cells[3, 3] = "職稱";
            worksheet.Cells[3, 4] = "假別";
            worksheet.Cells[3, 5] = "申請日期";
            worksheet.Cells[3, 6] = "開始日期";
            worksheet.Cells[3, 7] = "結束日期";
            worksheet.Cells[3, 8] = "時數";
            //--------------------------------------
            int rowIndex = 5;
            for ( int i = 0 ;i<qLev.Count();i++)
            {
                var item = qLev[i];
                    worksheet.Cells[i + 4, 1] = item.Employee.EmployeeName;
                worksheet.Cells[i + 4, 2] = item.Employee.Group.GroupName;
                worksheet.Cells[i + 4, 3] = item.Employee.Position.position1;
                worksheet.Cells[i + 4, 4] = item.Leave.leave_name;
                worksheet.Cells[i + 4, 5] = item.ReleaseTime.ToString("yyyy/MM/dd HH:mm");
                    worksheet.Cells[i + 4, 6] = item.StartTime.ToString("yyyy/MM/dd HH:mm");
                    worksheet.Cells[i + 4, 7] = item.EndTime.ToString("yyyy/MM/dd HH:mm");
                    worksheet.Cells[i + 4, 8] = item.LeaveHours;
                rowIndex++;
            }
            worksheet.Cells[rowIndex + 1, 4] = "時數總和";
            worksheet.Cells[rowIndex, 5] = "特休";
            worksheet.Cells[rowIndex, 6] = "事假";
            worksheet.Cells[rowIndex, 7] = "病假";
            worksheet.Cells[rowIndex, 8] = "總和";
            int SLhs = 0, PLhs = 0, SickLhs = 0;
            foreach (var sl in qLevByLeaveID[0].Group)
            {
                SLhs  += (int)sl.LeaveHours;
            }
            foreach (var sl in qLevByLeaveID[1].Group)
            {
                PLhs += (int)sl.LeaveHours;
            }
            foreach (var sl in qLevByLeaveID[2].Group)
            {
                SickLhs += (int)sl.LeaveHours;
            }
            worksheet.Cells[rowIndex + 1, 5] = SLhs;
            worksheet.Cells[rowIndex + 1, 6] = PLhs;
            worksheet.Cells[rowIndex + 1, 7] = SickLhs;
            worksheet.Cells[rowIndex + 1, 8] = SLhs+ PLhs+ SickLhs;
            worksheet.get_Range("A1", $"H{rowIndex-2}").Font.Name = "標楷體";
            worksheet.get_Range("A1", $"H{rowIndex-2}").Font.Size = 14;
            worksheet.get_Range("A1", "D1").Borders.LineStyle = XlLineStyle.xlContinuous;
            worksheet.get_Range("A3", "H3").Borders.LineStyle = XlLineStyle.xlContinuous;
            worksheet.get_Range("A4", $"H{rowIndex - 2}").Borders.LineStyle = XlLineStyle.xlContinuous;
            workbook.SaveAs($"D:\\2019_{EmployeeDetail.DepartmentName}請假記錄");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);
            application.Quit();
            Marshal.FinalReleaseComObject(application);

            return Json(new { success = true, message = "下載成功，檔案已載於磁碟Ｄ" }, JsonRequestBehavior.AllowGet);
        }

    }
}
