using System;
using System.Collections.Generic;
using System.Text;

namespace SWeenTeneD_Project2
{
    public class Flight
    {
        //PK
        public int FlightID { get; set; }

        public string Company { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Flight() { }

        public Flight(string comp, DateTime leave, DateTime arrive)
        {
            Company = comp;
            DepartureTime = leave;
            ArrivalTime = arrive;
        }
    }
}
