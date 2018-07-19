using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;
using AccountLogin.Utils;

namespace AccountLogin.Controllers
{
    public class AccountController : Controller
    {
        EShopDatabaseContext dbc = new EShopDatabaseContext();
        // GET: Account
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(String Email, String Id)
        {
            var user = dbc.Customers.Find(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Ten dang nhap khong ton tai");
            }
            else if (user.Email != Email)
            {
                ModelState.AddModelError("", "Email khong ton tai");
            }
            else
            {

                Mailer.Send(Email, "Restore Password", user.Password);
                ModelState.AddModelError("", "Mat khau da duoc gui toi mail");
            }
            return View();
        }
        public ActionResult Active(String Id)
        {
            var user = dbc.Customers.Find(Id);
            user.Activated = true;
            dbc.SaveChanges();
            ModelState.AddModelError("", "Tai khoan da duoc kich hoat");
            return View("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer model)
        {
            try
            {
                dbc.Customers.Add(model);
                dbc.SaveChanges();
                var href = "http://localhost:53439/Account/Active/" + model.Id;
                Mailer.Send(model.Email, "Active Account", "<a href='" + href + "'>Activate</a>");

                ModelState.AddModelError("", "Đăng ký thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Đăng ký thất bại");
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Id, string Password)
        {
            //var user = dbc.Customers.Find(Id);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Sai ID");
            //}
            //else if (user.Password != Password)
            //{
            //    ModelState.AddModelError("", "Sai Mat Khau");

            //}
            //else
            //{
            //    ModelState.AddModelError("", "Dang nhap thanh cong");
            //    Session["user"] = user;
            //}
            var user = dbc.Customers.Single(a => a.Fullname==Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai ID");
            }
            else if (user.Password != Password)
            {
                ModelState.AddModelError("", "Sai Mat Khau");
            }
            else
            {
                ModelState.AddModelError("", "Dang nhap thanh cong");
                Session["user"] = user;
            }
            return View();
        }
    }
}