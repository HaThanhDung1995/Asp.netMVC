using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class OrderController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Orders.ToList();
            var model = new Order();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Orders.ToList();
            var model = dbc.Orders.Find(Id);
            return View("Index", model);
        }

        public ActionResult Insert(Order model)
        {
            try
            {
                dbc.Orders.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Orders.ToList();
                return View("Index", model);
            }
        }

        public ActionResult Update(Order model)
        {
            try
            {
                dbc.Entry(model).State = System.Data.EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("Edit", new { model.Id });
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
                ViewBag.Items = dbc.Orders.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Orders.Find(Id);
            try
            {
                dbc.Orders.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Orders.ToList();
                return View("Index", model);
            }
        }
    }
}