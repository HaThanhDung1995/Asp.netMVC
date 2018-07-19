using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class UploaderController : Controller
    {
        // GET: Uploader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var f1 = Request.Files["image"];
            var f2 = Request.Files["document"];

            if (f1.ContentLength > 0)
            {
                var path1 = Server.MapPath("~/Files/" + f1.FileName);
                f1.SaveAs(path1);
                ViewBag.F1_Name = f1.FileName;
            }

            if (f2.ContentLength > 0)
            {
                var path2 = Server.MapPath("~/Files/" + f2.FileName);
                f2.SaveAs(path2);
                ViewBag.F2_Name = f2.FileName;
                ViewBag.F2_Size = f2.ContentLength;
                ViewBag.F2_Type = f2.ContentType;
            }

            return View();
        }
    }
}