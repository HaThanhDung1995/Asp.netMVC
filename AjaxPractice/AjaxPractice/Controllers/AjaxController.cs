using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxPractice.Models;

namespace AjaxPractice.Controllers
{
    public class AjaxController : BaseController
    {
        ShopNe dbc =new ShopNe();
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            var model = dbc.Categories.ToList();
            return PartialView("_GetList",model);
        }
        public ActionResult CreateCate()
        {
            return PartialView("_CreateCate");
        }
        [HttpPost]
        public ActionResult CreateCate(Category model)
        {
            try
            {
                var cateadd = new Category
                {
                    Name = model.Name,
                    NameVN = model.NameVN
                };
                dbc.Categories.Add(cateadd);
                dbc.SaveChanges();
                return JsonSuccess("Good");
            }
            catch (Exception e)
            {
                return JsonError(e.ToString());
            }
            
           
        }
        public ActionResult Update(int id)
        {
            var user = dbc.Categories.Find(id);
            return PartialView("_Update",user);
        }
        [HttpPost]
        public ActionResult Update(Category model)
        {
            try
            {
                var user = dbc.Categories.Find(model.Id);
                user.NameVN = model.NameVN;
                user.Name = model.Name;
                dbc.SaveChanges();
                return JsonSuccess("Godd");
            }
            catch (Exception e)
            {
                return JsonError(e.ToString());
            }
            
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = dbc.Categories.Find(id);
                dbc.Categories.Remove(user);
                dbc.SaveChanges();
                return JsonSuccess("haha");
            }

            catch (Exception e)
            {
                return JsonError("Loi roi");
            }
        }

    }

}