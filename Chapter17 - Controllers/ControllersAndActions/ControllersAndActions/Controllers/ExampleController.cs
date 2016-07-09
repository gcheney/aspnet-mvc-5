using System;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // EGT: /Example/Index
        //return a view with model
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            DateTime date = DateTime.Now;
            return View(date);
        }

        // GET: /Example/Homepage
        //return a specific view
        public ViewResult Home()
        {
            //View using alternate layout
            return View("Home", "_AlternateLayout");
        }

        //Redirects to a specified URL
        public RedirectResult RedirectToUrl()
        {
            return Redirect("/Example/Index");
        }

        //Redirects to a specific route
        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new 
            {
                conreoller = "Example",
                action = "Index",
                id = "myID"
            });
        }

        //Redirects to an action and passes temp data
        public RedirectToRouteResult RedirectToAction()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;
            return RedirectToAction("TempTest");
        }

        //receives temp data from Redirect() and displays
        //a view
        public ViewResult TempTest()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["Date"];
            return View();
        }

        //Returns a staus code
        public HttpStatusCodeResult StatusCode()
        {
            //return new HttpStatusCodeResult(404, "URL Cannot be reached or found");
            return HttpNotFound("URL Cannot be reached or found");
        }
	}
}