using System;
using System.ComponentModel.DataAnnotations;

namespace WebServices.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage="Please enter the clients name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage="Please enter the reservation location")]
        public string Location { get; set; }
    }
}
