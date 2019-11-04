using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Flight
    {
        //PK
        public int FlightID { get; set; }

        public string Company { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public int SeatAvailable { get; set; }
        public double Price { get; set; }

        public Airport Airport { get; set; }

        public virtual ICollection<FlightTicket> FlightTicket { get; set; }
    }
}
