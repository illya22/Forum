using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        ForumDBEntities db = new ForumDBEntities();
        public int pageSize = 4;

        public ViewResult Topics()
        {

            return View(db.Topic.ToList());
        }




        public ActionResult Create_Topic()
        {
            ViewBag.Id_topic = new SelectList(db.Topic, "Id_topic", "Category");
            ViewBag.Id_topic = new SelectList(db.Topic, "Id_topic", "Category");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Topic([Bind(Include = "Id_topic,Category,Description")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topic.Add(topic);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.Id_topic = new SelectList(db.Topic, "Id_topic", "Category", topic.Id_topic);
            ViewBag.Id_topic = new SelectList(db.Topic, "Id_topic", "Category", topic.Id_topic);
            return View(topic);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topic.Find(id);
            db.Topic.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ViewResult List(string category, int page = 1)
        {
            ListViewModel model = new ListViewModel
            {
                Topics = db.Topic
                .Where(p => category == null || p.Category == category)
                .OrderBy(topic => topic.Id_topic)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    Current_Page = page,
                    Topics_Per_Page = pageSize,
                    Total_Topics = category == null ?
                    db.Topic.Count() :
                    db.Topic.Where(topic => topic.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

    }
}