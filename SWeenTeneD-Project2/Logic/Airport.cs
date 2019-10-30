﻿using System;
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