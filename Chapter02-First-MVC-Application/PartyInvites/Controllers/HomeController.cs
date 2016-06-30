using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        //
        // GET: Home/RsvpForm
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        //
        // POST: Home/RsvpForm
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email response to party organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                //there was a validation error
                return View();
            }
        }
	}
}