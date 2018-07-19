using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxHelper.Models;

namespace AjaxHelper.Controllers
{
    public class AjaxController : BaseController
    {
        EShopContext dbc= new EShopContext();
        // GET: Ajax
        public ActionResult Index3()
        {
            return View();
        }
        
        
        public ActionResult GetList()
        {
            var categories = dbc.Categories.ToList();
            return PartialView("_Getlist", categories);
        }
       
       
        public ActionResult CreateProduct()
        {
            return PartialView("_CreateProduct");
        }
        [HttpPost]
        public ActionResult CreateProduct(Category model)
        {
            try
            {
               
               var cateAdd=new Category
                {
                   Name = model.Name,
                   NameVN = model.NameVN
                };
                dbc.Categories.Add(cateAdd);
                dbc.SaveChanges();
                return JsonSuccess("Create Success");
            }
            catch(Exception e)
            {
                return JsonError(e.Message);
            }
           
        }
    }
}