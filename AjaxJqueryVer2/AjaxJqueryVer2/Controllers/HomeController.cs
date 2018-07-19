using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxJqueryVer2.Models;

namespace AjaxJqueryVer2.Controllers
{
    public class HomeController : Controller
    {
        StudentDataContext dbc = new StudentDataContext();
        public ActionResult Index()
        {
            var data = dbc.Students.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(int id)
        {
            var data = dbc.Students.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(Student model)
        {
            var data = dbc.Students.Single(a=>a.Id==model.Id);
            data.Name = model.Name;
            data.Number = model.Number;
            data.Sta = model.Sta;
            dbc.SaveChanges();
            return Json(new
            {
                message="Cap Nhat Thanh Cong"
            });
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            model.Sta = "DisActivated";
            dbc.Students.Add(model);
            
            dbc.SaveChanges();
            return Json(new
            {
                message = "Them  Thanh Cong"
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}