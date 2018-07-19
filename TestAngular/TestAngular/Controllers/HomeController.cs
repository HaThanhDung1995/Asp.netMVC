using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interface;

namespace TestAngular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISupplierService _supplierService;

        public HomeController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public ActionResult Index()
        {
            var list = _supplierService.ListSupplier();
            return View(list);
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
    }
}