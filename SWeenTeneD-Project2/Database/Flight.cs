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

        public virtual ICollection<FlightLocation> FlightLocation { get; set; }

        public virtual ICollection<FlightTicket> FlightTicket { get; set; }
    }
}
