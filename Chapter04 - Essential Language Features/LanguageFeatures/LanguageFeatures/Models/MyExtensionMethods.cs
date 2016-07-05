using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (var prod in productEnum)
            {
                total += prod.Price;
            }

            return total;
        }

        /// <summary>
        /// Use yield keyword to filter products by a parameter
        /// </summary>
        /// <param name="productEnum"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static IEnumerable<Product> FilterByCategory(
                this IEnumerable<Product> productEnum, string category)
        {
            foreach (var prod in productEnum)
            {
                if (prod.Category == category)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, 
                Func<Product, bool> selector) 
        {
            foreach (var prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}