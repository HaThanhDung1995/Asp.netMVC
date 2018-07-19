using MyController2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyController2.Controllers
{
    public class MayTinhController : Controller
    {
        // GET: MayTinh
        public ActionResult Index()
        {
            ViewBag.ThongTin = new MayTinh();
            return View();
        }

        public ActionResult Calculate(MayTinh model)
        {
            switch (model.O)
            {
                case '+':
                    model.C = model.A + model.B;
                    break;
                case '-':
                    model.C = model.A - model.B;
                    break;
                case 'x':
                    model.C = model.A * model.B;
                    break;
                case ':':
                    model.C = model.A / model.B;
                    break;
            }
            ViewBag.ThongTin = model;

            return View("Index");
        }
    }
}