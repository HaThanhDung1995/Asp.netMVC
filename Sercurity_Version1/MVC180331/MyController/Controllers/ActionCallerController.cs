using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController.Controllers
{
    public class ActionCallerController : Controller
    {
        // GET: ActionCaller
        [HttpGet]
        public ActionResult Action1()
        {
            ViewBag.Message = "GET";
            return View();
        }
        [HttpPost]
        public ActionResult Action1(String x)
        {
            ViewBag.Message = "POST";
            return View();
        }

        public ActionResult Action2()
        {
            ViewBag.Message = "Action2 - POST";
            return View("Action1");
        }

        [Route("NhatNghe")]
        public ActionResult Action3()
        {
            ViewBag.Message = "Action3 - POST";
            return View("Action1");
        }
    }
}