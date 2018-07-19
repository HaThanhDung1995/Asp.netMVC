using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class HomeController : EShopController
    {
        

        public ActionResult Index()
        {
            ViewBag.Cate5 = dbc.Categories
                .Where(c => c.Products.Count >= 4)
                .OrderBy(c => Guid.NewGuid())
                .Take(5)
                .ToList();

            ViewBag.Specials = dbc.Products
                .Where(p => p.Special == true).ToList();

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

        public ActionResult _Category()
        {
            var list = dbc.Categories.ToList();
            return PartialView(list);
        }

        public ActionResult _Supplier()
        {
            var list = dbc.Suppliers.ToList();
            return PartialView(list);
        }

        public ActionResult _Favorite()
        {
            var ids = XCookie.GetValue("Favorites");
            var list = dbc.Products.ToList()
                .Where(p => ids.Contains(p.Id.ToString()));
            return PartialView(list);
        }
    }
}