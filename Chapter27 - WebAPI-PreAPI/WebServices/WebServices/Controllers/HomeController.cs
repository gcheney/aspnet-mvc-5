using System.Web.Mvc;
using WebServices.Models;
using WebServices.Infrastructure;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        private ReservationRespository repo = ReservationRespository.Current;

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                repo.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Remove(int id)
        {
            if (repo.Remove(id) != null) 
            { 
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid && repo.Update(item))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
	}
}