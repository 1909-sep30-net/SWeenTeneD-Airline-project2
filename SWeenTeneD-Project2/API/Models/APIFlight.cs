using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class APIFlight
    {
        public int FlightID { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public string Origin { get; set; }

        public string Destination { get; set; }
        public int SeatAvailable { get; set; }
        public double Price { get; set; }
    }
}
