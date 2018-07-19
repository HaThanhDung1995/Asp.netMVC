using EShop.Areas.Admin.Models;
using EShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class InventoryController : EShopController
    {
        public ActionResult ByCategory()
        {
            ViewBag.Group = "Category";
            var data = dbc.Products
                .GroupBy(p => p.Category)
                .Select(g => new Report
                {
                    Group = g.Key.NameVN,
                    Quantity = g.Sum(p => p.Quantity),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View("Inventory", data);
        }

        public ActionResult BySupplier()
        {
            ViewBag.Group = "Supplier";
            var data = dbc.Products
                .GroupBy(p => p.Supplier)
                .Select(g => new Report
                {
                    Group = g.Key.Name,
                    Quantity = g.Sum(p => p.Quantity),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View("Inventory", data);
        }
    }
}