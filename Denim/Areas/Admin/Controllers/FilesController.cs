using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Denim.Models;
using System.IO;

namespace Denim.Areas.Admin.Controllers
{
  
    public class FilesController : Controller
    {
        DenimEntities db = new DenimEntities();
        Denim.Models.File objFile = new Models.File();

        public ActionResult Index()
        {
            db = new DenimEntities();

            Denim.Models.File objEvents = new Denim.Models.File();
            objFile.FileList = db.Files.ToList();
            return View(objFile.FileList);
        }
     
            public ActionResult Create()
        {

            return View();
        }
        public ActionResult AddFiles(Denim.Models.File obj, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {

                var path = Path.Combine(Server.MapPath("~/Files/"));
                //file.SaveAs(path);
                string fileName = file.FileName;
                string ImageName = fileName.Split('.')[0].ToString();
                string ImagePath = "~/Files/" + fileName;
                objFile.FileName = ImageName;
                objFile.FilePath = ImagePath;
                db.Files.Add(objFile);
                db.SaveChanges();
            }

            Denim.Models.File objEvents = new Denim.Models.File();
            objFile.FileList = db.Files.ToList();
            return View("Index", objFile.FileList);
        }
        public ActionResult DeleteFiles(string ImageName,int id)
        {
            Denim.Models.File objfile = db.Files.Find(id);
            db.Files.Remove(objfile);
            db.SaveChanges();
       
            return RedirectToAction("Index");
        }
    }
}