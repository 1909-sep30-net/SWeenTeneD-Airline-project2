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

        public Airport(){}

        public Airport(int airportId, string airName, string airLocate, string airWeather)
        {
            AirportID = airportId;
            Name = airName;
            Location = airLocate;
            Weather = airWeather;
        }
    }
}
