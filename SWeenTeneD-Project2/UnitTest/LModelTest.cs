using System;
using Xunit;
using Database;
using API;
using Moq;

namespace UnitTest
{
    public class LModelTest
    {
        public DateTime DepartingTime1 = new DateTime(2019, 11, 20, 10, 30, 5);
        public DateTime ArrivalTime1 = new DateTime(2019, 11, 21, 9, 30, 0);
        
        [Fact]
        public void CustomerTest()
        {
            Logic.Customer customer1 = new Logic.Customer
            {
                CustomerID = 1,
                FirstName = "aaa",
                LastName = "bbb",
                Email = "123@123",
                Password = "1234"
            };
            Logic.Customer customer2 = new Logic.Customer(1,"aaa", "bbb", "123@123", "1234");

            Assert.Equal(customer1.CustomerID, customer2.CustomerID);
            Assert.Equal(customer1.FirstName, customer2.FirstName);
            Assert.Equal(customer1.LastName, customer2.LastName);
            Assert.Equal(customer1.Email, customer2.Email);
            Assert.Equal(customer1.Password, customer2.Password);
        }

        [Fact]
        public void FlightTest()
        {
            Logic.Flight flight1 = new Logic.Flight
            {
                FlightID = 1,
                Company = "AA",
                DepartureTime = DepartingTime1,
                ArrivalTime = ArrivalTime1,
                Origin = "DFW",
                Destination = "LAX",
                SeatAvailable = 99
            };
            Logic.Flight flight2 = new Logic.Flight(1, "AA", DepartingTime1, ArrivalTime1, "DFW", "LAX", 99);

            Assert.Equal(flight1.FlightID, flight2.FlightID);
            Assert.Equal(flight1.Company, flight2.Company);
            Assert.Equal(flight1.ArrivalTime, flight2.ArrivalTime);
            Assert.Equal(flight1.DepartureTime, flight2.DepartureTime);
            Assert.Equal(flight1.Origin, flight2.Origin);
            Assert.Equal(flight1.Destination, flight2.Destination);
            Assert.Equal(flight1.SeatAvailable, flight2.SeatAvailable);

        }

        [Fact]
        public void AirportTest()
        {
            Logic.Airport airport1 = new Logic.Airport
            {
                AirportID = 1,
                Name = "Sweentened",
                Location = "Dallas",
                Weather = "Sunny"
            };
            Logic.Airport airport2 = new Logic.Airport(1, "Sweentened", "Dallas", "Sunny");

            Assert.Equal(airport1.AirportID, airport2.AirportID);
            Assert.Equal(airport1.Name, airport2.Name);
            Assert.Equal(airport1.Location, airport2.Location);
            Assert.Equal(airport1.Weather, airport2.Weather);
        }

        [Fact]
        public void FlightTicketTest()
        {
            Logic.FlightTicket ticket1 = new Logic.FlightTicket
            {
                TicketID = 1,
                CustomerID = 1,
                FlightID = 1,
                Price = 258.66,
                Checkin = true,
                Luggage = 2             
            };
            Logic.FlightTicket ticket2 = new Logic.FlightTicket(1, 1, 1, 258.66, true, 2);

            Assert.Equal(ticket1.TicketID, ticket2.TicketID);
            Assert.Equal(ticket1.CustomerID, ticket2.CustomerID);
            Assert.Equal(ticket1.FlightID, ticket2.FlightID);
            Assert.Equal(ticket1.Checkin, ticket2.Checkin);
            Assert.Equal(ticket1.Luggage, ticket2.Luggage);
            Assert.Equal(ticket1.Price, ticket2.Price);
        }
    }
}
