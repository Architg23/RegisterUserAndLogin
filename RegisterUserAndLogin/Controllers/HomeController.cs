using RegisterUserAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Edit(int Id)
        {
            var obj = db.Users.Where(u => u.User_Id == Id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(User users)
        {
            db.Entry(users).State = EntityState.Modified;
            int obj = db.SaveChanges();
            if(obj > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.EditMsg = ("<script>alert('Something Went Wrong..')</script>");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            User obj = db.Users.Where(u => u.User_Id == Id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(User users)
        {
                db.Users.Remove(users);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "About Us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact.";

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
                return View(db.Users.ToList());
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