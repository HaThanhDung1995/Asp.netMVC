using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class ExMethodController : Controller
    {
        // GET: ExMethod
        public ActionResult Index()
        {
            var fullname = "Nguyễn Nghiệm";
            var encode = fullname.ToBase64();
            var decode = encode.FromBase64();
            var md5 = fullname.ToMd5();

            ViewBag.Origin = fullname;
            ViewBag.Encode = encode;
            ViewBag.Decode = decode;
            ViewBag.Md5 = md5;

            return View();
        }
    }
}