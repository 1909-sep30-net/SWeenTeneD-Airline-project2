using log = Logic;
using System;
using Xunit;
using Database;
using API;
using Moq;

namespace UnitTest
{
    public class UnitTest
    {
        //public UnitTest(IRepo repository)
        //{
        //    iRepo = repository;
        //}

        public DateTime DepartingTime = new DateTime(2019, 11, 20, 10, 30, 5);
        public DateTime ArrivalTime = new DateTime(2019, 11, 21, 9, 30, 0);
        
        [Fact]
        public void TestMock()
        {
            //arrange
            var repo = new Mock<log.IRepo>();
            var a = new log.Customer("tri", "nguyen", "Tri@Broke.Everything", "TriBrokeEverything");
            repo.Setup(x => x.CreateCustomer(a));
            repo.Object.ReadCustomerList(a);
        }


        [Theory]
        [InlineData("JFK Airport", "Arlington", "Rain")]
        public void CheckTrueValidAirport(string airName, string airLocate, string airWeather)
        {
            log.Airport airport = new log.Airport(airName, airLocate, airWeather);

            Assert.True(airport.ValidAirport(airport), "Aiport is valid");
        }

        [Theory]
        [InlineData(null, "Arlington", null)]
        public void CheckFalseValidAirport(string airName, string airLocate, string airWeather)
        {
            log.Airport airport = new log.Airport(airName, airLocate, airWeather);

            Assert.False(airport.ValidAirport(airport), "Aiport is NOT valid");
        }

        [Theory]
        [InlineData("JFK Airport", "Arlington", "Rain")]
        public void CheckTrueDelay(string airName, string airLocate, string airWeather)
        {
            log.Airport airport = new log.Airport(airName, airLocate, airWeather);

            Assert.True(airport.AirportDelay(airport), "Sorry the weather is bad.  There is a delay!");
        }

        [Theory]
        [InlineData("JFK Airport", "Arlington", "Sunny")]
        public void CheckFalseDelay(string airName, string airLocate, string airWeather)
        {
            log.Airport airport = new log.Airport(airName, airLocate, airWeather);

            Assert.False(airport.AirportDelay(airport), "Weather is great.  No delay!");
        }


        //May not work due to the constraints of DateTime
        [Theory]
        [InlineData("Korean Air", null, null)]
        public void CheckFalseValidFlight(string flightCom, DateTime flightDepart, DateTime flightArrive)
        {
            log.Flight flight = new log.Flight(flightCom, flightDepart, flightArrive);

            Assert.False(flight.ValidFlight(flight), "Invalid flight!");
        }

        //TicketID = ticketID;
        //    FlightID = flightID;
        //    CustomerID = customerID;
        //    Price = price;
        //    Checkin = checkin;
        //    Luggage = luggage;

        [Theory]
        [InlineData(2, 2, 150, true, 1)]
        public void CheckTrueValidFlightTicket(int flightID, int customerID, int price, bool checkin, int luggage)
        {
            log.FlightTicket flightTicket = new log.FlightTicket(flightID, customerID, price, checkin, luggage);

            Assert.True(flightTicket.ValidFlightTicket(flightTicket), "Valid flight ticket!  Have a nice flight!");
        }

        [Theory]
        [InlineData(2, 2, 175, false, 1)]
        public void CheckFalseValidFlightTicket(int flightID, int customerID, int price, bool checkin, int luggage)
        {
            log.FlightTicket flightTicket = new log.FlightTicket(flightID, customerID, price, checkin, luggage);

            Assert.False(flightTicket.ValidFlightTicket(flightTicket), "Invalid flight ticket!  You have not checked in!");
        }

        [Theory]
        [InlineData("Tri", "Nguyen", "Tri@Broke.Everything", "TriBrokeEverything")]
        public void CheckTrueValidCust(string fname, string lname, string email, string password)
        {
            log.Customer a = new log.Customer(fname, lname, email, password);

            Assert.True(a.ValidCust(a), "Customer Valid");
        }

        [Theory]
        [InlineData("Tri", null, "Tri@Broke.Everything", "TriBrokeEverything")]
        public void CheckFalseValidCust(string fname, string lname, string email, string password)
        {
            log.Customer a = new log.Customer(fname, lname, email, password);

            Assert.False(a.ValidCust(a), "Customer Not Valid");
        }
    }
}