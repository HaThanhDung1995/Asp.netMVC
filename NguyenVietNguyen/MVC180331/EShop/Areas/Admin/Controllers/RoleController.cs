using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class RoleController : EShopController
    {
        public ActionResult Index()
        {
            var model = new Role();
            ViewBag.Items = dbc.Roles.ToList();
            return View(model);
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Roles.Find(Id);
            ViewBag.Items = dbc.Roles.ToList();
            return View("Index", model);
        }

        public ActionResult Insert(Role entity)
        {
            try
            {
                dbc.Roles.Add(entity);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Update(Role entity)
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
                var entity = dbc.Roles.Find(Id);
                dbc.Roles.Remove(entity);
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