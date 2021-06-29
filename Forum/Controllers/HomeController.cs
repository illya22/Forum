using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        ForumDBEntities db = new ForumDBEntities();


        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SingUp(Users users)
        {
            if (db.Users.Any(x => x.User_name == users.User_name))
            {
                ViewBag.Notification = "This account has already existed!!!";
                return View();
            }
            else
            {

                db.Users.Add(users);
                db.SaveChanges();

                Session["Id"] = users.Id_user.ToString();
                Session["User_Name"] = users.User_name.ToString();
                return RedirectToAction("List", "Forum");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("List", "Forum");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users users)
        {
            var check_if_login = db.Users.Where(x => x.User_name.Equals(users.User_name)
            && x.User_password.Equals(users.User_password)).FirstOrDefault();

            if (check_if_login != null)
            {
                Session["Id"] = users.Id_user.ToString();
                Session["User_Name"] = users.User_name.ToString();
                return RedirectToAction("List", "Forum");
            }
            else
            {
                ViewBag.Notification = "Wrong name or password!!";
            }
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}