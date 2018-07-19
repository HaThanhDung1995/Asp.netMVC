using ActionFilter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilter.Controllers
{
    [Authenticate]
    public class OrderController : Controller
    {
        // Thanh toán
        public ActionResult Checkout()
        {
            return View();
        }
        // Danh sách đơn hàng của người sử dụng
        public ActionResult List()
        {
            return View();
        }
        // Chi tiết đơn hàng
        public ActionResult Detail()
        {
            return View();
        }
        // Các mặt hàng đã mua
        public ActionResult Items()
        {
            return View();
        }
    }
}