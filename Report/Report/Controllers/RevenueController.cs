using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.DataContracts;
using Report.Models;

namespace Report.Controllers
{
    public class RevenueController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: Revenue
        public ActionResult ByCategory()
        {
            var list = dbc.OrderDetails.GroupBy(c => c.Product.Category).Select(g => new Models.Report
            {
                Group = g.Key.NameVN,
                Quantity = g.Sum(p=>p.Quantity),
                Value = g.Sum(p=>p.UnitPrice*p.Quantity),
                AvgPrice = g.Average(p=>p.UnitPrice),
                MaxPrice = g.Max(p=>p.UnitPrice),
                MinPrice = g.Min(p=>p.UnitPrice)
            }).ToList();
            
            return View(list);
        }
        public ActionResult ByYear()
        {
            var data = dbc.OrderDetails
                .GroupBy(d => d.Order.OrderDate.Year)
                .ToList()
                .Select(g => new Models.Report
                {
                    Group = g.Key.ToString(),
                    Quantity = g.Sum(p => p.Quantity),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList();
            return View(data);
        }
    }
}