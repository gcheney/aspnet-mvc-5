﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.AdditionalControllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Controller = "Additonal Controller - Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
	}
}