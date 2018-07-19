using ActionFilter.Filters;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilter.Controllers
{
    public class AccountController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            var user = dbc.Customers.Find(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (user.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                Session["user"] = user;
                ModelState.AddModelError("", "Đăng nhập thành công");
                Log.log((String)Session["ReturnUrl"]);
                if (Session["ReturnUrl"] != null)
                {
                    return Redirect(Session["ReturnUrl"].ToString());
                }
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Fotgot()
        {
            return View();
        }
        [Authenticate]
        public ActionResult Change()
        {
            return View();
        }
        [Authenticate]
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Activated()
        {
            return View();
        }
        [Authenticate]
        public ActionResult Logoff()
        {
            return View();
        }
    }
}