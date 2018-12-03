using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppContext = Challenge_Club_Dashboard.Models.AppContext;
using System.Web.Mvc;
using Challenge_Club_Dashboard.Models;

namespace Challenge_Club_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Members = new List<string>()
            {
                "John Smith", "Andy Wilhouse","Mary Stewart","Catherine McDonald", "Anduin Wrynn", "Jaina Proudmoore", "Sylvanas Windrunner"
            };
            ViewBag.Activities = new List<string>()
            {
                "Recreational Activity","Employment Training", "Computer Lab",
                "Advocacy Training", "Volunteer", "Arts & Crafts", "Gardening", "Reading/Library",
                "Exercise", "Social Games", "Family & Friends (After Hours)", "Other"
            };
            ViewBag.MemberActivities = new AppContext().MemberActivities.ToArray();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            // TODO: Add insert logic here
            AppContext context = new AppContext();
            MemberActivity model = context.MemberActivities.Add(new MemberActivity() {
                Member = collection.Get("Member"),
                Activity = collection.Get("Activity")
            });
            context.SaveChanges();
            return RedirectToAction("About");
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            AppContext context = new AppContext();
            MemberActivity model = context.MemberActivities.Find(id);
            context.MemberActivities.Remove(model);
            context.SaveChanges();
            return RedirectToAction("About");
        }
    }
}