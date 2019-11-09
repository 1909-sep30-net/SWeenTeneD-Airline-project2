using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public interface IRepo
    {
        /// <summary>
        /// Function to create single customer in the database
        /// request passing a logic model: Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>string</returns>
        public Task<string> CreateCustomer(Customer customer);

        /// <summary>
        /// Function to read list of customer from database
        /// reauest passing a logic model: Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>List of Customer</returns>
        public Task<List<Customer>> ReadCustomerList(Customer customer);

        /// <summary>
        /// Function to update single customer in the database
        /// request passing a logic model: Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>string</returns>
        public Task<string> UpdateCustomer(Customer customer);

        /// <summary>
        /// Function to delete a single customer in the database
        /// request passing a logic model: Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>string</returns>
        public Task<string> DeleteCustomer(Customer customer);


        /// <summary>
        /// Function to create single Flight in the database
        /// request a logic model: Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>string</returns>
        public Task<string> CreateFlight(Flight flight);

        /// <summary>
        /// Function to read a list of Flights in the datbase
        /// request a logic model: Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>list of Flight</returns>
        public Task<List<Flight>> ReadFlightList(Flight flight);

        /// <summary>
        /// Function to update single flight in the database
        /// request a logic model: Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>string</returns>
        public Task<string> UpdateFlight(Flight flight);

        /// <summary>
        /// Function to delete a single flight in the database
        /// request a logic model: Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>string</returns>
        public Task<string> DeleteFlight(Flight flight);


        /// <summary>
        /// Function to create single new airport in the database
        /// request a logic model: Airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns>string</returns>
        public Task<string> CreateAirport(Airport airport);

        /// <summary>
        /// Function to read a list of airport in the database,
        /// request passing a logic model: Airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns>list of Airport</returns>
        public Task<List<Airport>> ReadAirportList(Airport airport);

        /// <summary>
        /// Function to update single airport in the database,
        /// request passing a logic model: Airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns>string</returns>
        public Task<string> UpdateAirport(Airport airport);

        /// <summary>
        /// Function to delete single airport in the database,
        /// request passing a logic model: Airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns>string</returns>
        public Task<string> DeleteAirport(Airport airport);


        /// <summary>
        /// Function to create single new Ticket in the database,
        /// request passing a logic model FlightTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>string</returns>
        public Task<string> CreateFlightTicket(FlightTicket ticket);

        /// <summary>
        /// Function to read list of ticket in the database,
        /// request passing a logic model: FlightTicket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>list of FlightTicket</returns>
        public Task<List<FlightTicket>> ReadTicketList(FlightTicket ticket);

        /// <summary>
        /// Function to update single ticket in the database,
        /// request passing a logic model: FlightTicket
        /// </summary>
        /// <param name="Airport"></param>
        /// <returns>string</returns>
        public Task<string> UpdateFlightTicket(FlightTicket ticket);

        /// <summary>
        /// Function to delete single ticket in the database,
        /// request passing a logic model: FlightTicket
        /// Also the SeatAvailable in Flight will be updated.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>string</returns>
        public Task<string> DeleteFlightTicket(FlightTicket ticket);


        /// <summary>
        /// Function to check and update SeatAvailable in Flight.
        /// if seat is not enough, return resection string. If 
        /// it's enough, update the SeatAvailable in Database.Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="numTickets"></param>
        /// <returns>string</returns>
        public Task<string> CheckSeatAvailible(int flight, int numTickets);

        /// <summary>
        /// Returns max index of TicketID
        /// </summary>
        /// <returns></returns>
        public Task<int> GetTicketId();

        /// <summary>
        /// Returns max index of FlightID
        /// </summary>
        /// <returns></returns>
        public Task<int> GetFlightId();

        /// <summary>
        /// Returns max index of CustomerID
        /// </summary>
        /// <returns></returns>
        public Task<int> GetCustomerId();

        public Task<string> GetAirPortName(string name);
    }
}
