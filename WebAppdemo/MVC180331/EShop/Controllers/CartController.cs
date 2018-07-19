using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Add(int Id)
        {
            XSession.Cart.Add(Id);
            var data = new
            {
                Count = XSession.Cart.Count,
                Amount = String.Format("{0:#,###.#0}", XSession.Cart.Amount)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(int Id)
        {
            XSession.Cart.Remove(Id);
            var data = new
            {
                Count = XSession.Cart.Count,
                Amount = String.Format("{0:#,###.#0}", XSession.Cart.Amount)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int Id, int Qty)
        {
            XSession.Cart.Update(Id, Qty);
            var data = new
            {
                Count = XSession.Cart.Count,
                Amount = String.Format("{0:#,###.#0}", XSession.Cart.Amount)
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Clear()
        {
            XSession.Cart.Clear();
            return View("Index");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}