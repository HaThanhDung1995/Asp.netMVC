using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Controllers;

namespace EShop.Areas.Admin.Controllers
{
    public class AccountController : EShopController
    {
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String Id,String Password)
        {
            var model = dbc.Masters.Find(Id);
            if (model == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (model.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                Session["Master"] = model;
                if (Session["ReturnUrl"] != null)
                {
                    return Redirect(XSession.ReturnUrl);
                }
                ModelState.AddModelError("", "Đăng nhập thành công");
            }
            return View();
        }
    }
}