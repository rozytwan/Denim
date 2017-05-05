using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Denim.Models;
using System.IO;
namespace Denim.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        DenimEntities db;
        // GET: Admin/Gallery
        Gallery objGallery;
        
        public ActionResult Index()
        {
            db = new DenimEntities();

            objGallery = new Gallery();
           
           
            objGallery.imageList = db.Galleries.ToList();
            return View(objGallery.imageList);
        }
  public ActionResult AddGalleryImage()
        {
            db = new DenimEntities();



            ViewBag.EventId = new SelectList(db.Events, "Id", "Note");
            return View();
        }

        [HttpPost]
        public ActionResult SaveGallery(Gallery objGal, HttpPostedFileBase file)
        {
            ViewBag.IsSaved = false;
            db = new DenimEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    var fileName = "";
                    if (file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Gallery/Events"), fileName);
                        string[] file_name = fileName.Split('.');
                        file.SaveAs(path);
                    }
                    string ImageName = fileName.Split('.')[0].ToString();
                    string ImagePath = "Gallery/Events/" + fileName;
                    objGallery = new Gallery();
                    objGallery.EventId = objGal.EventId;
                    objGallery.ImageName = ImageName;
                    objGallery.ImagePath = ImagePath;
                    db.Galleries.Add(objGallery);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.IsSaved = true;
                }
                catch (Exception )
                {

                }
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Note");
            objGallery.imageList = db.Galleries.ToList();
            return View("Index",objGallery.imageList);
        }
        public ActionResult EditGalleryImage(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                db = new DenimEntities();
                Gallery objEvnt = db.Galleries.Find(id);

                return View(objEvnt);
            }
            else
            {
                return View("~/Views/Shared/ErrorAdmin.cshtml");
            }
        }

        public ActionResult Update(Gallery objgal, int id)
        {
            try { 
            db = new DenimEntities();
            Gallery gal = db.Galleries.Find(id);

            gal.EventId = objgal.EventId;
            gal.ImageName = objgal.ImageName;
            db.Entry(gal);

            db.SaveChanges();
        }
          catch
            {

            }
            Gallery objEvents = new Gallery();
            objEvents.imageList = db.Galleries.ToList();
            return View("Index", objEvents.imageList);
    

        //objGallery = new Gallery();
        //ViewBag.Event = new SelectList(db.Events, "Id", "Note", objGallery.EventId);
        //return View();
    }
        public ActionResult Del()
        {
            return View();
        }

        public ActionResult DeleteGalleryImage(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                db = new DenimEntities();
                Gallery objGallery = db.Galleries.Find(id);
                db.Galleries.Remove(objGallery);

                db.SaveChanges();
                
                objGallery.imageList = db.Galleries.ToList();
                return View("Index", objGallery.imageList);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
           
        }
    }
}