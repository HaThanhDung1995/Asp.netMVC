using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC180331.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return Content("Chào quí vị");
        }

        public ActionResult Chao()
        {
            ViewBag.Slogan = "Đối tác chiến lược của Microsoft";
            return View();
        }

        public ActionResult Hi()
        {
            return View("NhatNghe");
        }
    }
}