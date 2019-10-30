using Logic.Models;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        public DateTime DepartingTime = new DateTime(2019, 11, 20, 10, 30, 5);
        public DateTime ArrivalTime = new DateTime(2019, 11, 21, 9, 30, 0);


        [Theory]
        [InlineData(1,"JFK Airport", "Arlington", "Rain")]
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

        [Theory]
        [InlineData(1, "JFK Airport", "Arlington", "Rain")]
        public void CheckTrueDelay(int airID, string airName, string airLocate, string airWeather)
        {
            Airport airport = new Airport(airID, airName, airLocate, airWeather);

            Assert.True(airport.AirportDelay(airport), "Sorry the weather is bad.  There is a delay!");
        }

        [Theory]
        [InlineData(1, "JFK Airport", "Arlington", "Sunny")]
        public void CheckFalseDelay(int airID, string airName, string airLocate, string airWeather)
        {
            Airport airport = new Airport(airID, airName, airLocate, airWeather);

            Assert.False(airport.AirportDelay(airport), "Weather is great.  No delay!");
        }


        //May not work due to the constraints of DateTime
        [Theory]
        [InlineData(2, "Korean Air", null, null)]
        public void CheckFalseValidFlight(int flightID, string flightCom, DateTime flightDepart, DateTime flightArrive)
        {
            Flight flight = new Flight(flightID, flightCom, flightDepart, flightArrive);

            Assert.False(flight.ValidFlight(flight), "Invalid flight!");
        }

        [Theory]
        [InlineData(1, 1, "Guangzhou")]
        public void CheckTrueValidFlightLocation(int flightLocationID, int flightID, string original)
        {
            FlightLocation flightLocation = new FlightLocation(flightLocationID, flightID, original);

            Assert.True(flightLocation.ValidFlightLocation(flightLocation), "Everything checks out for the flight location!  Valid!");
        }

        [Theory]
        [InlineData(1, 1, null)]
        public void CheckFalseValidFlightLocation(int flightLocationID, int flightID, string original)
        {
            FlightLocation flightLocation = new FlightLocation(flightLocationID, flightID, original);

            Assert.False(flightLocation.ValidFlightLocation(flightLocation), "Invalid flight location.  Try again!");
        }

        //TicketID = ticketID;
        //    FlightID = flightID;
        //    CustomerID = customerID;
        //    Price = price;
        //    Checkin = checkin;
        //    Luggage = luggage;

        [Theory]
        [InlineData(2, 2, 2, 150, true, 1)]
        public void CheckTrueValidFlightTicket(int ticketID, int flightID, int customerID, int price, bool checkin, int luggage)
        {
            FlightTicket flightTicket = new FlightTicket(ticketID, flightID, customerID, price, checkin, luggage);

            Assert.True(flightTicket.ValidFlightTicket(flightTicket), "Valid flight ticket!  Have a nice flight!");
        }

        [Theory]
        [InlineData(2, 2, 2, 175, false, 1)]
        public void CheckFalseValidFlightTicket(int ticketID, int flightID, int customerID, int price, bool checkin, int luggage)
        {
            FlightTicket flightTicket = new FlightTicket(ticketID, flightID, customerID, price, checkin, luggage);

            Assert.False(flightTicket.ValidFlightTicket(flightTicket), "Invalid flight ticket!  You have not checked in!");
        }


    }
}
