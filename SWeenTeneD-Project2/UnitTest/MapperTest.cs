using System;
using Xunit;
using d = Database;
using l = Logic;


namespace UnitTest
{
    public class MapperTest
    {
        [Fact]
        public void MapCustomertoETest()
        {
            l.Customer customer1 = new l.Customer
            {
                CustomerID = 1,
                FirstName = "tri",
                LastName = "nguyen",
                Email = "123@321",
                Password = "1234"
            };

            d.Customer customer2 = d.Mapper.MapCustomerToE(customer1);

            Assert.Equal(customer1.CustomerID, customer2.CustomerID);
            Assert.Equal(customer1.FirstName, customer2.FirstName);
            Assert.Equal(customer1.LastName, customer2.LastName);
            Assert.Equal(customer1.Email, customer2.Email);
            Assert.Equal(customer1.Password, customer2.Password);

        }

        [Fact]
        public void MapEToCustomerTest()
        {
            d.Customer customer1 = new d.Customer
            {
                CustomerID = 1,
                FirstName = "tri",
                LastName = "nguyen",
                Email = "123@321",
                Password = "1234"
            };

            l.Customer customer2 = d.Mapper.MapEToCustomer(customer1);

            Assert.Equal(customer1.CustomerID, customer2.CustomerID);
            Assert.Equal(customer1.FirstName, customer2.FirstName);
            Assert.Equal(customer1.LastName, customer2.LastName);
            Assert.Equal(customer1.Email, customer2.Email);
            Assert.Equal(customer1.Password, customer2.Password);

        }

        [Fact]
        public void MapAirportToETest()
        {
            l.Airport airport1 = new l.Airport
            {
                Name = "DAL",
                Location = "Dallas",
                Weather = "Sunny"
            };

            d.Airport airport2 = d.Mapper.MapAirportToE(airport1);

            Assert.Equal(airport1.Name, airport2.Name);
            Assert.Equal(airport1.Location, airport2.Location);
            Assert.Equal(airport1.Weather, airport2.Weather);
        }

        [Fact]
        public void MapEToAirportTest()
        {
            d.Airport airport1 = new d.Airport
            {
                Name = "DAL",
                Location = "Dallas",
                Weather = "Sunny"
            };

            l.Airport airport2 = d.Mapper.MapEToAirport(airport1);

            Assert.Equal(airport1.Name, airport2.Name);
            Assert.Equal(airport1.Location, airport2.Location);
            Assert.Equal(airport1.Weather, airport2.Weather);
        }

        [Fact]
        public void MapFlightToETest()
        {
            l.Flight flight1 = new l.Flight
            {
                FlightID = 1,
                Company = "AA",
                DepartureTime = new DateTime(2010, 1, 1),
                ArrivalTime = new DateTime(2010, 1, 2),
                Origin = "DAL",
                Destination = "LAX",
                SeatAvailable = 123,
                Price = 299.99
            };

            d.Flight flight2 = d.Mapper.MapFlightToE(flight1);

            Assert.Equal(flight1.FlightID, flight2.FlightID);
            Assert.Equal(flight1.Company, flight2.Company);
            Assert.Equal(flight1.DepartureTime, flight2.DepartureTime);
            Assert.Equal(flight1.ArrivalTime, flight2.ArrivalTime);
            Assert.Equal(flight1.Origin, flight2.Origin);
            Assert.Equal(flight1.Destination, flight2.Destination);
            Assert.Equal(flight1.SeatAvailable, flight2.SeatAvailable);
            Assert.Equal(flight1.Price, flight2.Price);
        }

        [Fact]
        public void MapEToFlightTest()
        {
            d.Flight flight1 = new d.Flight
            {
                FlightID = 1,
                Company = "AA",
                DepartureTime = new DateTime(2010, 1, 1),
                ArrivalTime = new DateTime(2010, 1, 2),
                Origin = "DAL",
                Destination = "LAX",
                SeatAvailable = 123,
                Price = 299.99
            };

            l.Flight flight2 = d.Mapper.MapEtoFlight(flight1);

            Assert.Equal(flight1.FlightID, flight2.FlightID);
            Assert.Equal(flight1.Company, flight2.Company);
            Assert.Equal(flight1.DepartureTime, flight2.DepartureTime);
            Assert.Equal(flight1.ArrivalTime, flight2.ArrivalTime);
            Assert.Equal(flight1.Origin, flight2.Origin);
            Assert.Equal(flight1.Destination, flight2.Destination);
            Assert.Equal(flight1.SeatAvailable, flight2.SeatAvailable);
            Assert.Equal(flight1.Price, flight2.Price);
        }

        [Fact]
        public void MapTicketToETest()
        {
            l.FlightTicket ticket1 = new l.FlightTicket
            {
                TicketID = 1,
                CustomerID = 1,
                FlightID = 1,
                Checkin = true,
                Price = 123.55,
                Luggage = 2
            };

            d.FlightTicket ticket2 = d.Mapper.MapFlightTicketToE(ticket1);

            Assert.Equal(ticket1.TicketID, ticket2.FlightTicketID);
            Assert.Equal(ticket1.CustomerID, ticket2.CustomerID);
            Assert.Equal(ticket1.FlightID, ticket2.FlightID);
            Assert.Equal(ticket1.Checkin, ticket2.Checkin);
            Assert.Equal(ticket1.Price, ticket2.Price);
            Assert.Equal(ticket1.Luggage, ticket2.Luggage);

        }

        [Fact]
        public void MapEToTicketTest()
        {
            d.FlightTicket ticket1 = new d.FlightTicket
            {
                FlightTicketID = 1,
                CustomerID = 1,
                FlightID = 1,
                Checkin = true,
                Price = 123.55,
                Luggage = 2
            };

            l.FlightTicket ticket2 = d.Mapper.MapEToFlightTicket(ticket1);

            Assert.Equal(ticket1.FlightTicketID, ticket2.TicketID);
            Assert.Equal(ticket1.CustomerID, ticket2.CustomerID);
            Assert.Equal(ticket1.FlightID, ticket2.FlightID);
            Assert.Equal(ticket1.Checkin, ticket2.Checkin);
            Assert.Equal(ticket1.Price, ticket2.Price);
            Assert.Equal(ticket1.Luggage, ticket2.Luggage);

        }
    }
}
