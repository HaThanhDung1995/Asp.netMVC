using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorNHelper.Controllers
{
    public class CustomHelperController : Controller
    {
        // GET: CustomHelper
        public ActionResult Static()
        {
            ViewBag.Message1 = "Công cha như núi thái sơn";
            ViewBag.Message2 = "Tuy nhiên, quá trình điều tra, ông Toàn và đồng phạm kêu oan, cho rằng đã làm đúng trình tự thủ tục. Nguyên nhân thiệt hại là sau khi tiếp quản ngân hàng, ông Danh và dàn lãnh đạo cấp dưới đã gia hạn khoản vay thêm một năm và điều chỉnh lãi suất xuống 12%. Quá hạn tất toán nhưng ngân hàng (lúc này đã đổi tên thành VNCB) không thu hồi được các khoản vay.";
            return View();
        }

        public ActionResult ExtMethod()
        {
            return View();
        }

        public ActionResult Directive()
        {
            ViewBag.Message1 = "Công cha như núi thái sơn";
            ViewBag.Message2 = "Tuy nhiên, quá trình điều tra, ông Toàn và đồng phạm kêu oan, cho rằng đã làm đúng trình tự thủ tục. Nguyên nhân thiệt hại là sau khi tiếp quản ngân hàng, ông Danh và dàn lãnh đạo cấp dưới đã gia hạn khoản vay thêm một năm và điều chỉnh lãi suất xuống 12%. Quá hạn tất toán nhưng ngân hàng (lúc này đã đổi tên thành VNCB) không thu hồi được các khoản vay.";
            return View();
        }
    }
}