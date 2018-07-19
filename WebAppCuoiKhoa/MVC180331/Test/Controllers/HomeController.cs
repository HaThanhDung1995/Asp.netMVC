using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
       DataContext dbc= new DataContext();
        public ActionResult Index()
        {
            var RoleIds = dbc.MasterRoles
                .Where(mr => mr.MasterId == "ndthienlong")
                .Select(mr => mr.RoleId).ToList();
            ViewBag.Role = RoleIds;
            var model = dbc.ActionRoles.Any(a => RoleIds.Contains(a.RoleId));
            if (!model)
            {
                ViewBag.message = "Thanh Cong";
            }
            return View();
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