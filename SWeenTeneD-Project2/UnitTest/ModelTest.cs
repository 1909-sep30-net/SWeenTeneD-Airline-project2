using System;
using Xunit;
using Database;
using API.Models;
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
            Logic.Customer customer2 = new Logic.Customer(1, "aaa", "bbb", "123@123", "1234");

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

    public class APIModelTest
    {
        public DateTime DepartingTime1 = new DateTime(2019, 11, 20, 10, 30, 5);
        public DateTime ArrivalTime1 = new DateTime(2019, 11, 21, 9, 30, 0);

        [Fact]
        public void CustomerTest()
        {
            APICustomer customer = new APICustomer
            {
                CustomerID = 1,
                FirstName = "Tri",
                LastName = "Nguyen",
                Email = "Tri@gmail.com",
                Password = "tri1234"
            };
            Assert.Equal(1, customer.CustomerID);
            Assert.Equal("Tri", customer.FirstName);
            Assert.Equal("Nguyen", customer.LastName);
            Assert.Equal("Tri@gmail.com", customer.Email);
            Assert.Equal("tri1234", customer.Password);
        }

        [Fact]
        public void FlightTest()
        {
            APIFlight flight = new APIFlight
            {
                FlightID = 1,
                Company = "AA",
                DepartureTime = DepartingTime1,
                ArrivalTime = ArrivalTime1,
                Origin = "DEW",
                Destination = "LAX",
                SeatAvailable = 99
            };

            Assert.Equal(1, flight.FlightID);
            Assert.Equal("AA", flight.Company);
            Assert.Equal(DepartingTime1, flight.DepartureTime);
            Assert.Equal(ArrivalTime1, flight.ArrivalTime);
            Assert.Equal("DEW", flight.Origin);
            Assert.Equal("LAX", flight.Destination);
            Assert.Equal(99, flight.SeatAvailable);
        }

        [Fact]
        public void AirportTest()
        {
            APIAirport airport = new APIAirport
            {
                AirportID = 1,
                Name = "Fly",
                Location = "Dallas",
                Weather = "Sunny"
            };

            Assert.Equal(1, airport.AirportID);
            Assert.Equal("Fly", airport.Name);
            Assert.Equal("Dallas", airport.Location);
            Assert.Equal("Sunny", airport.Weather);

        }
        [Fact]
        public void FlightTicketTest()
        {
            APIFlightTicket ticket = new APIFlightTicket
            {
                TicketID = 1,
                CustomerID = 1,
                FlightID = 1,
                Price = 299.99,
                CheckIn = false,
                Luggage = 1
            };

            Assert.Equal(1, ticket.TicketID);
            Assert.Equal(1, ticket.CustomerID);
            Assert.Equal(1, ticket.FlightID);
            Assert.Equal(299.99, ticket.Price);
            Assert.False(ticket.CheckIn);
            Assert.Equal(1, ticket.Luggage);
        }
    }

    public class EntityModelTest
    {

        public DateTime DepartingTime1 = new DateTime(2019, 11, 20, 10, 30, 5);
        public DateTime ArrivalTime1 = new DateTime(2019, 11, 21, 9, 30, 0);

        [Fact]
        public void CustomerTest()
        {
            Customer customer = new Customer
            {
                CustomerID = 1,
                FirstName = "Tri",
                LastName = "Nguyen",
                Email = "Tri@gmail.com",
                Password = "tri1234"
            };
            Assert.Equal(1, customer.CustomerID);
            Assert.Equal("Tri", customer.FirstName);
            Assert.Equal("Nguyen", customer.LastName);
            Assert.Equal("Tri@gmail.com", customer.Email);
            Assert.Equal("tri1234", customer.Password);
        }

        [Fact]
        public void FlightTest()
        {
            Flight flight = new Flight
            {
                FlightID = 1,
                Company = "AA",
                DepartureTime = DepartingTime1,
                ArrivalTime = ArrivalTime1,
                Origin = "DEW",
                Destination = "LAX",
                SeatAvailable = 99
            };

            Assert.Equal(1, flight.FlightID);
            Assert.Equal("AA", flight.Company);
            Assert.Equal(DepartingTime1, flight.DepartureTime);
            Assert.Equal(ArrivalTime1, flight.ArrivalTime);
            Assert.Equal("DEW", flight.Origin);
            Assert.Equal("LAX", flight.Destination);
            Assert.Equal(99, flight.SeatAvailable);
        }

        [Fact]
        public void AirportTest()
        {
            Airport airport = new Airport
            {
                AirportID = 1,
                Name = "Fly",
                Location = "Dallas",
                Weather = "Sunny"
            };

            Assert.Equal(1, airport.AirportID);
            Assert.Equal("Fly", airport.Name);
            Assert.Equal("Dallas", airport.Location);
            Assert.Equal("Sunny", airport.Weather);
        }

        [Fact]
        public void FlightTicketTest()
        {
            FlightTicket ticket = new FlightTicket
            {
                FlightTicketID = 1,
                CustomerID = 1,
                FlightID = 1,
                Price = 299.99,
                Checkin = false,
                Luggage = 1
            };

            Assert.Equal(1, ticket.FlightTicketID);
            Assert.Equal(1, ticket.CustomerID);
            Assert.Equal(1, ticket.FlightID);
            Assert.Equal(299.99, ticket.Price);
            Assert.False(ticket.Checkin);
            Assert.Equal(1, ticket.Luggage);
        }
    }
}