using RazorNHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorNHelper.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            ViewBag.a = 5;
            ViewBag.b = 7;
            ViewBag.c = 12;
            return View();
        }
        [HttpPost]
        public ActionResult Index(int a, int b)
        {
            ViewBag.c = (a + b);
            return View();
        }

        public ActionResult DropDownList1()
        {
            var array = new[] { "Nokia", "Apple", "Samsung" };
            ViewBag.Items = new SelectList(array);
            return View();
        }

        public ActionResult DropDownList2()
        {
            var array = new List<Country> { 
                new Country{Id="VN", Name="Việt Nam"},
                new Country{Id="US", Name="United States"},
                new Country{Id="UK", Name="United Kindom"}
            };
            ViewBag.Items = new SelectList(array, "Id", "Name", "US");
            return View();
        }
    }
}