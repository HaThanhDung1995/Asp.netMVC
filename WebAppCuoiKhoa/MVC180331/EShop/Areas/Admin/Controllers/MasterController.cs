using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class MasterController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Master();
            ViewBag.Items = dbc.Masters.ToList();
            return View(model);
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Masters.Find(Id);
            ViewBag.Items = dbc.Masters.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Master entity)
        {
            try
            {
                dbc.Masters.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Master entity)
        {
            try
            {
                dbc.Entry(entity).State = System.Data.EntityState.Modified;
                dbc.SaveChanges();
                TempData["Message"] = "Cập nhật thành công!";
            }
            catch
            {
                TempData["Message"] = "Cập nhật thất bại!";
            }
            return RedirectToAction("Edit", new { entity.Id });
        }

        public ActionResult Delete(String Id)
        {
            try
            {
                var entity = dbc.Masters.Find(Id);
                dbc.Masters.Remove(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}