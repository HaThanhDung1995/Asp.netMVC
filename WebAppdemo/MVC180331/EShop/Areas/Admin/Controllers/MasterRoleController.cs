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
            ViewBag.Master = new SelectList(dbc.Masters,"Id","FullName");
            ViewBag.Role = dbc.Roles.ToList();
            return View();
        }
        //Lấy Các Role Thuộc Master này thông qua bảng Master Role
        public ActionResult GetRoleIds(String MasterId)
        {
            var data = dbc.MasterRoles.Where(mr => mr.MasterId == MasterId).Select(mr => mr.RoleId).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddOrDelete(MasterRole model)
        {
            var message = "";
            //Nếu tồn tại thì xóa
            try
            {
                var data = dbc.MasterRoles.Single(mr => mr.MasterId == model.MasterId && mr.RoleId == model.RoleId);
                dbc.MasterRoles.Remove(data);
                message = "Thêm thành công";
            }
            //Không tồn tại thì thêm vào
            catch
            {
                dbc.MasterRoles.Add(model);
                message = "Xóa thành công";
            }

            dbc.SaveChanges();
            return Content(message);
        }
    }
}