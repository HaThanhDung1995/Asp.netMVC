using DataSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataSharing.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: ProductManager
        public ActionResult Index()
        {
            if (Session["XXX"] == null)
            {
                Session["XXX"] = DB.Products;
            }
            var model = new Product();
            ViewBag.Items = Session["XXX"];
            return View(model);
        }

        public ActionResult Insert(Product model)
        {
            var Items = Session["XXX"] as List<Product>;
            Items.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var Items = Session["XXX"] as List<Product>;
            var model = Items.Single(p => p.Id == Id);
            ViewBag.Items = Items;
            return View("Index", model);
        }

        public ActionResult Update(Product model)
        {
            var Items = Session["XXX"] as List<Product>;
            var Item = Items.Single(p => p.Id == model.Id);
            Item.Name = model.Name;
            Item.UnitPrice = model.UnitPrice;
            Item.Image = model.Image;
            Item.Description = model.Description;

            return RedirectToAction("Edit", new { Id = model.Id });
        }

        public ActionResult Delete(int Id)
        {
            var Items = Session["XXX"] as List<Product>;
            var model = Items.Single(p => p.Id == Id);
            Items.Remove(model);
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
    }
}