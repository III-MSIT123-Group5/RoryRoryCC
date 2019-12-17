using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using BusinessSystemMVC_Admin_page_.Models;
using Microsoft.AspNet.Identity;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class FilesController : Controller
    {
        private BusinessDataBaseEntities db = new BusinessDataBaseEntities();

        [HttpGet]
        public ActionResult Upload()
        {
            return View(new BusinessSystemMVC_Admin_page_.Models.File());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                if (files.First() != null)
                {
                    foreach (HttpPostedFileBase file in files)
                    {
                        //不含路徑的檔名及副檔名
                        string SourceFilename = Path.GetFileName(file.FileName);
                        //string TargetFilename = Path.Combine(Server.MapPath(
                        //    "~/Uploads"), SourceFilename);

                        //所在資料夾
                        string saveDir = "\\Uploads\\";
                        //根目錄
                        string appPath = Request.PhysicalApplicationPath;
                        //完整路徑(包含檔名)
                        string savePath = appPath + saveDir + SourceFilename;


                        file.SaveAs(savePath);


                        db.Files.Add(new BusinessSystemMVC_Admin_page_.Models.File
                        {
                            FileName = SourceFilename,
                            Data =savePath,
                            FileSize = file.ContentLength.ToString(),
                            EmployeeID = EmployeeDetail.EmployeeID,
                            UploadDate = DateTime.Now,
                            Extension = Path.GetExtension(file.FileName)
                        });
                    }
                    //儲存修改
                    db.SaveChanges();
                }
                return View("Index");
                //return Json(new { success = true, message = "新增成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        public FileResult Download(int id)
        {
            var FileName = db.Files.Where(f => f.FileID == id).Select(f=>f.FileName).FirstOrDefault();
            string saveDir = "Uploads\\";
            string appPath = Request.PhysicalApplicationPath;
            string DownloadFileName = appPath + saveDir + FileName;
            ContentDisposition cd = new ContentDisposition
            {
                FileName = FileName,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }

        public FileResult DownloadAll()
        {
            string ZipFileName = "All.zip";

            string saveDir = "Uploads\\";
            string appPath = Request.PhysicalApplicationPath;
            string UploadsFolder = appPath + saveDir;
            string DownloadFileName = appPath+ZipFileName;
            if (System.IO.File.Exists(DownloadFileName))
            {
                System.IO.File.Delete(DownloadFileName);
            }

            System.IO.Compression.ZipFile.CreateFromDirectory(UploadsFolder, DownloadFileName);
            ContentDisposition cd = new ContentDisposition
            {
                FileName = ZipFileName,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }


        public ActionResult DownloadChoose(string[] Cheak)
        {
            string DownloadFileName = null;
            string ZipFileName = "All.zip";
            string FileName = null;
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                for (int i = 0; i < Cheak.Length; i++)
                {
                    var q = db.Files.AsEnumerable().Where(f => f.FileID.ToString() == Cheak.ElementAt(i));
                    FileName = q.Select(f => f.FileName).FirstOrDefault();

                    string saveDir = "Uploads\\";
                    string appPath = Request.PhysicalApplicationPath;
                    DownloadFileName = appPath + saveDir+ FileName;
                    //壓縮檔案
                    zip.AddFile(DownloadFileName, "");
                    zip.Save(DownloadFileName);
                }
            }
            ContentDisposition cd = new ContentDisposition
            {
                FileName = ZipFileName,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }

        
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LoadData()
        {
            //顯示
            
            var file = from f in db.Files
                        join emp in db.Employees
                        on f.EmployeeID equals emp.employeeID
                        select new
                        {
                            f.FileID,
                            f.FileName,
                            f.FileSize, 
                            f.UploadDate,
                            f.Extension,
                            emp.EmployeeName
                        };
            var files = file.ToList();

            return Json(new { data = files }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (BusinessDataBaseEntities db = new BusinessDataBaseEntities())
            {
                BusinessSystemMVC_Admin_page_.Models.File file = db.Files.Find(id);
                db.Files.Remove(file);
                string FileName = db.Files.Where(f => f.FileID == id).Select(f => f.FileName).FirstOrDefault();
                string saveDir = "Uploads\\";
                string appPath = Request.PhysicalApplicationPath;
                string DeleteFileName = appPath + saveDir + FileName;
                System.IO.File.Delete(DeleteFileName);
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
