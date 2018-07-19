using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Validate.Controllers
{
    public class AntiForgeryController : Controller
    {
        // GET: AntiForgery
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String Notes)
        {
            System.IO.File.AppendAllText("c:/temp/logs.txt", Notes + "\r\n");
            return View();
        }
    }
}