using MyController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController.Controllers
{
    public class ThamSoController : Controller
    {
        // GET: ThamSo
        public ActionResult UseModel()
        {
            return View();
        }
        public ActionResult UseModel2(StudentModel model)
        {
            // Bỏ vào ViewBag
            ViewBag.Ma = model.Id;
            ViewBag.HoTen = model.Name;
            ViewBag.Diem = model.Marks;

            return View("UseModel");
        }

        public ActionResult UseArguments()
        {
            return View();
        }

        public ActionResult UseArguments2(String Id, String Name, String Marks)
        {
            // Bỏ vào ViewBag
            ViewBag.Ma = Id;
            ViewBag.HoTen = Name;
            ViewBag.Diem = Marks;

            return View("UseArguments");
        }

        public ActionResult UseFormCollection()
        {
            return View();
        }

        public ActionResult UseFormCollection2(FormCollection Fields)
        {
            // Nhận tham số
            String Id = Fields["Id"];
            String Name = Fields["Name"];
            String Marks = Fields["Marks"];

            // Bỏ vào ViewBag
            ViewBag.Ma = Id;
            ViewBag.HoTen = Name;
            ViewBag.Diem = Marks;

            return View("UseFormCollection");
        }

        public ActionResult UseRequest()
        {
            return View();
        }

        public ActionResult UseRequest2()
        {
            // Nhận tham số
            String Id = Request["Id"];
            String Name = Request["Name"];
            String Marks = Request["Marks"];

            // Bỏ vào ViewBag
            ViewBag.Ma = Id;
            ViewBag.HoTen = Name;
            ViewBag.Diem = Marks;

            return View("UseRequest");
        }
    }
}