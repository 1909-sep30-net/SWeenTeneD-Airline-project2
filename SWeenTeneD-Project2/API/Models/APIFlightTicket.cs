using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class APIFlightTicket
    {
        public int TicketID { get; set; }

        public int FlightID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool CheckIn { get; set; }

        public int Luggage { get; set; }
    }
}
