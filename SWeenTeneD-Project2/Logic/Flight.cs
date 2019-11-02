using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic
{
    public class Flight
    {
        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightID { get; set; }

        public string Company { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int SeatAvailable { get; set; }

        public Flight() { }

        public Flight(string Fcompany, DateTime Depart, DateTime Arrive)
        {
            Company = Fcompany;
            DepartureTime = Depart;
            ArrivalTime = Arrive;
        }

        public bool ValidFlight(Flight flight)
        {
            if (Company != null && DepartureTime != null && ArrivalTime != null)
            {
                return true;
            }
            return false;
        }
    }
}
