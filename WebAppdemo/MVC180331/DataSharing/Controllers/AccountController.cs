using DataSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataSharing.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if(Request.Cookies["user"] != null){
                ViewBag.Id = Request.Cookies["user"].Values["id"];
                ViewBag.Password = Request.Cookies["user"].Values["pw"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id, String Password, Boolean Remember=false)
        {
            try
            {
                var sv = DB.Students.Single(s => s.Id == Id);
                if (sv.Password != Password)
                {
                    ViewBag.Message = "Invalid password!";
                }
                else
                {
                    ViewBag.Message = "Login successfully!";
                    
                    var cookie = new HttpCookie("user");
                    if (Remember == true)
                    {
                        cookie.Values["id"] = Id;
                        cookie.Values["pw"] = Password;
                        cookie.Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1); // Xóa cookie
                    }
                    Response.Cookies.Add(cookie);

                    Session["user"] = sv;
                    if (Session["return"] != null)
                    {
                        return Redirect(Session["return"].ToString());
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Invalid username!";
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Profile()
        {
            var model = Session["user"];
            if (model == null)
            {
                Session["return"] = "/Account/Profile";
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public ActionResult Change()
        {
            var model = Session["user"];
            if (model == null)
            {
                Session["return"] = "/Account/Change";
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}