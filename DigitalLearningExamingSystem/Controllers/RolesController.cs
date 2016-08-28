using DigitalLearningExamingSystem.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalLearningExamingSystem.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Roles
        public ActionResult Index()
        {
            //return View(db.Exams.ToList());
            //UserManager.AddToRoleAsync("admin", "teacher");
            //UserManager.AddToRoleAsync("admin", "student");
            //UserManager.AddToRoleAsync("admin", "admin");
            ViewBag.Users = UserManager.Users.ToList();
            return View(UserManager.Users.ToList());
        }
    }
}