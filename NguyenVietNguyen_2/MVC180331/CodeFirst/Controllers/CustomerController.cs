using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class CustomerController : Controller
    {
        EShopDbContext dbc = new EShopDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            var users = dbc.Customers.ToList();
            return View(users);
        }
    }
}