using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class SessionController : Controller
    {
        ConferenceContext context = new ConferenceContext();
        // GET: Session
        public ActionResult Index()
        {
            List<Session> sessions = context.Sessions.ToList();
            //return View("Index", sessions);
            return View(sessions);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Session/Create
        [HttpPost()]
        public ActionResult Create(Session session)
        {
            if(!ModelState.IsValid)
            {
                return View(session);
            }
            try
            {
                context.Sessions.Add(session);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(session);
            }
            

            TempData["Message"] = "Created " + session.Title;

            return RedirectToAction("Index");
        }

        public ActionResult Details(Int32 id)
        {
            Session session = context.Sessions.First(x => x.SessionID == id);
            if (session != null && session.SessionID > 0)
            {
                ViewBag.Title = session.Title;
                return View("Details", session);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}