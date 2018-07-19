using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;


namespace TestAjax.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult dungajax()
        {
            return Content("Hello Ha Thanh Dung","text/plain");
        }
        public ActionResult Displayname(string name)
        {
            return Content("Hello " +name, "text/plain");
        }
        public ActionResult DisplayOnject()
        {
            var model = new Product();
            model.pname = "Phone";
            model.pamount = "23";
            model.pprice = "5";
            List<Product> list = new List<Product>();
            list.Add(model);


            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}