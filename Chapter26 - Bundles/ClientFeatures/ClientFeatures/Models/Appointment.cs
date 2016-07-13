using System;
using System.ComponentModel.DataAnnotations;

namespace ClientFeatures.Models
{
    public class Appointment
    {
        [Required(ErrorMessage="Please enter your name")]
        public string ClientName { get; set; }

        public bool TermsAccepted { get; set; }
    }
}