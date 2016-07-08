using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [HttpGet]
        public ActionResult About(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "About";
            ViewBag.CustomVariable = id;
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id = "Custom")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            ViewBag.CustomVariable = id ?? "<no value>";
            return View("ActionName");
        }

        public RedirectToRouteResult MyActionMethod(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            return RedirectToRoute(new { controller = "Home", 
                action = "CustomVariable", id = id});
        }
	}
}