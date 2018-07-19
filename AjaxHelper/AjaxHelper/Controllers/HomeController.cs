using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxHelper.Models;

namespace AjaxHelper.Controllers
{
    public class HomeController : BaseController
    {
        EShopContext dbc = new EShopContext();
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

        public ActionResult GetList()
        {
            var list = dbc.Categories.ToList();
            return PartialView(list);
        }

        public ActionResult CreateProduct()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateProduct(Category model)
        {
            try
            {
                var cateAdd = new Category
                {
                    Name = model.Name,
                    NameVN = model.NameVN
                };
                dbc.Categories.Add(cateAdd);
                dbc.SaveChanges();
                return JsonSuccess("Good Job");
            }
            catch (Exception e)
            {
                return JsonError(e.ToString());
            }
        }
    }
}