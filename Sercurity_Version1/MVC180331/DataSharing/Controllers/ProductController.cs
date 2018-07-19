using DataSharing.Models;
using DataSharing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataSharing.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            var model = DB.Products;
            return View(model);
        }

        public ActionResult Detail(int Id)
        {
            HitCounter.Hit("/Product/Detail/" + Id);

            // Lấy cookie từ client
            var cookie = Request.Cookies["id_list"];
            // Nếu chưa tồn tại cookie id_list => Tạo mới
            if(cookie == null){
                cookie = new HttpCookie("id_list");
            }
            // Nếu chưa có sản phẩm trong cookie id_list => bổ sung vào
            if (cookie.Values[Id.ToString()] == null)
            {
                cookie.Values[Id.ToString()] = Id.ToString();
            }
            cookie.Expires = DateTime.Now.AddDays(5);
            Response.Cookies.Add(cookie);

            // Chuyển đổi tập key(id) sang List<int> để so sánh
            var ids = cookie.Values.AllKeys.Select(k=>int.Parse(k)).ToList();
            ViewBag.IdList = DB.Products.Where(p => ids.Contains(p.Id));

            var model = DB.Products.Single(p => p.Id == Id);
            return View(model);
        }
    }
}