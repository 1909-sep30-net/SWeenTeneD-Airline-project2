using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Airport
    {
        //PK
        public int AirportID { get; set; }

        //FK
        public string Name { get; set; }

        public string Location { get; set; }

        public string Weather { get; set; }

        public ICollection<Flight> Flight { get; set; }
    }
}
