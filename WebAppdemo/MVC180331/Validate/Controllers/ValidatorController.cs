using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validate.Models;

namespace Validate.Controllers
{
    public class ValidatorController : Controller
    {
        // GET: Validator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validate(Employee model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Chúc mừng bạn đã nhập đúng!");
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng sửa các lỗi sau đây!");
            }
            return View("Index");
        }

        public ActionResult Info()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Validate2(ContactInfo model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Chúc mừng bạn đã nhập đúng!");
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng sửa các lỗi sau đây!");
            }
            return View("Info");
        }

        public ActionResult Manual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manual(String Name, String Age)
        {
            if (Name.Length < 5)
            {
                ModelState.AddModelError("Name", "Ít nhất 5 ký tự!");
            }
            if (Age.Length == 0)
            {
                ModelState.AddModelError("Age", "Không để trống!");
            }
            try
            {
                int age = int.Parse(Age);
                if (age < 16 || age > 65)
                {
                    ModelState.AddModelError("Age", "Từ 16 đến 65!");
                }
            }
            catch
            {
                ModelState.AddModelError("Age", "Tuổi phải là số!");
            }
            return View();
        }
    }
}