using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;

namespace AccountLogin.Controllers
{
    public class TestAjaxController : Controller
    {
        EShopDatabaseContext dbc= new EShopDatabaseContext();
        // GET: TestAjax
        public ActionResult Search()
        {
           
            return View();
        }
        public ActionResult SearchAction(String Keywords="")
        {
            var user = dbc.Products.Where(p => p.Name.Contains(Keywords)).ToList();
            return PartialView("_Table",user);
        }
        public ActionResult SearchJson()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SearchJson(String Keywords = "")
        {
            var model = dbc.Products
                .Where(p => p.Name.Contains(Keywords))
                
                .ToList();
            
            return Json(model);
        }
    }
}