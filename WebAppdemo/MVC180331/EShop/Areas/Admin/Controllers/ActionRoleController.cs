using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Controllers;
using EShop.Models;

namespace EShop.Areas.Admin.Controllers
{
    public class ActionRoleController : EShopController
    {
        // GET: Admin/ActionRole
        public ActionResult Index()
        {
            ViewBag.Role = new SelectList(dbc.Roles, "Id", "Name");
            ViewBag.Action = dbc.WebActions.ToList();
            return View();
        }
        public ActionResult ActionIds(String RoleId)
        {
            var data = dbc.ActionRoles.Where(ar => ar.RoleId == RoleId).Select(ar=>ar.WebActionId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrDelete(ActionRole model)
        {
            var message = "";
            try
            {
                var a = dbc.ActionRoles.Single(ar => ar.RoleId == model.RoleId && ar.WebActionId == model.WebActionId);
                dbc.ActionRoles.Remove(a);
                message = "Xóa Thành Công";
            }

            catch
            {
                dbc.ActionRoles.Add(model);
                message = "Thêm Thành Công";
            }

            dbc.SaveChanges();
            return Content(message);
        }
    }
}