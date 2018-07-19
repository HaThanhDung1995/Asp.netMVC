using MyController2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Student model)
        {
            String path = Server.MapPath("~/App_Data/"+model.Id+".txt");
            String[] Data = { model.Id, model.Name, model.Marks.ToString()};
            System.IO.File.WriteAllLines(path, Data);

            ViewBag.Message = "Lưu file thành công!";
            return View("Index");
        }

        public ActionResult Open(Student model)
        {
            var path = Server.MapPath("~/App_Data/" + model.Id + ".txt");
            if (System.IO.File.Exists(path))
            {
                var Data = System.IO.File.ReadAllLines(path);
                model.Name = Data[1];
                model.Marks = double.Parse(Data[2]);

                ViewBag.ThongTin = model;
                ViewBag.Message = "Thông tin chi tiết!";
                return View("Information");
            }
            else
            {
                ViewBag.Message = "Sinh viên này chưa nhập!";
                return View("Index");
            }
        }
    }
}