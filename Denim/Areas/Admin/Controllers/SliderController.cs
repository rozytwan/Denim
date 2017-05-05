using Denim.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denim.Areas.Admin.Controllers
{
   
    public class SliderController : Controller
    {
        DenimEntities db = new DenimEntities();
        Slider objSlider = new Slider();
        // GET: Admin/Slider
        public ActionResult Index()
        {
            objSlider.slidList = db.Sliders.ToList();
            return View("Index", objSlider.slidList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImages(Slider objslid, HttpPostedFileBase file)
        {
            if (isFileValid(file))
            {
                string fileName = "";
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    string[] file_name = fileName.Split('.');
                    file.SaveAs(path);
                }

                //var path = Path.Combine(Server.MapPath("~/Images/"));
                //file.SaveAs(path);
                //string fileName = file.FileName;
                string ImageName = fileName.Split('.')[0].ToString();
                string ImagePath = "Images/" + fileName;
                objSlider.ImageName = ImageName;
                objSlider.ImagePath = ImagePath;
                db.Sliders.Add(objSlider);
                db.SaveChanges();
               
            }

        else
            {
                ViewBag.path = "Invalid Dimensions";
       
            }
            objSlider.slidList = db.Sliders.ToList();
            return View("Index", objSlider.slidList);


        }
        public bool isFileValid(HttpPostedFileBase file)
        {
            Bitmap bitmp = new Bitmap(file.InputStream);
            if (bitmp.Width == 1140 | bitmp.Height == 350)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
        public ActionResult DeleteImage(int id)
        {
            Slider objSlider = db.Sliders.Find(id);
            db.Sliders.Remove(objSlider);
            db.SaveChanges();
        
            return RedirectToAction("Index");

        }
    }
}