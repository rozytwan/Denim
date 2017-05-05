using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Denim.Models;
using System.IO;

namespace Denim.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
      
        // GET: Admin/Event
        DenimEntities db;
        public ActionResult Index()
        {
            db = new DenimEntities();

            Event objEvents = new Event();
            objEvents.eventList = db.Events.ToList();
            return View(objEvents.eventList);
        }

        Event objEvent = new Event();
        public ActionResult AddEvent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Save(Event objEvnt)
        {
            ViewBag.IsSaved = false;
            db = new DenimEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    objEvent.Note = objEvnt.Note;
                    objEvent.Date = objEvnt.Date;
                    objEvent.Status = objEvnt.Status;
                    db.Events.Add(objEvent);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.IsSaved = true;
                }
                catch (Exception)
                {

                }
            }

            Event objEvents = new Event();
            objEvents.eventList = db.Events.ToList();
            return View("Index",objEvents.eventList);

        }

        public ActionResult EditEvent(Event objEvent, int? id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                db = new DenimEntities();
                Event objEvnt = db.Events.Find(id);

                return View(objEvnt);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult Update(Event objEvnt, int id)
        {
            try
            {
                db = new DenimEntities();
                Event objEvent = db.Events.Find(id);
                objEvent.Note = objEvnt.Note;
                objEvent.Date = objEvnt.Date;
                objEvent.Status = objEvnt.Status;
                db.Entry(objEvent);
                db.SaveChanges();
            }
            catch
            {

            }
            Event objEvents = new Event();
            objEvents.eventList = db.Events.ToList();
            return View("Index", objEvents.eventList);

        }

        public ActionResult DeleteEvent(int? Id)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                db = new DenimEntities();
                Event objEvent = db.Events.Find(Id);

                return View(objEvent);
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
                        Event objEvent = db.Events.Find(id);
                        db.Events.Remove(objEvent);
                        db.SaveChanges();
                    }
                }
                catch
                {

                }
                Event objEvents = new Event();
                objEvents.eventList = db.Events.ToList();
                return View("Index", objEvents.eventList);
            }
            else
            {
                return View("~/Areas/Admin/Views/Shared/Error.cshtml");
            }
        }
    }
}