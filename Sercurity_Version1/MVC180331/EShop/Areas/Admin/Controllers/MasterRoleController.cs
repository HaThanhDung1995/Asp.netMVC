using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Controllers;
using EShop.Models;

namespace EShop.Areas.Admin.Controllers
{
    public class MasterRoleController : EShopController
    {
        // GET: Admin/MasterRole
        public ActionResult Index()
        {
            ViewBag.Master = new SelectList(dbc.Masters.ToList(), "Id", "FullName");
            ViewBag.Role = dbc.Roles.ToList();
            return View();
        }

        public ActionResult GetRole(String MasterId)
        {
            var data = dbc.MasterRoles.Where(mr => mr.MasterId == MasterId).Select(mr=>mr.RoleId).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrDelete(MasterRole model)
        {
            var message = "";
            try
            {
                var ms=dbc.MasterRoles.Single(mr => mr.MasterId == model.MasterId && mr.RoleId==model.RoleId);
                dbc.MasterRoles.Remove(ms);
                message = "Xoa Thanh Cong";
            }
            catch
            {
                dbc.MasterRoles.Add(model);
                message = "Them Thanh Cong";
            }

            dbc.SaveChanges();
            return Content(message);
        }
    }
}