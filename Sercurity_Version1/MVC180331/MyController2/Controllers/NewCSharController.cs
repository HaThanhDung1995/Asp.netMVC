using MyController2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class NewCSharController : Controller
    {
        // GET: NewCShar
        public ActionResult Index()
        {
            var sv = new Student
            {
                Id = "NghiemN",
                Name = "Nguyễn Nghiệm",
                Marks = 9
            };

            ViewBag.sv = sv;
            return View();
        }

        public ActionResult Index2()
        {
            var sv1 = new Student
            {
                Id = "NghiemN",
                Name = "Nguyễn Nghiệm",
                Marks = 9
            };

            var sv2 = new Student
            {
                Id = "TeoNV",
                Name = "Nguyễn Văn Tèo",
                Marks = 5
            };

            var list = new List<Student> { sv1, sv2 };

            ViewBag.list = list;
            return View();
        }
    }
}