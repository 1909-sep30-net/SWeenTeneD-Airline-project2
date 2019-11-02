﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic
{
    public class FlightTicket
    {
        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketID { get; set; }

        //FK
        public int FlightID { get; set; }

        //FK
        public int CustomerID { get; set; }

        public double Price { get; set; }

        public bool Checkin { get; set; }

        public int Luggage { get; set; }

        public FlightTicket() { }

        public FlightTicket(int flightID, int customerID, double price, bool checkin, int luggage)
        {
            FlightID = flightID;
            CustomerID = customerID;
            Price = price;
            Checkin = checkin;
            Luggage = luggage;
        }

        public bool ValidFlightTicket(FlightTicket flightTicket)
        {
            if (Checkin != false)
            {
                return true;
            }
            return false;
        }
    }
}
