using EIPBussinessSystem_MVC.Models;
using EIPBussinessSystem_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace EIPBussinessSystem_MVC.Controllers
{
    public class FilesController : Controller
    {
        private BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();
        // GET: Files
        public ActionResult Index()
        {
            var FileList = dbContext.Files.Join(dbContext.Employees, f => f.EmployeeID, e => e.employeeID, (f, e) => new
            {
                檔案編號 = f.FileID,
                檔案名稱 = f.FileName,
                檔案大小 = f.FileSize,
                上傳員工 = e.EmployeeName,
                上傳日期 = f.UploadDate,
                檔案類型 = f.Extension
            }).OrderBy(fe => fe.檔案編號);
            return View(FileList.ToList());


            //DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads"));
            //var query = (from f in di.EnumerateFiles("*.*")
            //             select f).Select((file, index) =>
            //             new DownloadFile
            //             {
            //                 ID = index + 1,
            //                 FileName = file.Name,
            //                 FileSize = file.Length,
            //                 CreationTime = file.CreationTime,
            //                 Checked = false
            //             });
            //return View(query);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files.First() != null)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    string SourceFilename = Path.GetFileName(file.FileName);
                    string TargetFilename = Path.Combine(Server.MapPath(
                        "~/Uploads"), SourceFilename);
                    file.SaveAs(TargetFilename);

                    dbContext.Files.Add(new Models.File
                    {
                        FileName = Path.GetFileNameWithoutExtension(file.FileName),
                        //Data = TargetFilename,
                        FileSize = file.ContentLength.ToString(),
                        //EmployeeID = LoginID,
                        UploadDate = DateTime.Now,
                        Extension = Path.GetExtension(file.FileName)
                    });
                    //儲存修改
                    dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public FileResult Download(string FileName)
        {
            string DownloadFileName = Path.Combine(Server.MapPath("~/Uploads"), FileName);
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
            string UploadsFolder = Server.MapPath("~/Uploads");
            string DownloadFileName =
                Path.Combine(Server.MapPath("~"), ZipFileName);
            if (System.IO.File.Exists(DownloadFileName))
            {
                System.IO.File.Delete(DownloadFileName);
            }

            ZipFile.CreateFromDirectory(UploadsFolder, DownloadFileName);
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


            //string DownloadFileName = null;
            for (int i = 0; i < Cheak.Length+1; i++)
            {
                DownloadFileName = Path.Combine(Server.MapPath("~/Uploads"), Cheak.ElementAt(i));
                ContentDisposition cd = new ContentDisposition
                {
                    FileName = Cheak.ElementAt(i),
                    Inline = false,
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                ;
            }
            return File(DownloadFileName, MediaTypeNames.Application.Octet);
        }


    }
    
}
