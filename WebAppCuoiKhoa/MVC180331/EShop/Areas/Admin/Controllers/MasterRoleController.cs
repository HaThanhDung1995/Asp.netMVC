using EShop.Controllers;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    public class MasterRoleController : EShopController
    {
        // GET: Admin/MasterRole
        public ActionResult Index()
        {
            ViewBag.MasterId = new SelectList(dbc.Masters, "Id", "FullName");
            ViewBag.Roles = dbc.Roles.ToList();

            return View();
        }

        public ActionResult GetRoleIds(String MasterId)
        {
            var RoleIds = dbc.MasterRoles
                .Where(mr => mr.MasterId == MasterId)
                .Select(mr => mr.RoleId).ToList();

            return Json(RoleIds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrDelete(MasterRole model)
        {
            try
            {
                var MasterRole = dbc.MasterRoles
                    .Single(mr => mr.RoleId == model.RoleId && mr.MasterId == model.MasterId);
                dbc.MasterRoles.Remove(MasterRole);
            }
            catch
            {
                dbc.MasterRoles.Add(model);
            }
            dbc.SaveChanges();

            return Content("Đã cập nhật vai trò");
        }
    }
}