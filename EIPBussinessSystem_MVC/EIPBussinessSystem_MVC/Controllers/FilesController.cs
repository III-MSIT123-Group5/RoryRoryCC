using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using EIPBussinessSystem_MVC.Models;

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
            if (files.First() != null)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    string SourceFilename = Path.GetFileName(file.FileName);
                    string TargetFilename = Path.Combine(Server.MapPath(
                        "~/Uploads"), SourceFilename);
                    file.SaveAs(TargetFilename);

                    /////////////////////////////////////////////////
                    byte[] WriteTagMsg = { 0x52, 0x46, 0x49, 0x44, 0x01, 0x06, 0x21, 0x01, 0x00, 0x02, 0x11, 0x11 };
                    ////////////////////////////////////////////////////
                    db.Files.Add(new Models.File
                    {
                        FileName = Path.GetFileNameWithoutExtension(file.FileName),
                        Data = WriteTagMsg,
                        //TargetFilename,
                        FileSize = file.ContentLength.ToString(),
                        EmployeeID = 1032,
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
            for (int i = 0; i < Cheak.Length + 1; i++)
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
        /// ///////////////////////////////////////////////////

        // GET: Files
        public ActionResult Index()
        {
            var files = db.Files.Include(f => f.Employee);
            return View(files.ToList());
        }

        // GET: Files/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }


        // GET: Files/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", file.EmployeeID);
            return View(file);
        }

        // POST: Files/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileID,FileName,FileSize,EmployeeID,UploadDate,Data,Extension")] Models.File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "employeeID", "EmployeeName", file.EmployeeID);
            return View(file);
        }

        // GET: Files/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.File file = db.Files.Find(id);
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
            Models.File file = db.Files.Find(id);
            db.Files.Remove(file);
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
