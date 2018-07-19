using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorNHelper.Controllers
{
    public class RazorController : Controller
    {
        // GET: Razor
        public ActionResult Index()
        {
            ViewBag.Message = "<h1>Chào thế giới <i>MS.MVC</i></h1>";
            return View();
        }

        public ActionResult Text()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}