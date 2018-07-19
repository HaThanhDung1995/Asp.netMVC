using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class ProductController : EShopController
    {
        public ActionResult Send(int Id, String From, String To, String Subject, String Body)
        {
            var url = Request.Url.AbsoluteUri.Replace("Send", "Detail/" + Id);
            Body += "<hr><a href='" + url + "'>Chi tiết</a>";
            XMailer.Send(To, Subject, Body, From);
            return Content("Gửi mail thành công!");
        }

        public ActionResult AddToFavorite(int Id)
        {
            var ids = XCookie.GetValue("Favorites", Id.ToString());
            if (!ids.Contains(Id.ToString()))
            {
                ids += "&" + Id.ToString();
            }
            XCookie.Add("Favorites", 30, ids);
            return Content("");
        }

        public ActionResult Detail(int Id)
        {
            var model = dbc.Products.Find(Id);
            // Tăng số lần xem
            model.Views++;
            dbc.SaveChanges();

            // Ghi nhận mặt hàng đã xem bằng cookie
            var ids = XCookie.GetValue("Views", Id.ToString());
            if (!ids.Contains(Id.ToString()))
            {
                ids += "&" + Id.ToString();
            }
            XCookie.Add("Views", 30, ids);

            // Truy vấn hàng đã xem
            ViewBag.Views = dbc.Products.ToList()
                .Where(p => ids.Contains(p.Id.ToString()));

            return View(model);
        }

        public ActionResult ListByCategory(int Id)
        {
            var list = dbc.Categories.Find(Id).Products.ToList();
            return View("List", list);
        }
        public ActionResult ListBySupplier(String Id)
        {
            var list = dbc.Suppliers.Find(Id).Products.ToList();
            return View("List", list);
        }
        public ActionResult ListByKeywords(String Keywords)
        {
            var list = dbc.Products
                .Where(p => p.Name.Contains(Keywords) ||
                p.Category.Name.Contains(Keywords) ||
                p.Category.NameVN.Contains(Keywords) ||
                p.Supplier.Name.Contains(Keywords))
                .ToList();
            return View("List", list);
        }
        public ActionResult ListBySpecial(String Id)
        {
            List<Product> list = null;
            switch (Id)
            {
                case "BEST":
                    list = dbc.Products
                        .OrderByDescending(p => p.OrderDetails.Sum(d => d.Quantity))
                        .Take(10)
                        .ToList();
                    break;
                case "LATE":
                    list = dbc.Products.Where(p => p.Latest).ToList();
                    break;
                case "DISC":
                    list = dbc.Products
                        .Where(p => p.Discount > 0)
                        .OrderByDescending(p => p.Discount)
                        .ToList();
                    break;
                case "SPEC":
                    list = dbc.Products
                        .Where(p => p.Special)
                        .ToList();
                    break;
                case "FAVO":
                    list = dbc.Products
                        .Where(p => p.Views > 0)
                        .OrderByDescending(p => p.Views)
                        .Take(10)
                        .ToList();
                    break;
            }
            return View("List", list);
        }
    }
}