using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class WebActionController : EShopController
    {
        public ActionResult Index()
        {
            var model = new WebAction();
            ViewBag.Items = dbc.WebActions.ToList();
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.WebActions.Find(Id);
            ViewBag.Items = dbc.WebActions.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(WebAction entity)
        {
            try
            {
                dbc.WebActions.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(WebAction entity)
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

        public ActionResult Delete(int Id)
        {
            try
            {
                var entity = dbc.WebActions.Find(Id);
                dbc.WebActions.Remove(entity);
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