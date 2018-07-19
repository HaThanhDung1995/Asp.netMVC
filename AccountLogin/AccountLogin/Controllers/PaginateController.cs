using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;

namespace AccountLogin.Controllers
{
    public class PaginateController : Controller
    {
        EShopDatabaseContext dbc = new EShopDatabaseContext();
        // GET: Paginate
        public ActionResult LoadMore()
        {
            ViewBag.Count = Math.Ceiling(dbc.Products.Count() / 6.0);
            return View();
        }
        [HttpPost]
        public ActionResult LoadMore(int PageNo=0)
        {
            var model = dbc.Products.OrderByDescending(p=>p.UnitPrice).Skip(6 * PageNo).Take(6).ToList();
            return PartialView("_LoadMore",model);
        }
    }
}