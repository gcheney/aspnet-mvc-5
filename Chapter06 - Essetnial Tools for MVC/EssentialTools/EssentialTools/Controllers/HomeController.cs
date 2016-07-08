using System;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports",Price = 275M},
            new Product {Name = "LifeJacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "SoccerBall", Category = "Soccer", Price = 19.5M},
            new Product {Name = "Cornerflag", Category = "Soccer", Price = 34.95M}
        };

        public HomeController(IValueCalculator calc)
        {
            this.calc = calc;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
	}
}