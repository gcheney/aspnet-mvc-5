using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        //Non- Auto property
        private string _name;

        public string Name
        {
            get { return _name; }
            set {  _name = value;}
        }

        //AutoProperties
        public int ProductID { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}