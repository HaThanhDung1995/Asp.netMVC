using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;

namespace EShop.Filters
{
    public class B1b2b3Attribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            //Lấy Url
            var uri = ctx.HttpContext.Request.Url.AbsoluteUri;
            //Nếu nó không chứa Admin hoặc Admin/Home thì cho phép chạy còn nếu có admin thì dính cái authenticate của admin
            if (!uri.Contains("/Admin/") || uri.Contains("/Admin/Home"))
            {
                return;
            }
            //Lấy Session lưu khi Master đăng nhập
            //Lọc Tiếp
            var Master = HttpContext.Current.Session["Master"] as Master;
            //Nếu không có thì đưa về trang đăng nhập
            if (Master == null)
            {
                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Home/Login?Reason=Chua dang nhap");
                return;
            }

            //Xử lý chức năng phân vai trò
            //Lấy Action rồi chuyền chúng về chữ thường
            var action = (ctx.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + ctx.ActionDescriptor.ActionName).ToLower();


            //Sử dụng cơ sở dữ liệu truy vấn
            using (var dbc = new EShopDbContext())
            {



                var action1 = dbc.WebActions.Any(wa => wa.Name == action);
                //Nếu trong cơ sở dữ liệu không có lưu action thì thông qua
                if (!action1)
                {

                    return;
                }
                //Lấy RoleIds
                //Lưu ý người dùng phải đăng nhập thì mới có thể phân quyền nền vì vậy mới có MasterId
                //Select sẽ giúp chúng ta lấy được những giá trị nằm trong đó
                var RoleIds = dbc.MasterRoles
                    .Where(mr => mr.MasterId == Master.Id)
                    .Select(mr => mr.RoleId);
                //Nếu trong ActionRole có chưa bất kỳ cái gì của web action và chứa RoleId
                //Thì cho thông qua
                //Đây là chỗ giải quyết vấn đề chó phép dùng action

                if (dbc.ActionRoles
                    .Any(ar => ar.WebAction.Name == action && RoleIds.Contains(ar.RoleId)))
                {

                    return;
                }
                //Không thì trả về trang Login vì chưa cấp quyền
                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Home/Index?Reason=Chua cap quyen");




                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Home/Index?Reason=Chua cap quyen");


                //Xử lý chức năng phân vai trò
                //Lấy Action rồi chuyền chúng về chữ thường
                //var action = (ctx.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + ctx.ActionDescriptor.ActionName).ToLower();
                ////Sử dụng cơ sở dữ liệu truy vấn
                //using (var dbc = new EShopDbContext())
                //{
                //    var action1 = dbc.WebActions.Any(wa => wa.Name == action);
                //    //Nếu trong cơ sở dữ liệu không có lưu action thì thông qua
                //    if (!action1)
                //    {

                //        return;
                //    }
                //    //Lấy RoleIds
                //    //Lưu ý người dùng phải đăng nhập thì mới có thể phân quyền nền vì vậy mới có MasterId
                //    //Select sẽ giúp chúng ta lấy được những giá trị nằm trong đó
                //    var RoleIds = dbc.MasterRoles
                //        .Where(mr=>mr.MasterId==Master.Id)
                //        .Select(mr=>mr.RoleId);
                //    //Nếu trong ActionRole có chưa bất kỳ cái gì của web action và chứa RoleId
                //    //Thì cho thông qua
                //    //Đây là chỗ giải quyết vấn đề chó phép dùng action

                //    if(dbc.ActionRoles
                //        .Any(ar=>ar.WebAction.Name == action && RoleIds.Contains(ar.RoleId)))
                //    {
                //        return;
                //    }
                //    //Không thì trả về trang Login vì chưa cấp quyền
                //    HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                //    ctx.Result = new RedirectResult("/Admin/Home/Index?Reason=Chua cap quyen");
                //}
            }
        }
    }
}