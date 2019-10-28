using System;
using System.Collections.Generic;
using System.Text;

namespace Database
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

        public Customer Customer { get; set; }

        public Flight Flight { get; set; }
    }
}
