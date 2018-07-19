using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DataSharing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Chạy SAU khi ứng dụng khởi động thành công
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var path = Server.MapPath("~/App_Data/Visitors.txt");
            var text = File.ReadAllText(path);
            Application["Visitors"] = int.Parse(text);
        }

        // Chạy TRƯỚC khi ứng dụng shutdown
        protected void Application_End()
        {
            var path = Server.MapPath("~/App_Data/Visitors.txt");
            var text = Application["Visitors"].ToString();
            File.WriteAllText(path, text);
        }

        // Chạy SAU khi có một phiên làm việc được tạo ra
        protected void Session_Start()
        {
            Application.Lock();
            Application["Visitors"] = (int)Application["Visitors"] + 1;

            var path = Server.MapPath("~/App_Data/Visitors.txt");
            var text = Application["Visitors"].ToString();
            File.WriteAllText(path, text);
            Application.UnLock();
        }

        // Chạy TRƯỚC khi một phiên làm việc hết hạn
        protected void Session_End()
        {
        }

        // Chạy SAU khi có một yêu cầu từ người dùng
        protected void Application_BeginRequest()
        {
        }

        // Chạy TRƯỚC kết thúc một yêu cầu từ người dùng
        protected void Application_EndRequest()
        {
        }
    }
}
