using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ.Controllers
{
    public class ProductController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();

        public ActionResult Index(int PageNo = 0, double Min = Double.MinValue, double Max = Double.MaxValue)
        {
            var PageCount = Math.Ceiling(dbc.Products.Count() / 5.0);
            if (PageNo < 0)
            {
                PageNo = (int)PageCount - 1;
            }
            else if (PageNo >= PageCount)
            {
                PageNo = 0;
            }
            Session["PageNo"] = PageNo;
            Session["PageCount"] = (int)PageCount;

            var model = dbc.Products
                .Where(p => p.UnitPrice >= Min && p.UnitPrice <= Max)
                .OrderByDescending(p => p.UnitPrice)
                .Skip(PageNo * 5)
                .Take(5)
                .ToList();
            return View(model);
        }

        public ActionResult Detail(int Id)
        {
            var model = dbc.Products.Single(p => p.Id == Id);
            return View(model);
        }
    }
}