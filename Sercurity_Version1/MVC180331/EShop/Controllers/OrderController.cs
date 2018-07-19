using EShop.Filters;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    [Authenticate]
    public class OrderController : EShopController
    {
        // GET: Order
        public ActionResult Checkout()
        {
            var model = new Order();
            model.OrderDate = DateTime.Now;
            model.CustomerId = XSession.User.Id;
            model.Amount = XSession.Cart.Amount;
            model.Receiver = XSession.User.Fullname;
            model.RequireDate = DateTime.Now.AddDays(5);

            return View(model);
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            dbc.Orders.Add(order);
            foreach (var p in XSession.Cart.Items)
            {
                var detail = new OrderDetail
                {
                    Discount = p.Discount,
                    Order = order,
                    ProductId = p.Id,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice
                };
                dbc.OrderDetails.Add(detail);
            }
            dbc.SaveChanges();
            ModelState.AddModelError("", "Đặt hàng thành công!");
            XSession.Cart.Clear();
            return View();
        }

        public ActionResult List()
        {
            var model = dbc.Orders
                .Where(o => o.CustomerId == XSession.User.Id)
                .OrderByDescending(o=>o.OrderDate)
                .ToList();
            return View(model);
        }

        public ActionResult Detail(int Id)
        {
            var model = dbc.Orders.Find(Id);
            return View(model);
        }

        public ActionResult Cancel(int Id)
        {
            var model = dbc.Orders.Find(Id);
            dbc.Orders.Remove(model);
            dbc.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Items()
        {
            var model = dbc.OrderDetails
                .Where(d => d.Order.CustomerId == XSession.User.Id)
                .Select(d => d.Product)
                .Distinct()
                .ToList();
            return View("../Product/List", model);
        }
    }
}