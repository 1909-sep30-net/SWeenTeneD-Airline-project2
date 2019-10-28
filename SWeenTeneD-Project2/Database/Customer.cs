using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    //Business Customer
    public class Customer
    {
        //PK
        public int CustomerID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<FlightTicket> FlightTicket { get; set; }
    }
}
