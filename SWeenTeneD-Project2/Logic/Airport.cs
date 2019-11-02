using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic
{
    public class Airport
    {
        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirportID { get; set; }

        //FK
        public string Name { get; set; }

        public string Location { get; set; }

        public string Weather { get; set; }

        public Airport()
        {
        }

        public Airport(string airName, string airLocate, string airWeather)
        {
            Name = airName;
            Location = airLocate;
            Weather = airWeather;
        }

        public bool ValidAirport(Airport air)
        {
            if (Name != null && Location != null && Weather != null)
                return true;
            else
                return false;
        }

        public bool AirportDelay(Airport air)
        {
            if (Weather == "Rain" | Weather == "rain")
            {
                return true;
            }
            return false;
        }
    }
}
