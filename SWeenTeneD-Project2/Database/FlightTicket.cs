using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class FlightTicket
    {
        //PK
        public int FlightTicketID { get; set; }

        //FK
        [ForeignKey("FlightID")]
        public int FlightID { get; set; }

        //FK
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

        public double Price { get; set; }

        public bool Checkin { get; set; }

        public int Luggage { get; set; }

        public Customer Customer { get; set; }

        public Flight Flight { get; set; }
    }
}
