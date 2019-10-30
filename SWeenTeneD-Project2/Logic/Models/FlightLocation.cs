using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
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

        public FlightLocation(int fLocationID, int flightID, string original)
        {
            FLID = fLocationID;
            FlightID = flightID;
            ORI_DES = original;
        }

        public bool ValidFlightLocation(FlightLocation flightLocation)
        {
            if(ORI_DES != null)
            {
                return true;
            }
            return false;
        }
    }
}
