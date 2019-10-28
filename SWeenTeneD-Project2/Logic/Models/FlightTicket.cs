using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class FlightTicket
    {
        //PK
        public int TicketID { get; set; }

        //FK
        public int FlightID { get; set; }

        //FK
        public int CustomerID { get; set; }

        public double Price { get; set; }

        public bool Checkin { get; set; }

        public int Luggage { get; set; }


    }
}
