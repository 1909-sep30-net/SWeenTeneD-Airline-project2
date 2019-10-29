using Logic.Models;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1,"JFK Airport", "Arlington", "Rainy")]
        public void CheckTrueValidAirport(int airID, string airName, string airLocate, string airWeather)
        {
            Airport airport = new Airport(airID, airName, airLocate, airWeather);

            Assert.True(airport.ValidAirport(airport), "Aiport is valid");
        }

        [Theory]
        [InlineData(1, null, "Arlington", null)]
        public void CheckFalseValidAirport(int airID, string airName, string airLocate, string airWeather)
        {
            Airport airport = new Airport(airID, airName, airLocate, airWeather);

            Assert.False(airport.ValidAirport(airport), "Aiport is NOT valid");
        }
    }
}
