using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class BonusController : Controller
    {
        // GET: Bonus
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Compute(String Salary, String Birthday)
        {
            var luong = double.Parse(Salary);
            var ngaySinh = Convert.ToDateTime(Birthday);
            var tuoi = DateTime.Now.Year - ngaySinh.Year;

            if (tuoi < 25)
            {
                ViewBag.Thuong = luong * 0.05;
            }
            else if (tuoi < 40)
            {
                ViewBag.Thuong = luong * 0.1;
            }
            else
            {
                ViewBag.Thuong = luong * 0.15;
            }
            ViewBag.Luong = luong;
            ViewBag.ThucLinh = ViewBag.Thuong + luong;

            return View("Index");
        }
    }
}