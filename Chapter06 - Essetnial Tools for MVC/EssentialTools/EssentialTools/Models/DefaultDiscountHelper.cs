using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        /// <summary>
        /// Provides a ten percent discount
        /// </summary>
        /// <param name="total">The toal of the purchase</param>
        /// <returns>The total value after the 
        /// discount has been applied</returns>
        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize / 100m * total));
        }
    }
}