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

        public ActionResult Upload()
        {
            return View();
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
                    //不含路徑的檔名及附檔名
                    string SourceFilename = Path.GetFileName(file.FileName);
                    //string TargetFilename = Path.Combine(Server.MapPath(
                    //    "~/Uploads"), SourceFilename);

                    //所在資料夾
                    string saveDir = "\\Uploads\\";
                    //根目錄
                    string appPath = Request.PhysicalApplicationPath;
                    //完整路徑(包含檔名)
                    string savePath = appPath + saveDir+ SourceFilename;


                    file.SaveAs(savePath);


                    db.Files.Add(new BusinessSystemMVC_Admin_page_.Models.File
                    {
                        FileName = SourceFilename,
                        Data = savePath,
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

        public FileResult Download(string FileName)
        {
            string saveDir = "\\Uploads\\";
            string appPath = Request.PhysicalApplicationPath;
            string DownloadFileName = appPath + saveDir + FileName;
            ContentDisposition cd = new ContentDisposition
            {
                FileName = FileName,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            Dispose();
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }

        public FileResult DownloadAll()
        {
            string ZipFileName = "All.zip";

            string saveDir = "\\Uploads\\";
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
            Dispose();
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

                    string saveDir = "\\Uploads\\";
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
            Dispose();
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }
        /// ///////////////////////////////////////////////////

        // GET: Files
        public ActionResult Index(string FileName)
        {
            var files = db.Files.Include(f => f.Employee);
            if (!String.IsNullOrEmpty(FileName))
            {
                files = files.Where(s => s.FileName.Contains(FileName));
            }
            return View(files.ToList());
        }


        // GET: Files/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessSystemMVC_Admin_page_.Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BusinessSystemMVC_Admin_page_.Models.File file = db.Files.Find(id);
            db.Files.Remove(file);
            string FileName = db.Files.Where(f => f.FileID == id).Select(f => f.FileName).FirstOrDefault();
            string saveDir = "\\Uploads\\";
            string appPath = Request.PhysicalApplicationPath;
            string DeleteFileName = appPath + saveDir + FileName;
            System.IO.File.Delete(DeleteFileName);
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
