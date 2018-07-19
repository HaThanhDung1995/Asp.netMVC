using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilter.Filters
{
    public class LogFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.log("OnActionExecuting()");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log.log("OnActionExecuted()");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log.log("OnResultExecuting()");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log.log("OnResultExecuted()");
        }
    }
}