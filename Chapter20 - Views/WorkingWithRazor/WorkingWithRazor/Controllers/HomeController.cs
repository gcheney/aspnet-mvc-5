using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] names = { "Apple", "Orange", "Pear" };
            return View(names);
        }

        [ChildActionOnly]
        public ActionResult Time(DateTime time)
        {
            return PartialView(time);
        }
	}
}