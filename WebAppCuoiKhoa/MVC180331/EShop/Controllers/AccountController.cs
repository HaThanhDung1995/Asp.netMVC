using EShop.Filters;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class AccountController : EShopController
    {
        public ActionResult Login()
        {
            var Info = XCookie.GetValue("user", "&").Split('&');
            ViewBag.Id = Info[0];
            ViewBag.Password = Info[1];
            return View();
        }
        [HttpPost]
        public ActionResult Login(String id, String password, bool remember=false)
        {
            var user = dbc.Customers.Find(id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhâp!");
            }
            else if (user.Password != password)
            {
                ModelState.AddModelError("", "Sai mật khẩu!");
            }
            else if (!user.Activated)
            {
                ModelState.AddModelError("", "Tài khoản chưa kích hoạt!");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhâp thành công!");
                XSession.User = user;
                if (remember)
                {
                    XCookie.Add("user", 30, id + '&' + password);
                }
                else
                {
                    XCookie.Add("user", 0);
                }
                if (XSession.ReturnUrl != null)
                {
                    return Redirect(XSession.ReturnUrl);
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Vui lòng sửa các lỗi sau đây");
                return View();
            }

            // Upload
            var file = Request.Files["UpPhoto"];
            if (file.ContentLength > 0)
            {
                user.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Customers/" + user.Photo));
            }
            else
            {
                user.Photo = "user.png";
            }
            // Insert
            try
            {
                user.Activated = false;
                dbc.Customers.Add(user);
                dbc.SaveChanges();
                // Gửi mail
                var url = Request.Url.AbsoluteUri.Replace("Register", "Activate/" + user.Id.ToBase64());
                var body = "Vui lòng click vào liên kết sau để <a href='"+url+"'>kích hoạt</a>";
                XMailer.Send(user.Email, "Welcome to EShop", body);

                ModelState.AddModelError("", "Đăng ký thành công!");
            }
            catch
            {
                ModelState.AddModelError("", "Đăng ký thất bại!");
            }
            return View();
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
                ModelState.AddModelError("", "Sai tên đăng nhâp!");
            }
            else if (user.Email != Email)
            {
                ModelState.AddModelError("", "Sai địa chỉ email!");
            }
            else
            {
                XMailer.Send(Email, "Quên mật khẩu", user.Password);
                ModelState.AddModelError("", "Mật khẩu đã được gửi qua email!");
            }
            return View();
        }

        [Authenticate]
        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        [Authenticate]
        public ActionResult Change(String Id, String Password, String Password1, String Password2)
        {
            if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu mới không đúng!");
            }
            else
            {
                var user = dbc.Customers.Find(Id);
                if (user == null)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhâp!");
                }
                else if (user.Password != Password)
                {
                    ModelState.AddModelError("", "Sai mật khẩu!");
                }
                else
                {
                    user.Password = Password1;
                    dbc.SaveChanges();

                    ModelState.AddModelError("", "Đổi mật khẩu thành công!");
                }
            }
            return View();
        }

        [Authenticate]
        public ActionResult Edit()
        {
            return View(XSession.User);
        }
        [HttpPost]
        [Authenticate]
        public ActionResult Edit(Customer user)
        {
            // Upload
            var file = Request.Files["UpPhoto"];
            if (file.ContentLength > 0)
            {
                user.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Customers/" + user.Photo));
            }
            // Update
            try
            {
                dbc.Entry(user).State = System.Data.EntityState.Modified;
                dbc.SaveChanges();

                ModelState.AddModelError("", "Cập nhật thành công!");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại!");
            }
            return View();
        }

        public ActionResult Activate(String Id)
        {
            var user = dbc.Customers.Find(Id.FromBase64());
            user.Activated = true;
            dbc.SaveChanges();
            return RedirectToAction("Login");
        }

        [Authenticate]
        public ActionResult Logoff()
        {
            XSession.RemoveUser();
            return RedirectToAction("Index", "Home");
        }
    }
}