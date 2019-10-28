using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class FlightLocation
    {
        //PK
        public int FLID { get; set; }
        //FK
        public int FlightID { get; set; }

        //FK
        public string ORI_DES { get; set; }
    }
}
