using System;
using System.Collections.Generic;
using System.Text;

namespace SWeenTeneD_Project2
{
    public class Airport
    {
        //PK
        public int AirportID { get; set; }

        //FK
        public string Name { get; set; }

        public string Location { get; set; }

        public string Weather { get; set; }

        public int DelayTime { get; set; }

        public Airport() { }

        public Airport(string n, string loc, string skies, int delay)
        {
            Name = n;
            Location = loc;
            Weather = skies;
            DelayTime = delay;
        }
    }
}
