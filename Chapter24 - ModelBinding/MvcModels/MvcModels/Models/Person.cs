using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcModels.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name="Last Name")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }

        public bool IsApproved { get; set; }

        public Role Role { get; set; }
    }
}