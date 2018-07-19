using EShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class HomeController : EShopController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(String Reason = "")
        {
            if (Reason.Length > 0)
            {
                ModelState.AddModelError("", Reason);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            var Master = dbc.Masters.Find(Id);
            if (Master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (Master.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                Session["Master"] = Master;
                ModelState.AddModelError("", "Đăng nhập thành công");
            }
            return View();
        }
    }
}