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
        // GET: Admin/MasterRole
        public ActionResult Index()
        {
            ViewBag.Role = new SelectList(dbc.Roles.ToList(), "Id", "Name");
            ViewBag.Action = dbc.WebActions.ToList();
            return View();
        }

        public ActionResult GetAction(String RoleId)
        {
            var data = dbc.ActionRoles.Where(ar => ar.RoleId == RoleId).Select(ar => ar.WebActionId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrDelete(ActionRole model)
        {
            var message = "";
            
            try
            {
                var ms=dbc.ActionRoles.Single(mr => mr.RoleId == model.RoleId && mr.WebActionId==model.WebActionId);
                dbc.ActionRoles.Remove(ms);
                message = "Xoa Thanh Cong";
            }
            catch
            {
                dbc.ActionRoles.Add(model);
                message = "Them Thanh Cong";
            }

            dbc.SaveChanges();
            return Content(message);
        }
    }
}