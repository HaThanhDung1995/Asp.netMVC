using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax.Controllers
{
    public class AjaxController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();
        // GET: Ajax
        public ActionResult Time()
        {
            var time = DateTime.Now.ToString("hh:mm:ss tt");
            return Content(time);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchAction(String Keywords = "")
        {
            var model = dbc.Products
                .Where(p => p.Name.Contains(Keywords))
                .ToList();
            return PartialView("_Table", model);
        }

        public ActionResult SearchJson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchJson(String Keywords = "")
        {
            var model = dbc.Products
                .Where(p => p.Name.Contains(Keywords))
                .Select(p => new { p.Name, p.UnitPrice })
                .ToList();
            return Json(model);
        }

        public ActionResult Image()
        {
            return View();
        }
    }
}