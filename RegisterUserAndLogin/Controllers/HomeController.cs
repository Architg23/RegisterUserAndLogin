using RegisterUserAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserandLogin.Models;

namespace UserandLogin.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User usr)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured!");
            }
            return View(usr);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User users)
        {
                    var obj = db.Users.Where(u => u.User_Name.Equals(users.User_Name) && u.Password.Equals(users.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["User Id"] = obj.User_Id.ToString();
                        Session["User_Name"] = obj.User_Name.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name or Password is Invalid");
                    }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["User_Name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}