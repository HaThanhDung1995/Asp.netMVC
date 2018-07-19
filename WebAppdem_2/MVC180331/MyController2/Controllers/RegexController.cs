using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class RegexController : Controller
    {
        // GET: Regex
        public ActionResult Validate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate(String Email, String Phone, String IdCard, String Moto)
        {
            if (!Regex.IsMatch(Email, @"\w+@\w+(\.\w+){1,2}"))
            {
                ViewBag.EmailErr = "Email không hợp lệ";
            }
            if (!Regex.IsMatch(Phone, @"0\d{9,10}"))
            {
                ViewBag.PhoneErr = "Phone không hợp lệ";
            }
            if (!Regex.IsMatch(IdCard, @"\d{9}"))
            {
                ViewBag.IdCardErr = "CMND không hợp lệ";
            }
            if (!Regex.IsMatch(Moto, @"5\d-[A-Z]\d-((\d{4})|(\d{3}\.\d{2}))"))
            {
                ViewBag.MotoErr = "Moto không hợp lệ";
            }
            return View();
        }

        public ActionResult Numbers()
        {
            ViewBag.EvenNumbers = new List<String>();
            return View();
        }
        [HttpPost]
        public ActionResult Numbers(String Numbers)
        {
            var list = new List<String>();
            var nums = Regex.Split(Numbers, @"[,;\s]+");
            foreach(var num in nums){
                if (int.Parse(num) % 2 == 0)
                {
                    list.Add(num);
                }
            }
            ViewBag.EvenNumbers = list;
            return View();
        }

        public ActionResult Matches()
        {
            var path = Server.MapPath("~/App_Data/Email.txt");
            var text = System.IO.File.ReadAllText(path);
           
            var emails = Regex.Matches(text, @"\w+@\w+(\.\w+){1,2}");

            var list = new List<String>();
            foreach (var email in emails)
            {
                list.Add(email.ToString());
            }

            ViewBag.Emails = list;
            return View();
        }
    }
}