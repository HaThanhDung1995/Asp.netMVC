using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;

namespace AccountLogin.Controllers
{
    public class PracticeController : Controller
    {

        EShopDatabaseContext dbc=new EShopDatabaseContext();
        // GET: Practice
        public ActionResult Loadmore()
        {
            ViewBag.PageCount = Math.Ceiling(dbc.Products.Count() / 6.0);
            return View();
        }
        
        public ActionResult SearchAction(String Keywords = "")
        {
            var user = dbc.Products.Where(p => p.Name.Contains(Keywords)).ToList();
            return PartialView("_Table", user);
        }
        [HttpPost]
        public ActionResult Loadmore(int PageNo=0)
        {
            var model = dbc.Products.OrderBy(p => p.UnitPrice).Skip(6 * PageNo).Take(6).ToList();
            return PartialView("_Loadmore",model);
        }
    }
}