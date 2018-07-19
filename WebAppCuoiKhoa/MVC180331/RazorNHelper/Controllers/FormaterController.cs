using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorNHelper.Controllers
{
    public class FormaterController : Controller
    {
        // GET: Formater
        public ActionResult Number()
        {
            ViewBag.Number1 = 123456789.09876;
            ViewBag.Number2 = 0.15;
            return View();
        }

        public ActionResult Date()
        {
            ViewBag.Now = DateTime.Now;
            return View();
        }
    }
}