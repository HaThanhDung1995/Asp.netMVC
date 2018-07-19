using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Again.Models;
using AjaxPractice.Controllers;

namespace Again.Controllers
{
    public class TestController : BaseController
    {
        Shop dbc = new Shop();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListCate()
        {
            var user = dbc.Categories.ToList();
            return PartialView("_ListCate",user);
        }

        public ActionResult Create()
        {
            return PartialView("_CreateCate");
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                var caadd = new Category
                {
                    Name = model.Name,
                    NameVN = model.NameVN
                };
                dbc.Categories.Add(caadd);
                dbc.SaveChanges();
                return JsonSuccess("Thêm Thành Công");
            }
            catch (Exception e)
            {
                return JsonError("Thêm Thất Bại");
            }
        }
        public ActionResult Update(int Id)
        {
            var user = dbc.Categories.Find(Id);
            return PartialView("_Update",user);
        }
        [HttpPost]
        public ActionResult Update(Category model)
        {
            try
            {
                var cate = dbc.Categories.Find(model.Id);
                cate.Name = model.Name;
                cate.NameVN = model.NameVN;
                dbc.SaveChanges();
                return JsonSuccess("Cập Nhật Thành Công");
            }
            catch (Exception e)
            {
                return JsonError("Cập nhật thất bại");
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