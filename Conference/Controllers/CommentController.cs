using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class CommentController : Controller
    {
        ConferenceContext context = new ConferenceContext();

        // GET: Comment
        [ChildActionOnly()]
        public PartialViewResult _GetForSession(Int32 sessionID)
        {
            ViewBag.SessionID = sessionID;
            List<Comment> comments = context.Comments.Where(x => x.SessionID == sessionID).ToList();
            return PartialView("_GetForSession", comments);
        }

        [ChildActionOnly()]
        public PartialViewResult _CommentForm(Int32 sessionID)
        {
            Comment comment = new Comment() { SessionID = sessionID };
            return PartialView("_CommentForm", comment);
        }

        // this needs a different name because of a quirk in the Ajax form
        [ValidateAntiForgeryToken()]
        public PartialViewResult _Submit(Comment comment) //_CreateSubmit
        {
            context.Comments.Add(comment);
            context.SaveChanges();

            List<Comment> comments = context.Comments.Where(x => x.SessionID == comment.SessionID).ToList();
            ViewBag.SessionID = comment.SessionID;
            
            return PartialView("_GetForSession", comments);
        }
    }
}