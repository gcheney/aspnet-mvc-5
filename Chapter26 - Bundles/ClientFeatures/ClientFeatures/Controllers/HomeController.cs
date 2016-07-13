using System;
using System.Web.Mvc;
using ClientFeatures.Models;

namespace ClientFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult MakeAppointment()
        {
            Appointment appt = new Appointment
            {
                ClientName = "Adam",
                TermsAccepted = true
            };
            return View(appt);
        }

        [HttpPost]
        public ActionResult MakeAppointment(Appointment appt)
        {
            // TODO: statements to store appointment in repository

            if (!ModelState.IsValid)
            {
                return RedirectToAction("MakeAppointment");
            }
            return Json(appt, JsonRequestBehavior.AllowGet);
        }
	}
}