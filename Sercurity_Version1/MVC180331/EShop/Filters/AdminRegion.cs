using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;

namespace EShop.Filters
{
    public class AdminRegionAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url.AbsoluteUri;
            if (!url.Contains("/Admin/") || url.Contains("/Admin/Home"))
            {
                return;
            }

            var Master = HttpContext.Current.Session["Master"] as Master;
            if (Master == null)
            {
                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                filterContext.Result=new RedirectResult("/Admin/Home/Login?Reason=Chua dang nhap");
                return;
            }

            var action = (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                         filterContext.ActionDescriptor.ActionName).ToLower();
            using (var dbc = new EShopDbContext())
            {
                var actionav = dbc.WebActions.Any(wb => wb.Name == action);
                if (!actionav)
                {
                    return;
                }

                var RoleIds = dbc.MasterRoles.Where(mr => mr.MasterId == Master.Id).Select(r => r.RoleId);
                if (dbc.ActionRoles.Any(ar => ar.WebAction.Name == action && RoleIds.Contains(ar.RoleId)))
                {
                    return;
                }

                HttpContext.Current.Session["ReturnUrl"] = HttpContext.Current.Request.Url.AbsoluteUri;
                filterContext.Result = new RedirectResult("/Admin/Home/Login?Reason=Chua cap quyen");
            }
        }
    }
}