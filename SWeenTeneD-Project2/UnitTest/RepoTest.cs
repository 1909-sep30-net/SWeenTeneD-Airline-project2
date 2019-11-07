using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UnitTest
{
    public class RepoTest
    {
        Logic.Customer customer = new Logic.Customer
        {
            FirstName = "Tri",
            LastName = "Nguyen",
            Email = "123@321",
            Password = "1234"
        };

        Logic.Airport airport = new Logic.Airport
        {
            Name = "DFW",
            Location = "Arlington",
            Weather = "Sunny"
        };

        Logic.Flight flight = new Logic.Flight
        {
            Company = "AA",
            DepartureTime = new DateTime(2018, 1, 1, 0, 0, 0),
            ArrivalTime = new DateTime(2018, 1 , 2, 0, 0, 0),
            Origin = "DFW",
            Destination = "LAX",
            SeatAvailable = 3,
            Price = 299.99
        };

        Logic.FlightTicket ticket = new Logic.FlightTicket
        {
            CustomerID = 1,
            FlightID = 1,
            Checkin = false,
            Price = 299.99,
            Luggage = 1
        };

        [Fact]
        public async Task RepoCreateCustomerTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                            .UseInMemoryDatabase("CreateCustomer")
                                                            .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateCustomer(customer);

            Customer check = testContext.Customer.Select(c => c).First();

            Assert.NotNull(check);
        }

        [Fact]
        public async Task RepoReadCustomerTestAsync()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("ReadCustomer")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateCustomer(customer);

            List<Logic.Customer> customerFind = await repo.ReadCustomerList(customer);
            Logic.Customer first = customerFind.First();

            Assert.Equal(customer.FirstName, first.FirstName);
            Assert.Equal(customer.LastName, first.LastName);
            Assert.Equal(customer.Email, first.Email);
            Assert.Equal(customer.Password, first.Password);
        }

        [Fact]
        public async Task RepoUpdateCustomerTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("UpdateCustomer")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            Logic.Customer newCustomer = new Logic.Customer
            {
                CustomerID = 1,
                FirstName = "Wesley",
                LastName = "Tang",
                Email = "321@123",
                Password = "4321"
            };

            string create = await repo.CreateCustomer(customer);
            string update = await repo.UpdateCustomer(newCustomer);

            string firstName = testContext.Customer.Select(c => c.FirstName).First();
            string lastName = testContext.Customer.Select(c => c.LastName).First();
            string email = testContext.Customer.Select(c => c.Email).First();
            string password = testContext.Customer.Select(c => c.Password).First();

            Assert.Equal(newCustomer.FirstName, firstName);
            Assert.Equal(newCustomer.LastName, lastName);
            Assert.Equal(newCustomer.Email, email);
            Assert.Equal(newCustomer.Password, password);
        }

        [Fact]
        public async Task RepoDeleteCustomerTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("DeleteCustomer")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            customer.CustomerID = 1;

            string create = await repo.CreateCustomer(customer);
            string delete = await repo.DeleteCustomer(customer);

            Assert.Equal("delete success", delete);
        }

        [Fact]
        public async Task RepoCreateAirportTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("CreateAirport")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateAirport(airport);

            Airport check = testContext.Airport.Select(a => a).First();

            Assert.NotNull(check);
        }

        [Fact]
        public async Task RepoReadAirportTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("ReadAirport")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateAirport(airport);

            List<Logic.Airport> airportFind = await repo.ReadAirportList(airport);

            Assert.Equal(airport.Name, airportFind[0].Name);
            Assert.Equal(airport.Location, airportFind[0].Location);
            Assert.Equal(airport.Weather, airportFind[0].Weather);
        }

        [Fact]
        public async Task RepoUpdateAirportTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("UpdateAirport")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            Logic.Airport newAirport = new Logic.Airport
            {
                Name = "DFW",
                Location = "Dallas",
                Weather = "Cloudy"
            };

            string create = await repo.CreateAirport(airport);
            string update = await repo.UpdateAirport(newAirport);

            string location = testContext.Airport.Select(a => a.Location).First();
            string weather = testContext.Airport.Select(a => a.Weather).First();

            Assert.Equal(newAirport.Location, location);
            Assert.Equal(newAirport.Weather, weather);
        }

        [Fact]
        public async Task RepoDeleteAirportTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                                .UseInMemoryDatabase("DeleteAirport")
                                                .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateAirport(airport);
            string delete = await repo.DeleteAirport(airport);

            Assert.Equal("delete success", delete);
        }

        [Fact]
        public async Task RepoCreateFlight()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                    .UseInMemoryDatabase("CreateFlight")
                                    .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateFlight(flight);

            Flight check = testContext.Flight.Select(f => f).First();

            Assert.NotNull(check);
        }

        [Fact]
        public async Task RepoReadFlight()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                    .UseInMemoryDatabase("ReadFlight")
                                    .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateFlight(flight);

            List<Logic.Flight> check = await repo.ReadFlightList(flight);

            Assert.Equal(1, check[0].FlightID);
            Assert.Equal(flight.Company, check[0].Company);
            Assert.Equal(flight.DepartureTime, check[0].DepartureTime);
            Assert.Equal(flight.ArrivalTime, check[0].ArrivalTime);
            Assert.Equal(flight.Origin, check[0].Origin);
            Assert.Equal(flight.Destination, check[0].Destination);
            Assert.Equal(flight.SeatAvailable, check[0].SeatAvailable);
            Assert.Equal(flight.Price, check[0].Price);
        }

        [Fact]
        public async Task UpdateFlightTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                    .UseInMemoryDatabase("UpdateFlight")
                                    .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);
            string create = await repo.CreateFlight(flight);

            Logic.Flight newFlight = new Logic.Flight
            {
                FlightID = 1,
                Company = "SW",
                DepartureTime = new DateTime(2018, 12, 31, 12, 0, 0),
                ArrivalTime = new DateTime(2019, 1, 1, 5, 4, 3),
                Origin = "LAX",
                Destination = "DAL",
                SeatAvailable = 123,
                Price = 150.50
            };

            string update = await repo.UpdateFlight(newFlight);

            string company = testContext.Flight.Select(f => f.Company).First();
            DateTime depart = testContext.Flight.Select(f => f.DepartureTime).First();
            DateTime arrival = testContext.Flight.Select(f => f.ArrivalTime).First();
            string origin = testContext.Flight.Select(f => f.Origin).First();
            string des = testContext.Flight.Select(f => f.Destination).First();
            int seat = testContext.Flight.Select(f => f.SeatAvailable).First();
            double price = testContext.Flight.Select(f => f.Price).First();

            Assert.Equal(newFlight.Company, company);
            Assert.Equal(newFlight.DepartureTime, depart);
            Assert.Equal(newFlight.ArrivalTime, arrival);
            Assert.Equal(newFlight.Origin, origin);
            Assert.Equal(newFlight.Destination, des);
            Assert.Equal(newFlight.SeatAvailable, seat);
            Assert.Equal(newFlight.Price, price);
        }

        [Fact]
        public async Task DeleteFlightTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                                  .UseInMemoryDatabase("DeleteFlight")
                                  .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            flight.FlightID = 1;

            string create = await repo.CreateFlight(flight);
            string delete = await repo.DeleteFlight(flight);

            Assert.Equal("delete success", delete);
        }

        [Fact]
        public async Task CreateTicketTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                      .UseInMemoryDatabase("CreateTicket")
                      .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            string create = await repo.CreateFlightTicket(ticket);

            FlightTicket check = testContext.FlightTicket.Select(f => f).First();

            Assert.NotNull(check);
        }

        [Fact] 
        public async Task ReadTicketTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                      .UseInMemoryDatabase("ReadTicket")
                      .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            string create = await repo.CreateFlightTicket(ticket);

            List<Logic.FlightTicket> find = await repo.ReadTicketList(ticket);

            Assert.Equal(ticket.TicketID + 1, find[0].TicketID);
            Assert.Equal(ticket.CustomerID, find[0].CustomerID);
            Assert.Equal(ticket.FlightID, find[0].FlightID);
            Assert.Equal(ticket.Price, find[0].Price);
            Assert.Equal(ticket.Luggage, find[0].Luggage);
            Assert.Equal(ticket.Checkin, find[0].Checkin);
        }

        [Fact]
        public async Task UpdateTicketTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                      .UseInMemoryDatabase("UpdateTicket")
                      .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            string create = await repo.CreateFlightTicket(ticket);

            Logic.FlightTicket newTicket = new Logic.FlightTicket
            {
                TicketID = 1,
                CustomerID = 2,
                FlightID = 3,
                Checkin = true,
                Price = 123.99,
                Luggage = 2
            };

            string update = await repo.UpdateFlightTicket(newTicket);

            int cusId = testContext.FlightTicket.Select(f => f.CustomerID).First();
            int flightId = testContext.FlightTicket.Select(f => f.FlightID).First();
            bool checkIn = testContext.FlightTicket.Select(f => f.Checkin).First();
            int luggage = testContext.FlightTicket.Select(f => f.Luggage).First();
            double price = testContext.FlightTicket.Select(f => f.Price).First();

            Assert.Equal(newTicket.CustomerID, cusId);
            Assert.Equal(newTicket.FlightID, flightId);
            Assert.Equal(newTicket.Checkin, checkIn);
            Assert.Equal(newTicket.Luggage, luggage);
            Assert.Equal(newTicket.Price, price);
        }

        [Fact]
        public async Task DeleteTicketTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                      .UseInMemoryDatabase("DeleteTicket")
                      .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            string create = await repo.CreateFlightTicket(ticket);
            string createFlight = await repo.CreateFlight(flight);

            ticket.TicketID = 1;

            string delete = await repo.DeleteFlightTicket(ticket);

            Assert.Equal("delete success", delete);
        }

        [Fact]
        public async Task CheckSeatAvailableTest()
        {
            DbContextOptions<SWTDbContext> options = new DbContextOptionsBuilder<SWTDbContext>()
                        .UseInMemoryDatabase("SeatAvailable")
                        .Options;
            using SWTDbContext testContext = new SWTDbContext(options);
            Repo repo = new Repo(testContext);

            string create = await repo.CreateFlight(flight);

            string yes = await repo.CheckSeatAvailible(1, 2);
            string no = await repo.CheckSeatAvailible(1, 5);

            Assert.Equal("Yes", yes);
            Assert.Equal("No", no);
        }

    }
}
