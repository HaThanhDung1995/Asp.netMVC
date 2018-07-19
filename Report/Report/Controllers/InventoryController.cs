using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Report.Models;

namespace Report.Controllers
{
    public class InventoryController : Controller
    {
        DataContext dbc =new DataContext();
        // GET: Inventory
        public ActionResult ByCategory()
        {
            var list = dbc.Products.GroupBy(p => p.Category).Select(g => new Models.Report 
            {
                Group=g.Key.NameVN,
                Quantity=g.Sum(p=>p.Quantity),
                Value = g.Sum(p => p.UnitPrice * p.Quantity),
                MinPrice = g.Min(p => p.UnitPrice),
                MaxPrice = g.Max(p => p.UnitPrice),
                AvgPrice = g.Average(p => p.UnitPrice)
            });
            return View(list);
        }
    }
}