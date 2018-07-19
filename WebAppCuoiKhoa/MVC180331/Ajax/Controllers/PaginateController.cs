using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ajax.Controllers
{
    public class PaginateController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();
        // GET: Paginate
        public ActionResult Index()
        {
            ViewBag.PageCount = (int)Math.Ceiling(dbc.Products.Count() / 8.0);
            return View();
        }

        public ActionResult Load(int PageNo = 0)
        {
            var model = dbc.Products
                .OrderBy(p => p.UnitPrice)
                .Skip(8 * PageNo)
                .Take(8)
                .ToList();
            return PartialView(model);
        }

        public ActionResult LoadMore()
        {
            ViewBag.PageCount = (int)Math.Ceiling(dbc.Products.Count() / 6.0);
            return View();
        }
        [HttpPost]
        public ActionResult LoadMore(int PageNo = 0)
        {
            //Thread.Sleep(3000);
            var model = dbc.Products
                .OrderBy(p => p.UnitPrice)
                .Skip(6 * PageNo)
                .Take(6)
                .ToList();
            return PartialView("_LoadMore", model);
        }
    }
}