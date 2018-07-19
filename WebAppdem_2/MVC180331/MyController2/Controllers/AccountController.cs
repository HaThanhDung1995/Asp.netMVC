using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Username, String Password)
        {
            if (Username != "Nhất")
            {
                ViewBag.Message = "Sai tên đăng nhập";
            }
            else if (Password != "Nghệ")
            {
                ViewBag.Message = "Sai mật khẩu";
            }
            else
            {
                ViewBag.Message = "Chúc mừng, bạn đã đăng nhập thành công";
            }
            return View();
        }
    }
}