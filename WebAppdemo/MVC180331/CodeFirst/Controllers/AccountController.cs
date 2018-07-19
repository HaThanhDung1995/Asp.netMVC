using CodeFirst.Models;
using CodeFirst.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class AccountController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();

        public ActionResult Activate(String Id)
        {
            var user = dbc.Customers.Find(Id);
            user.Activated = true;
            dbc.SaveChanges();
            ModelState.AddModelError("", "Tai khoan da duoc kich hoat");
            return View("Login");
        }

        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(String Id, String Email)
        {
            var user = dbc.Customers.Find(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai ten dang nhap!");
            }
            else if (user.Email != Email)
            {
                ModelState.AddModelError("", "Sai email dang ky!");
            }
            else
            {
                // Gui mail
                XMailer.Send(Email, "Forgot password", user.Password);
                ModelState.AddModelError("", "Mat khau da duoc gui qua email!");
            }
            return View();
        }

        public ActionResult Edit()
        {
            var user = Session["user"];
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Customer model)
        {
            try
            {
                dbc.Entry(model).State = EntityState.Modified;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Cap nhat thanh cong!");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat that bai!");
            }
            return View(model);
        }

        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Change(String Id, String Password, String Password1, String Password2)
        {
            var user = dbc.Customers.Find(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai ten dang nhap");
            }
            else if (user.Password != Password)
            {
                ModelState.AddModelError("", "Sai mat khau dang nhap cu");
            }
            else if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xac nhan mat khau moi khong dung");
            }
            else
            {
                user.Password = Password1;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Doi mat khau thanh cong");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer model)
        {
            model.Activated = false;
            try
            {
                dbc.Customers.Add(model);
                dbc.SaveChanges();
                ModelState.AddModelError("", "Dang ky thanh cong!");

                //Gui mail
                var href = "http://localhost:54916/Account/Activate/" + model.Id;
                XMailer.Send(model.Email, "Welcome", "<a href='"+href+"'>Activate</a>");
            }
            catch
            {
                ModelState.AddModelError("", "Dang ky that bai!");
            }
            return View();
        }

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
                ModelState.AddModelError("", "Sai ten dang nhap!");
            }
            else if (user.Password != Password)
            {
                ModelState.AddModelError("", "Sai mat khau dang nhap!");
            }
            else
            {
                ModelState.AddModelError("", "Dang nhap thanh cong!");
                Session["user"] = user;
            }
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

    }
}