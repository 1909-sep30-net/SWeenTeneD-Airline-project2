﻿using System;
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

        public Flight() { }

        public Flight(int Fid, string Fcompany, DateTime Depart, DateTime Arrive)
        {
            FlightID = Fid;
            Company = Fcompany;
            DepartureTime = Depart;
            ArrivalTime = Arrive;
        }

        public bool ValidFlight(Flight flight)
        {
            if(Company != null && DepartureTime != null && ArrivalTime != null)
            {
                return true;
            }
            return false;
        }
    }
}
