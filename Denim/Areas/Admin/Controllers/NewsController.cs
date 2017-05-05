using Denim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denim.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        DenimEntities db;
        News obj = new News();
        // GET: Admin/News
        public ActionResult Index()
        {
            db = new DenimEntities();

            //News objEvents = new News();
            obj.NewsList = db.News.ToList();
            return View(obj.NewsList);
        }
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(News objNews)
        {
            ViewBag.IsSaved = false;
            db = new DenimEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    obj.Title = objNews.Title;
                    obj.Date = objNews.Date;
                    obj.Description = objNews.Description;
                    db.News.Add(obj);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.IsSaved = true;
                }
                catch (Exception)
                {

                }
            }
            News objEvents = new News();
            objEvents.NewsList = db.News.ToList();
           return View("Index", objEvents.NewsList);

        }
       
        public ActionResult EditEvent(News objNews, int? id)
        {

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                db = new DenimEntities();
                News obj = db.News.Find(id);

                return View(obj);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult Update(News objEvnt, int id)
        {
            try
            {
                db = new DenimEntities();
                News obj = db.News.Find(id);
                obj.Title = objEvnt.Title;
                obj.Date = objEvnt.Date;
                obj.Description = objEvnt.Description;
                db.Entry(obj);
                db.SaveChanges();
            }
            catch
            {

            }
       
            obj.NewsList = db.News.ToList();
            return View("Index", obj.NewsList);

        }
   public ActionResult DeleteEvent(int? Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                db = new DenimEntities();
                News obj = db.News.Find(Id);

                return View(obj);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                db = new DenimEntities();

                try
                {
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(id)))
                    {
                        News obj = db.News.Find(id);
                        db.News.Remove(obj);
                        db.SaveChanges();
                    }
                }
                catch
                {

                }
                News objEvents = new News();
                objEvents.NewsList = db.News.ToList();
                return View("Index", objEvents.NewsList);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
        }
    }
}