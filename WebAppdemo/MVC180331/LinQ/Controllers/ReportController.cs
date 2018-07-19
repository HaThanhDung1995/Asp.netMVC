using CodeFirst.Models;
using LinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ.Controllers
{
    public class ReportController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();

        public ActionResult Inventory()
        {
            var model = dbc.Products
                .GroupBy(p => p.Category)
                .Select(g => new Report
                {
                    Category = g.Key.NameVN,
                    Count = g.Count(),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View(model);
        }

        public ActionResult RevenueByCategory()
        {
            var model = dbc.OrderDetails
                .GroupBy(d => d.Product.Category)
                .Select(g => new Report
                {
                    Category = g.Key.NameVN,
                    Count = g.Sum(d => d.Quantity),
                    Value = g.Sum(d => d.UnitPrice * d.Quantity),
                    MinPrice = g.Min(d => d.UnitPrice),
                    MaxPrice = g.Max(d => d.UnitPrice),
                    AvgPrice = g.Average(d => d.UnitPrice)
                })
                .ToList();
            return View(model);
        }

        public ActionResult RevenueByCustomer()
        {
            var model = dbc.OrderDetails
                .GroupBy(d => d.Order.Customer)
                .Select(g => new Report
                {
                    Category = g.Key.Id,
                    Count = g.Sum(d => d.Quantity),
                    Value = g.Sum(d => d.UnitPrice * d.Quantity),
                    MinPrice = g.Min(d => d.UnitPrice),
                    MaxPrice = g.Max(d => d.UnitPrice),
                    AvgPrice = g.Average(d => d.UnitPrice)
                })
                .OrderByDescending(r=>r.Value)
                .Take(10)
                .ToList();
            return View(model);
        }
    }
}