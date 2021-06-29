using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class NavController : Controller
    {
        ForumDBEntities db = new ForumDBEntities();

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = db.Topic
                .Select(topic => topic.Category)
                .Distinct()

                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}