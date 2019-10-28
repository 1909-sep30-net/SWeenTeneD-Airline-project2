using System;
using System.Collections.Generic;
using System.Text;

namespace SWeenTeneD_Project2
{
    public class FlightLocation
    {
        //PK
        public int FLID { get; set; }
        //FK
        public int FlightID { get; set; }

        //FK
        public string ORI_DES { get; set; }

        public FlightLocation() { }

        public FlightLocation(int flyID, string Dest)
        {
            FlightID = flyID;
            ORI_DES = Dest;
        }
    }
}
