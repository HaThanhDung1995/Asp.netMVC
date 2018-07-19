using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaoXuanTruong.Models;

namespace CaoXuanTruong.Controllers
{
    public class CategoryController : Controller
    {
        EshopDatabseContext dbc =new EshopDatabseContext();
        // GET: Category
        public ActionResult Index()
        {
            var model = dbc.Categories.ToList();
            return View(model);
        }
        public ActionResult Product(int Id)
        {
            var model = dbc.Categories.Find(Id);
            return View(model);
        }
    }
}