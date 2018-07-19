using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilter.Filters
{
    public class AuthenticateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Session = HttpContext.Current.Session;
            if (Session["user"] == null)
            {
                Session["ReturnUrl"] = HttpContext.Current.Request.Url.ToString();
                HttpContext.Current.Response.Redirect("/Account/Login");
            }
        }
    }
}