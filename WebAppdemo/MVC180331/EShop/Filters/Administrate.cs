using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Filters
{
    public class AdministrateAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            // Lấy địa chỉ action được yêu cầu
            var AbsoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;

            /*
             * 1. Không kiểm tra ngoài vùng Admin và Home/Login
             */
            if (!AbsoluteUri.Contains("/Admin/"))
            {
                return;
            }

            /*
             * 2. Bắt buộc phải đăng nhập khi vào bất kỳ trang nào của Admin
             */
            if (XSession.Master == null)
            {
                ctx.Controller.ViewData.ModelState.AddModelError("", "Vui lòng đăng nhập!");
                XSession.ReturnUrl = AbsoluteUri;
                ctx.Result = new RedirectResult("/Admin/Account/Login");
                return;
            }

            // Lấy tên action được truy cập và đổi sang chữ thường để phù hợp với CSDL
            var actionName = (ctx.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + ctx.ActionDescriptor.ActionName).ToLower();
            using (var dbc = new EShopDbContext())
            {
                /*
                 * 3. Không kiểm tra những action không nhập vào WebActions
                 */
                if (!dbc.WebActions.Any(a => a.Name == actionName))
                {
                    return;
                }
                // Vai trò của Master đăng nhập
                var rolesOfMaster = dbc.MasterRoles
                    .Where(mr => mr.MasterId == XSession.Master.Id)
                    .Select(mr => mr.RoleId)
                    .ToList();
                // Vai trò cho phép truy cập actionName
                var rolesAllow = dbc.ActionRoles
                    .Where(ar => ar.WebAction.Name == actionName)
                    .Select(ar => ar.RoleId)
                    .ToList();
                /*
                 * 4. Kiểm tra Master có được cấp quyền sử dụng actionName này hay không
                 */
                if (!rolesOfMaster.Any(roleId => rolesAllow.Contains(roleId)))
                {
                    ctx.Controller.ViewData.ModelState.AddModelError("", "Bạn không được cấp quyền để thực hiện chức năng này!");
                    XSession.ReturnUrl = AbsoluteUri;
                    ctx.Result = new RedirectResult("/Admin/Account/Login");
                }
            }
        }
    }
}