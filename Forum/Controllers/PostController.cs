using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        private ForumDBEntities db = new ForumDBEntities();

       
        public ActionResult Index()
        {

            var posts = db.Post.Include(p => p.Topic).Include(p => p.Users);
            return View(posts.ToList());

        }



   

        public ActionResult Create()
        {
            ViewBag.Topic_id = new SelectList(db.Topic, "Id_topic", "Category");
            ViewBag.User_id = new SelectList(db.Users, "Id_user", "User_name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_post,Topic_id,User_id,User_name,Post_text,Post_date")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Topic_id = new SelectList(db.Topic, "Id_topic", "Category", post.Topic_id);
            ViewBag.User_id = new SelectList(db.Users, "Id_user", "User_name", post.User_id);
            return View(post);
        }

         
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Topic_id = new SelectList(db.Topic, "Id_topic", "Category", post.Topic_id);
            ViewBag.User_id = new SelectList(db.Users, "Id_user", "User_name", post.User_id);
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_post,Topic_id,User_id,User_name,Post_text,Post_date")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Topic_id = new SelectList(db.Topic, "Id_topic", "Category", post.Topic_id);
            ViewBag.User_id = new SelectList(db.Users, "Id_user", "User_name", post.User_id);
            return View(post);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
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
