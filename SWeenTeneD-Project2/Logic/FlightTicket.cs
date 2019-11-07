using System.ComponentModel.DataAnnotations.Schema;


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

        public FlightTicket(){}

        public FlightTicket(int ticketId, int flightID, int customerID, double price, bool checkin, int luggage)
        {
            TicketID = ticketId;
            FlightID = flightID;
            CustomerID = customerID;
            Price = price;
            Checkin = checkin;
            Luggage = luggage;
        }
    }
}
