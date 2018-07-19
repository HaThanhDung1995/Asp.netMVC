using DataSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataSharing.Controllers
{
    public class SharerController : Controller
    {
        // GET: Sharer
        public ActionResult Detail()
        {
            ViewBag.Id = "NghiemN";
            ViewBag.Name = "Nguyễn Nghiệm";
            ViewData["Mark"] = 9;

            var model = new Student
            {
                Id="TeoNV",
                Name="Nguyễn Văn Tèo",
                Mark = 8
            };
            return View(model);
        }

        public ActionResult List()
        {
            var sv1 = new Student
            {
                Id = "TeoNV",
                Name = "Nguyễn Văn Tèo",
                Mark = 8
            };
            var sv2 = new Student
            {
                Id = "NghiemN",
                Name = "Nguyễn Nghiệm",
                Mark = 4
            };
            var sv3 = new Student
            {
                Id = "ThaoLTH",
                Name = "Lê Thị Hương Thảo",
                Mark = 7
            };
            var list = new List<Student> { sv1, sv2, sv3 };
            return View(list);
        }
    }
}