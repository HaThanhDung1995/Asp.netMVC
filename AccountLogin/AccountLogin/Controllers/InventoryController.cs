using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;

namespace AccountLogin.Controllers
{
    public class InventoryController : Controller
    {
        EShopDatabaseContext dbc = new EShopDatabaseContext();
        // GET: Inventory
        public ActionResult Inventory()
        {
            var model = dbc.Products
                .GroupBy(p => p.Category)
                .Select(g => new Report
                {
                    Category = g.Key.NameVN,
                    Count = g.Count(),
                    Sum = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .ToList()
                ;
            return View(model);
        }
        public ActionResult InventoryForCategory()
        {
            var model = dbc.OrderDetails
                    .GroupBy(p => p.Product.Category)
                    .Select(g => new Report
                    {
                        Category = g.Key.NameVN,
                        Count = g.Count(),
                        Sum = g.Sum(p => p.UnitPrice * p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        AvgPrice = g.Average(p => p.UnitPrice)
                    })
                    .ToList()
                ;
            return View(model);
        }

        public ActionResult InventoryForCustomer()
        {
            var model = dbc.OrderDetails.GroupBy(c => c.Order.Customer).Select(g => new Report
                {
                    Category = g.Key.Fullname,
                    Count = g.Count(),
                    Sum = g.Sum(p => p.UnitPrice * p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                
                
                .ToList();
            return View(model);
        }
    }
}