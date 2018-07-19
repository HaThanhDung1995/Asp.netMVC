using RazorNHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorNHelper.Controllers
{
    public class ModelUIController : Controller
    {
        // GET: ModelUI
        public ActionResult Index()
        {
            var model = new Student();
            model.Id = "NghiemN";
            model.Password = "iloveyou";
            return View(model);
        }

        public ActionResult Index2()
        {
            var model = new Student();
            model.Id = "NghiemN";
            model.Password = "iloveyou";
            return View(model);
        }

        public ActionResult Index3()
        {
            var model = new Student();
            model.Id = "NghiemN";
            model.Password = "iloveyou";
            ViewBag.SV = model;
            return View();
        }
    }
}