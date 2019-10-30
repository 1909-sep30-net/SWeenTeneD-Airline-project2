using System;
using System.Collections.Generic;
using System.Text;

namespace SWeenTeneD_Project2
{
    public class FlightTicket
    {
        //PK
        public int TicketID { get; set; }

        //FK
        public int FlightID { get; set; }

        //FK
        public int CustomerID { get; set; }

        public decimal Price { get; set; }

        public bool Checkin { get; set; }

        public int Luggage { get; set; }

        public FlightTicket() { }

        public FlightTicket(int flyID, int custID, decimal cost, bool check, int baggins)
        {
            FlightID = flyID;
            CustomerID = custID;
            Price = cost;
            Checkin = check;
            Luggage = baggins;
        }
    }
}
