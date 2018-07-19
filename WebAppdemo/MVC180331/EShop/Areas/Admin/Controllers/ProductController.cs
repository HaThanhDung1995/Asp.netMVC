using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class ProductController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.Items = dbc.Products.ToList();
            var model = new Product();
            ViewBag.CategoryID = new SelectList(dbc.Categories, "Id", "NameVN");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Items = dbc.Products.ToList();
            var model = dbc.Products.Find(Id);
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN", model.CategoryId);
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name", model.SupplierId);
            return View("Index", model);
        }

        [ValidateInput(false)]
        public ActionResult Insert(Product model)
        {
            var file = Request.Files["UpImage"];
            if (file.ContentLength > 0)
            {
                model.Image = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/Images/Products/" + model.Image));
            }
            else
            {
                model.Image = "Product.png";
            }
            try
            {
                dbc.Products.Add(model);
                dbc.SaveChanges();
                TempData["Message"] = "Thêm mới thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Thêm mới thất bại!";
                ViewBag.Items = dbc.Products.ToList();
                return View("Index", model);
            }
        }
        [ValidateInput(false)]
        public ActionResult Update(Product model)
        {
            var file = Request.Files["UpImage"];
            if (file.ContentLength > 0)
            {
                if (model.Image != "Product.png")
                {
                    System.IO.File.Delete(Server.MapPath("~/Images/Products/" + model.Image));
                }
                model.Image = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/Images/Products/" + model.Image));
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
                ViewBag.Items = dbc.Products.ToList();
                return View("Index", model);
            }
        }
        public ActionResult Delete(int Id)
        {
            var model = dbc.Products.Find(Id);
            if (model.Image != "Product.png")
            {
                System.IO.File.Delete(Server.MapPath("~/Images/Products/" + model.Image));
            }
            try
            {
                dbc.Products.Remove(model);
                dbc.SaveChanges();
                TempData["Message"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Message"] = "Xóa thất bại!";
                ViewBag.Items = dbc.Products.ToList();
                return View("Index", model);
            }
        }

        public ActionResult getPage(int PageNo = 0, int PageSize = 6)
        {
            ViewBag.Items = dbc.Products
                .OrderBy(p=>p.Id)
                .Skip(PageNo*PageSize)
                .Take(PageSize)
                .ToList();
            return PartialView("_Page");
        }

        public ActionResult getPageCount(int PageSize = 6)
        {
            var RowCount = dbc.Products.Count();
            var PageCount = Math.Ceiling(1.0 * RowCount / PageSize);
            return Content(PageCount.ToString());
        }

        
    }
}