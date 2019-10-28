using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Flight
    {
        //PK

        public int FlightID { get; set; }

        public string Company { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
