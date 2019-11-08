
namespace Database
{
    public static class Mapper
    {
        //Map Entity --> Business
        public static Logic.Airport MapEToAirport(Airport EAirport)
        {
            return new Logic.Airport
            {
                Name = EAirport.Name,
                Location = EAirport.Location,
                Weather = EAirport.Weather,
            };
        }

        //Map Business --> Entity
        public static Airport MapAirportToE(Logic.Airport BAirport)
        {
            return new Airport
            {
                Name = BAirport.Name,
                Location = BAirport.Location,
                Weather = BAirport.Weather,
            };
        }

        //Map Entity --> Business
        public static Logic.Customer MapEToCustomer(Customer ECustomer)
        {
            return new Logic.Customer
            {
                CustomerID = ECustomer.CustomerID,
                FirstName = ECustomer.FirstName,
                LastName = ECustomer.LastName,
                Email = ECustomer.Email,
                Password = ECustomer.Password
            };
        }
        //Map Business --> Entity
        public static Customer MapCustomerToE(Logic.Customer BCustomer)
        {
            return new Customer
            {
                CustomerID = BCustomer.CustomerID,
                FirstName = BCustomer.FirstName,
                LastName = BCustomer.LastName,
                Email = BCustomer.Email,
                Password = BCustomer.Password
            };
        }

        //Map Entity --> Business
        public static Logic.Flight MapEtoFlight(Flight EFlight)
        {
            return new Logic.Flight
            {
                FlightID = EFlight.FlightID,
                Company = EFlight.Company,
                DepartureTime = EFlight.DepartureTime,
                ArrivalTime = EFlight.ArrivalTime,
				Origin = EFlight.Origin,
				Destination = EFlight.Destination,
				Price = EFlight.Price,
				SeatAvailable = EFlight.SeatAvailable
            };
        }
        //Map Business --> Entity
        public static Flight MapFlightToE(Logic.Flight BFlight)
        {
            return new Flight
            {
                FlightID = BFlight.FlightID,
                Company = BFlight.Company,
                DepartureTime = BFlight.DepartureTime,
                ArrivalTime = BFlight.ArrivalTime,
				Origin = BFlight.Origin,
				Destination = BFlight.Destination,
				Price = BFlight.Price,
				SeatAvailable = BFlight.SeatAvailable
            };
        }

        //Map Entity --> Business
        public static Logic.FlightTicket MapEToFlightTicket(FlightTicket EFlightTicket)
        {
            return new Logic.FlightTicket
            {
                TicketID = EFlightTicket.FlightTicketID,
                FlightID = EFlightTicket.FlightID,
                CustomerID = EFlightTicket.CustomerID,
                Price = EFlightTicket.Price,
                Checkin = EFlightTicket.Checkin,
                Luggage = EFlightTicket.Luggage
            };
        }

        //Map Business --> Entity
        public static FlightTicket MapFlightTicketToE(Logic.FlightTicket BFlightTicket)
        {
            return new FlightTicket
            {
                FlightTicketID = BFlightTicket.TicketID,
                FlightID = BFlightTicket.FlightID,
                CustomerID = BFlightTicket.CustomerID,
                Price = BFlightTicket.Price,
                Checkin = BFlightTicket.Checkin,
                Luggage = BFlightTicket.Luggage
            };
        }

        public static Manager MapManagerToE(Logic.Manager manager)
        {
            return new Manager
            {
                ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Email = manager.Email,
                Password = manager.Password
            };
        }

        public static Logic.Manager MapEToManager(Manager manager)
        {
            return new Logic.Manager
            {
                ManagerId = manager.ManagerId,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Email = manager.Email,
                Password = manager.Password
            };
        }

    }
}
