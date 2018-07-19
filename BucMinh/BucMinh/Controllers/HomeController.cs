using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BucMinh.Models;



namespace BucMinh.Controllers
{
    public class HomeController : Controller
    {
        DataContext dbc = new DataContext();
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Đổ dữ liệu
        public ActionResult Json()
        {
            var model = dbc.Products.OrderByDescending(x=>x.Id).ToList();
            
            return Json(model.Select(x => new 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    Supplier = x.Supplier.Name
                })
                , JsonRequestBehavior.AllowGet);
        }
        //Thêm
        [HttpPost]
        public ActionResult Create(Product model)
        {
           
            dbc.Products.Add(model);
            dbc.SaveChanges();
            var data = new
            {
                message="Add Thanh Cong"
            };
            return Content("thanh dong");
        }
        
        public ActionResult Edit(int Id)
        {

            var model = dbc.Products.Single(a=>a.Id==Id);
           

            return Json(new SubProduct()
            {
                Id = model.Id,
                Name = model.Name,
                Category = model.CategoryId,
                Supplier = model.SupplierId
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(Product model)
        {

            var product = dbc.Products.Single(a => a.Id == model.Id);
            product.CategoryId = model.CategoryId;
            product.SupplierId = model.SupplierId;
            product.Name = model.Name;
            dbc.SaveChanges();


            return Json(new
            {
                message = "Thanh Cong"
            });
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {

            var model = dbc.Products.Single(a => a.Id == Id);
            dbc.Products.Remove(model);
            dbc.SaveChanges();

            return Content("Xoa Thanh Cong");
        }

    }
}