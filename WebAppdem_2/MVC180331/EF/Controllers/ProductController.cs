using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class ProductController : Controller
    {
        EShopV10 dbc = new EShopV10();

        // GET: Product
        public ActionResult List(int Id)
        {
            var category = dbc.Categories.Find(Id);
            return View(category);
        }

        public ActionResult Detail(int Id)
        {
            var product = dbc.Products.Find(Id);
            return View(product);
        }
    }
}