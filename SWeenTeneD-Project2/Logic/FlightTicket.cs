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

        public double Price { get; set; }

        public bool Checkin { get; set; }

        public int Luggage { get; set; }

        public FlightTicket() { }

        public FlightTicket(int ticketID, int flightID, int customerID, double price, bool checkin, int luggage)
        {
            TicketID = ticketID;
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
