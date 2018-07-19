using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class EFController : Controller
    {
        EShopV10 dbc = new EShopV10();

        // GET: EF
        public ActionResult Index()
        {
            ViewBag.List = dbc.Categories.ToList();
            var model = new Category();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.List = dbc.Categories.ToList();
            var model = dbc.Categories.Find(Id);
            return View("Index", model);
        }

        public ActionResult Insert(Category model)
        {
            try
            {
                dbc.Categories.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại";
                ViewBag.List = dbc.Categories.ToList();
                return View("Index");
            }
        }

        public ActionResult Update(Category model)
        {
            try
            {
                dbc.Entry(model).State = System.Data.EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction("Edit", new { Id = model.Id });
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại";
                ViewBag.List = dbc.Categories.ToList();
                return View("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                var model = dbc.Categories.Find(Id);
                dbc.Categories.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại";
                ViewBag.List = dbc.Categories.ToList();
                return View("Edit", new { Id = Id });
            }
        }
    }
}