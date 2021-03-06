﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = 
        {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", 
                Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", 
                Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName = "Smith", 
                Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones", 
                Role = Role.Guest}
        };

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Person person = personData.Where(p => p.PersonId == id).First();
                return View(person);
            }
            catch (InvalidOperationException e)
            {
                return HttpNotFound(e.Message);
            }
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary(
            [Bind(Prefix="HomeAddress", Include="City,Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult Address(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }
	}
}