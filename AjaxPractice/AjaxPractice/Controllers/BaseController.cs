﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxPractice.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public JsonResult JsonSuccess(string message, object data = null,
            JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return new JsonResult
            {
                Data = new
                {
                    type = "Success",
                    message = message,
                    data = data
                },

                JsonRequestBehavior = behavior
            };
        }

        public JsonResult JsonError(string message, object data = null,
            JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return new JsonResult
            {
                Data = new
                {
                    type = "Error",
                    message = message,
                    data = data
                },

                JsonRequestBehavior = behavior
            };
        }
    }
}