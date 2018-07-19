using EF1.Models.MVC5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class CodeFirstController : Controller
    {
        MvcContext dbc = new MvcContext();
        // GET: CodeFirst
        public ActionResult Index()
        {
            dbc.Courses.Add(new Course
            {
                Name = "ASP.NET MVC 5",
                Schoolfee = 3000000
            });
            dbc.SaveChanges();
            return View();
        }
    }
}