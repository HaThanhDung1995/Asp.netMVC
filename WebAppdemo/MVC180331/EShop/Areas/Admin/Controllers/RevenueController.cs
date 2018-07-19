using EShop.Areas.Admin.Models;
using EShop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class RevenueController : EShopController
    {
        public ActionResult ByCategory()
        {
            var data = dbc.OrderDetails
                .GroupBy(d => d.Product.Category)
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
            return View("Revenue", data);
        }

        public ActionResult BySupplier()
        {
            var data = dbc.OrderDetails
                .GroupBy(d => d.Product.Supplier)
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
            return View("Revenue", data);
        }

        public ActionResult ByYear()
        {
            var data = dbc.OrderDetails
                .GroupBy(d => d.Order.OrderDate.Year)
                .ToList()
                .Select(g => new Report
                {
                    Group = g.Key.ToString(),
                    Quantity = g.Sum(p => p.Quantity),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View("Revenue", data);
        }

        public ActionResult ByQuarter()
        {
            var data = dbc.OrderDetails
                .GroupBy(d => Math.Ceiling(d.Order.OrderDate.Month/3.0))
                .ToList()
                .Select(g => new Report
                {
                    Group = g.Key.ToString(),
                    Quantity = g.Sum(p => p.Quantity),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View("Revenue", data);
        }
    }
}