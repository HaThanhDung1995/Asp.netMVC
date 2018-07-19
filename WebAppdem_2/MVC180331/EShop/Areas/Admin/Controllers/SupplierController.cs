using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class SupplierController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Suppliers.ToList();
            var model = new Supplier();
            return View(model);
        }

        public ActionResult Edit(String Id)
        {
            ViewBag.Items = dbc.Suppliers.ToList();
            var model = dbc.Suppliers.Find(Id);
            return View("Index", model);
        }

        public ActionResult Insert(Supplier model)
        {
            var file = Request.Files["UpLogo"];
            if (file.ContentLength > 0)
            {
                model.Logo = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/Images/Suppliers/" + model.Logo));
            }
            else
            {
                model.Logo = "Supplier.png";
            }
            try
            {
                dbc.Suppliers.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Suppliers.ToList();
                return View("Index", model);
            }
        }

        public ActionResult Update(Supplier model)
        {
            var file = Request.Files["UpLogo"];
            if (file.ContentLength > 0)
            {
                if (model.Logo != "Supplier.png")
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Suppliers/" + model.Logo));
                }
                model.Logo = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/Images/Suppliers/" + model.Logo));
            }
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
                ViewBag.Items = dbc.Suppliers.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(String Id)
        {
            var model = dbc.Suppliers.Find(Id);
            if (model.Logo != "Supplier.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Images/Suppliers/" + model.Logo));
            }
            try
            {
                dbc.Suppliers.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Suppliers.ToList();
                return View("Index", model);
            }
        }
    }
}