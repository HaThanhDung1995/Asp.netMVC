using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Demo.Interface;
using Demo.Model;
using Demo.WebApplication.Models;

namespace Demo.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //khai báo service
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListStudent()
        {
            var listStudent = _studentService.ListStudent();
            return PartialView("_ListStudent", listStudent);
        }

        public ActionResult CretaeStudent()
        {
            //tạo view đẻ ng dùng nhập dữ liệu
            //model trên view sẽ là StudentViewModel
            return View();
        }

        //method post mình sẽ truyền vào cái viewmodel từ view mà ng dùng nhập dữ liệu
        [HttpPost]
        public ActionResult CretaeStudent(StudentViewModel studentViewModel)
        {
            //truyền dữ liệu từ StudentViewModel vào StudentModel để service xử lý, tại vì service đang mang biến là StudentModel
            var studentModel = new StudentModel
            {
                
                name = studentViewModel.name
            };

            //truyền model vào service để xử lý

            _studentService.CreateStudent(studentModel);

            //khi xử lý xong sẽ return về index
            return View("Index");
        }

        public ActionResult UpdateStudent(int id)
        {
            //lấy đc student theo id
            var student = _studentService.GetStudent(id);

            //mapping student vs StudentViewModel để binding sang View
            var studentViewModel = Mapper.Map<StudentViewModel>(student);
            
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult UpdateStudent(StudentViewModel studentViewModel)
        {
            //mapping StudentViewModel vs StudentModel để truyền StudentModel lên server xử lý
            var studentModel = Mapper.Map<StudentModel>(studentViewModel);
            
            //truyền StudentModel lên server
            _studentService.UpdateStudent(studentModel);
            return View("Index");
        }

      
        public ActionResult DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);
            return RedirectToAction("Index");
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