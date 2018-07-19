using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Controllers
{
    public class EShopController : Controller
    {
        protected EShopDbContext dbc = new EShopDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}