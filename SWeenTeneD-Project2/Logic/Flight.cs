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
        public double Price { get; set; }
        
        public Flight(){}

        public Flight(int flightId, string company, DateTime depart
                     ,DateTime arrive, string origin, string des, int seat, double price)
        {
            FlightID = flightId;
            Company = company;
            DepartureTime = depart;
            ArrivalTime = arrive;
            Origin = origin;
            Destination = des;
            SeatAvailable = seat;
            Price = price;
        }
    }
}
