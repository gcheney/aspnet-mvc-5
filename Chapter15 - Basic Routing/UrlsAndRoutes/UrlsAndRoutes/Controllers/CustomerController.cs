using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    [RoutePrefix("Users")]
    public class CustomerController : Controller
    {
        // Ignore Route Prefix
        // GET: /Test/
        [Route("~/Customers")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        // ~/Users/Add/Adam/99
        [Route("Add/{user}/{id:int}")]
        public string Create(string user, int id)
        {
            return string.Format("User: {0}, ID: {1}", user, id);
        }

        // ~/Users/Angela
        [Route("{user:alpha:length(6)}")]
        public string ChangePassConstraints(string user)
        {
            return string.Format("ChangePass Constraint Method - User: {0}", user);
        }

        // ~/Users/Add/Adam/Password
        [Route("Add/{user}/{password}")]
        public string ChangePass(string user, string password)
        {
            return string.Format("ChangePass Method - User: {0}, Pass: {1}",
                user, password);
        }

        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
	}
}