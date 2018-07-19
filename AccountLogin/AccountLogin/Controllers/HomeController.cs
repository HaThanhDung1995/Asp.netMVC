using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountLogin.Models;

namespace AccountLogin.Controllers
{
    public class HomeController : BaseController
    {
        EShopDatabaseContext dbc = new EShopDatabaseContext();

        public ActionResult Index()
        {
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

        public ActionResult GetListProduct()
        {
            var listProduct = dbc.Products.OrderByDescending(x => x.Id).ToList();
            return PartialView(listProduct);
        }

        
        public ActionResult CreateProduct()
        {
            return PartialView("_CreateProduct");
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                var productAdd = new Product
                {
                    Available = true,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Image = product.Image,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    ProductDate = DateTime.Now,
                    UnitPrice = product.UnitPrice,
                };
                dbc.Products.Add(productAdd);
                dbc.SaveChanges();
                return JsonSuccess("Create Success");
            }
            catch (Exception e)
            {
                return JsonError(e.Message);
            }
        }
    }
}