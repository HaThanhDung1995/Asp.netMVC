using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class ActionRoleController : EShopController
    {
        public ActionResult Index()
        {
            ViewBag.RoleId = new SelectList(dbc.Roles, "Id", "Name");
            ViewBag.WebActions = dbc.WebActions.ToList();

            return View();
        }

        public ActionResult GetActionIds(String RoleId)
        {
            var WebActionIds = dbc.ActionRoles
                .Where(ar => ar.RoleId == RoleId)
                .Select(ar => ar.WebActionId).ToList();

            return Json(WebActionIds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrDelete(ActionRole model)
        {
            var message = "";
            try
            {
                var ActionRole = dbc.ActionRoles
                    .Single(mr => mr.RoleId == model.RoleId && mr.WebActionId == model.WebActionId);
                dbc.ActionRoles.Remove(ActionRole);
                message = "Xóa quyền";
            }
            catch
            {
                dbc.ActionRoles.Add(model);
                message = "Thêm quyền";
            }
            dbc.SaveChanges();

            return Content(message);
        }
    }
}