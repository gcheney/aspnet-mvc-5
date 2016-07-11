using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using HelperMethods.Models.MetaData;


namespace HelperMethods.Models
{
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        [UIHint("Enum")]
        public Role Role { get; set; }

    }
}
