using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class OuputController : Controller
    {
        // GET: Ouput
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult Index3()
        {
            return Content("My name is Nghiem");
        }

        public ActionResult Index4()
        {
            return Redirect("http://www.gmail.com");
        }

        public ActionResult Index5()
        {
            return RedirectToAction("About", "Home");
        }

        public ActionResult Index6()
        {
            return File("~/Files/congving.jpg", "image/jpeg");
        }

        public ActionResult Index71()
        {
            var data = new[] { "6", "A", "Hello" };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index72()
        {
            var data = new
            {
                fullname = "Nguyễn NGhiệm",
                mark = 9,
                age = 45
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index73()
        {
            var data1 = new
            {
                fullname = "Nguyễn NGhiệm",
                mark = 9,
                age = 45
            };
            var data2 = new
            {
                fullname = "Nguyễn Văn Tèo",
                mark = 5,
                age = 20
            };
            var data = new ArrayList { data1, data2 };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index8()
        {

            var data = "alert('Hello World')";
            return JavaScript(data);
        }

        public ActionResult Script()
        {
            return View();
        }
    }
}