using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxCrud.Models;

namespace AjaxCrud.Controllers
{
    public class StudentController : Controller
    {
        StudentDataContext dbc = new StudentDataContext();
        // GET: Student
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Json()
        {
            var list = dbc.Students.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {

            model.Status = "Disactivated";
            dbc.Students.Add(model);
            dbc.SaveChanges();
            var data = new
            {
                message = "Thanh Cong"
            };
            return Json(data);
        }
        public ActionResult Get(int Id)
        {
            var data = dbc.Students.Single(p => p.Id == Id);
            
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(Student model)
        {
            var data = dbc.Students.Single(p => p.Id == model.Id);
            data.Name = model.Name;
            data.Status = model.Status;
            dbc.SaveChanges();

            return Json(new
            {
                message="Thanh Cong"
            });
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var data = dbc.Students.Single(p => p.Id == Id);
            dbc.Students.Remove(data);
            dbc.SaveChanges();
            return Json(new {message="Xoa Thanh Cong"});
        }
    }
}