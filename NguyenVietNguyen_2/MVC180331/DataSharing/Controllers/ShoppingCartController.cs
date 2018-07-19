using DataSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataSharing.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Add(int Id)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<Product>();
            }
            var Cart = Session["Cart"] as List<Product>;
            try
            {
                var Item = Cart.Single(p => p.Id == Id);
                Item.Quantity++;
            }
            catch
            {
                // Lấy mặt hàng từ CSDL
                var Item = DB.Products.Single(p => p.Id == Id);
                // Bỏ vào giỏ hàng
                Cart.Add(Item);
            }
            return RedirectToAction("List", "Product");
        }

        public ActionResult Index()
        {
            var Cart = Session["Cart"] as List<Product>;
            return View(Cart);
        }
    }
}