using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AutoProperty()
        {
            //Create new product 
            var prod = new Product {Name = "Kayak"};

            //get the property
            string prodName = prod.Name;

            //generate the view
            return View("Result", 
                (object)String.Format("Product Name: {0}", prodName));
        }

        public ViewResult CreateProduct()
        {
            //Create a new Product with Object Initializer
            var myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Price = 275M,
                Category = "Watersports",
                Description = "A boat for one person"
            };

            //generate the view
            return View("Result",
                (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            IList<int> intList = new List<int> { 10, 20, 30, 40 };

            //using the 'var' keyword to reduce duplication
            var myDict = new Dictionary<string, int> 
            {
                {"apple", 10}, {"orange", 20}, {"plum", 30}
            };

            string fruit = stringArray[1];
            return View("Result", 
                (object)String.Format("{0} cost ${1}",fruit, myDict[fruit]));
        }

        public ViewResult UseExtension()
        {
            //Create and populate the Shopping cart
            var cart = new ShoppingCart 
            {
                Products = new List<Product> 
                {
                    new Product { Name = "Kayak", Price = 275M },
                    new Product { Name = "LifeJacket", Price = 48.95M },
                    new Product { Name = "Soccer Ball", Price = 19.50M },
                    new Product { Name = "Football", Price = 34.95M }
                }
            };

            //get the total
            decimal cartTotal = cart.TotalPrices();

            return View("Result",
                (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            //SHopping cart using interface
            IEnumerable<Product> products = new ShoppingCart 
            {
                Products = new List<Product> 
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "LifeJacket", Price = 48.95M},
                    new Product {Name = "Soccer Ball", Price = 19.50M},
                    new Product {Name = "Football", Price = 34.95M}
                }
            };

            //create and populate an array of Product Objects
            Product[] prodArray = {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "LifeJacket", Price = 48.95M},
                    new Product {Name = "Soccer Ball", Price = 19.50M},
                    new Product {Name = "Football", Price = 34.95M}
            };

            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = prodArray.TotalPrices();

            return View("Result",
                (object)String.Format("Cart Total: {0}, Array Total: {1}",
                    cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            //SHopping cart using interface
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> 
                {
                    new Product {Name = "Kayak", Price = 275M, 
                        Category="Water"},
                    new Product {Name = "LifeJacket", Price = 48.95M, 
                        Category="Water"},
                    new Product {Name = "Soccer Ball", Price = 19.50M, 
                        Category="Soccer"},
                    new Product {Name = "Goal", Price = 34.95M, 
                        Category="Soccer"},
                    new Product {Name = "Football", Price = 34.95M, 
                        Category="Football"}
                }
            };

            decimal total = 0;
            foreach (var prod in products.FilterByCategory("Soccer"))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult UseLambdaFilter()
        {
            //Shopping cart using interface
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> 
                {
                    new Product {Name = "Kayak", Price = 275M, 
                        Category="Water"},
                    new Product {Name = "LifeJacket", Price = 48.95M, 
                        Category="Water"},
                    new Product {Name = "Soccer Ball", Price = 19.50M, 
                        Category="Soccer"},
                    new Product {Name = "Goal", Price = 34.95M, 
                        Category="Soccer"},
                    new Product {Name = "Football", Price = 34.95M, 
                        Category="Football"}
                }
            };

            //using a delegate
            Func<Product, bool> delegateFilter = delegate(Product prod)
            {
                return prod.Category == "Soccer";
            };

            //Using a delegate/lambda expression
            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            //using a pure lambda expression in place of delegate
            decimal total = products
                            .Filter(prod => prod.Category == "Soccer" && prod.Price > 20)
                            .Sum(prod => prod.Price);//added LINQ query

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult CreateAnonArray()
        {
            //anonymous array and objects
            var oddsAndEnds = new [] {
                new {Name = "MVC", Category = "Pattern"},
                new { Name = "ASP.NET", Category = "Framework"},
                new { Name = "CSharp", Category = "Programming Language"}
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds) 
            {
                result.Append(item.Name + " = " + item.Category).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProducts()
        {
            //create and populate an array of Product Objects
            Product[] products = 
            {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "LifeJacket", Price = 48.95M},
                    new Product {Name = "Soccer Ball", Price = 19.50M},
                    new Product {Name = "Football", Price = 34.95M}
            };

            //Query Syntax
            var foundProducts = from match in products
                                orderby match.Price descending
                                select new { match.Name, match.Price };

            //dot syntax
            foundProducts = products.OrderByDescending(p => p.Price)
                                    .Take(3)
                                    .Select(p => new { p.Name, p.Price });

            //Not deffered - does not wait for enumeration
            decimal results = products.Sum(p => p.Price);

            //Certain operations are deferred until enumeration
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            //create the result
            StringBuilder result = new StringBuilder();

            //Enumeration
            foreach (var prod in foundProducts)
            {
                result.AppendFormat("Price: {0} ", prod.Price);
            }

            return View("Result", (object)String.Format(
                "{0} \nSum: {1:c}", result.ToString(), results));
        }
	}
}