using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class CategoryController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Categories.ToList();
            var model = new Category();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Categories.ToList();
            var model = dbc.Categories.Find(Id);
            return View("Index", model);
        }

        public ActionResult Insert(Category model)
        {
            try
            {
                dbc.Categories.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Categories.ToList();
                return View("Index", model);
            }
        }

        public ActionResult Update(Category model)
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
                ViewBag.Items = dbc.Categories.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Categories.Find(Id);
            try
            {
                dbc.Categories.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Categories.ToList();
                return View("Index", model);
            }
        }
    }
}