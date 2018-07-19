using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Controllers;

namespace EShop.Areas.Admin.Controllers
{
    public class HomeController : EShopController
    {
        // GET: Admin/Home
        public ActionResult Index(String Reason="")
        {
            if (Reason.Length > 0)
            {
                ModelState.AddModelError("",Reason);
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Email, String Password)
        {
            
            try
            {
                var master = dbc.Masters.Single(m => m.Email == Email && m.Password == Password);
                ModelState.AddModelError("", "Dang nhap thanh cong");
                Session["Master"] = master;
                if (XSession.ReturnUrl != null)
                {
                    return Redirect(XSession.ReturnUrl);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Khong ton tai tai khoan");
            }

            return View();
        }
    }
}