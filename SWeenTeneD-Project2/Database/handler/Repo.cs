using System.Collections.Generic;
using System.Linq;
using Logic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
//IE: IEnumerable object
//IQ: IQueryable object
// E: Entity Model
// L: Logic Model
//DB: DbContext

namespace Database
{
    public class Repo : IRepo
    {
        private static SWTDbContext dbcontext;
        
        public Repo ( SWTDbContext dbContext )
        {
            dbcontext = dbContext;
        }

        public async Task<string> CreateCustomer(Logic.Customer customer)
        {
            Customer e_customer = Mapper.MapCustomerToE(customer);
            dbcontext.Add(e_customer);
            await dbcontext.SaveChangesAsync();
            //logger.Info();

            return $"{customer.FirstName} {customer.LastName} is created.";
        }


        public async Task<List<Logic.Customer>> ReadCustomerList(Logic.Customer customer)
        {
            if ( customer == null )
            {
                List<Customer> customerList = await dbcontext.Customer.ToListAsync();

                return customerList.Select(Mapper.MapEToCustomer).ToList();
            }

            if (customer.CustomerID <= 0)
            {
                IQueryable<Customer> q_cusotmer = dbcontext.Customer;

                if (customer.FirstName != null)
                {
                    q_cusotmer = q_cusotmer.Where(c => c.FirstName == customer.FirstName)
                                        .AsNoTracking();
                }
                if (customer.LastName != null)
                {
                    q_cusotmer = q_cusotmer.Where(c => c.LastName == customer.LastName)
                        .AsNoTracking();
                }
                if (customer.Email != null)
                {
                    q_cusotmer = q_cusotmer.Where(c => c.Email == customer.Email)
                        .AsNoTracking();
                }
                if (customer.Password != null)
                {
                    q_cusotmer = q_cusotmer.Where(c => c.Password == customer.Password)
                        .AsNoTracking();
                }

                List<Customer> customerFind = await q_cusotmer.ToListAsync();
                List<Logic.Customer> resultCustomer = customerFind.Select(Mapper.MapEToCustomer).ToList();
                if (resultCustomer.ToList().Count < 1)
                {
                    //logger.Warn();
                    return null;
                }
                return resultCustomer;
            }
            else
            {
                List<Logic.Customer> customerFind = new List<Logic.Customer>();
                customerFind.Add(Mapper.MapEToCustomer(await dbcontext.Customer.FindAsync(customer.CustomerID)));
                
                //logger.Info();
                return customerFind;
            }
            
        }

        public async Task<string> UpdateCustomer(Logic.Customer customer)
          {
            Customer e_customer = await dbcontext.Customer.FindAsync(customer.CustomerID);

            if (e_customer == null)
            {
                return "no such customer";
            }

            if (customer.LastName != null) {
                e_customer.LastName = customer.LastName;
            }
            if (customer.FirstName != null)
            {
                e_customer.FirstName = customer.FirstName;
            }
            if (customer.Email != null)
            {
                e_customer.Email = customer.Email;
            }
            if (customer.Password != null)
            {
                e_customer.Password = customer.Password;
            }
            
            await dbcontext.SaveChangesAsync();
            //logger.Info();

            return "update success";
          }


        public async Task<string> DeleteCustomer(Logic.Customer customer)
        {
            Customer e_customer = await dbcontext.Customer.FindAsync(customer.CustomerID);
            if (e_customer == null)
            {
                //logger.Warn("customer not found")
                return "no such customer";
            }

            dbcontext.Remove(dbcontext.Customer.Find(customer.CustomerID));
            dbcontext.SaveChanges();

            //logger.info();
            return "delete success";
        }

        public async Task<string> CreateFlight(Logic.Flight flight)
        {

            Flight e_flight = Mapper.MapFlightToE(flight);
            dbcontext.Add(e_flight);
            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "New Flight Created!";
        }

        public async Task<List<Logic.Flight>> ReadFlightList(Logic.Flight flight)
        {
            int maxId = await GetFlightId();
            if ( flight == null )
            {
                List<Flight> flightFind = await dbcontext.Flight.ToListAsync();

                return flightFind.Select(Mapper.MapEtoFlight).ToList();
            }
            if (flight.FlightID <= 0)
            {
                IQueryable<Flight> e_flight = dbcontext.Flight.Select(f => f);

                if(flight.Company != null)
                {
                    e_flight = e_flight.Where(f => f.Company == flight.Company)
                                               .AsNoTracking();
                }
                if(flight.DepartureTime != null)
                {
                    e_flight = e_flight.Where(f => f.DepartureTime == flight.DepartureTime)
                                               .AsNoTracking();
                }
                if(flight.ArrivalTime != null)
                {
                    e_flight = e_flight.Where(f => f.ArrivalTime == flight.ArrivalTime)
                                               .AsNoTracking();
                }
                if(flight.Origin != null)
                {
                    e_flight = e_flight.Where(e => e.Origin == flight.Origin)
                                            .AsNoTracking();
                }
                if(flight.Destination != null)
                {
                    e_flight = e_flight.Where(e => e.Destination == flight.Destination)
                                            .AsNoTracking();

                }
                if(flight.SeatAvailable > 0)
                {
                    e_flight = e_flight.Where(f => f.SeatAvailable == flight.SeatAvailable)
                                            .AsNoTracking();
                }
                if(flight.Price > 0)
                {
                    e_flight = e_flight.Where(f => f.Price == flight.Price)
                                            .AsNoTracking();
                }

                List<Flight> flightFind = await e_flight.ToListAsync();
                List<Logic.Flight> resultFlight = flightFind.Select(Mapper.MapEtoFlight).ToList();
                if (resultFlight.Count < 1 )
                {
                    //logger.Warn();
                    return null;                  
                }
                return resultFlight;
            }
            else 
            {
                List<Logic.Flight> flightFind = new List<Logic.Flight>
                {
                    Mapper.MapEtoFlight(await dbcontext.Flight.FindAsync(flight.FlightID))
                };
                //logger.Info();
                return flightFind;
            }
        }

        public async Task<string> UpdateFlight(Logic.Flight flight)
        {
            Flight e_flight = await dbcontext.Flight.FindAsync(flight.FlightID);

            if (e_flight == null)
            {
                //logger.Warn("Flight not Found")
                return "no such Flight";
            }

            if (flight.Company != null)
            {
                e_flight.Company = flight.Company;
            }
            if (flight.Origin != null)
            {
                e_flight.Origin = flight.Origin;
            }
            if (flight.Destination != null)
            {
                e_flight.Destination = flight.Destination;
            }
            if (flight.DepartureTime != null)
            {
                e_flight.DepartureTime = flight.DepartureTime;
            }
            if (flight.ArrivalTime != null)
            {
                e_flight.ArrivalTime = flight.ArrivalTime;
            }
            if (flight.SeatAvailable > 0)
            {
                e_flight.SeatAvailable = flight.SeatAvailable;
            }
            if (flight.Price > 0)
            {
                e_flight.Price = flight.Price;
            }

            await dbcontext.SaveChangesAsync();
            //logger.Info();

            return "update success";
        }


        public async Task<string> DeleteFlight(Logic.Flight flight)
        {
            Flight e_flight = await dbcontext.Flight.FindAsync(flight.FlightID);
            if (e_flight == null)
            {
                //logger.Warn("Flight not found.")
                return "no such customer";
            }

            dbcontext.Remove(dbcontext.Flight.Find(flight.FlightID));
            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "delete success";
        }

        public async Task<string> CreateAirport(Logic.Airport airport)
        {
            Airport e_airport = Mapper.MapAirportToE(airport);
            dbcontext.Add(e_airport);
            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "New Flight Created!";
        }


        public async Task<List<Logic.Airport>> ReadAirportList(Logic.Airport airport)
        {
            if (airport ==  null)
            {
                List<Airport> airportFind = await dbcontext.Airport.ToListAsync();

                return airportFind.Select(Mapper.MapEToAirport).ToList();
            }
            IQueryable<Airport> e_airport = dbcontext.Airport.Select(a => a);

            if (airport.Name != null)
            {
                e_airport = e_airport.Where(a => a.Name == airport.Name)
                                           .AsNoTracking();
            }
            if (airport.Location != null)
            {
                e_airport = e_airport.Where(f => f.Location == airport.Location)
                                           .AsNoTracking();
            }
            if (airport.Weather != null)
            {
                e_airport = e_airport.Where(f => f.Weather == airport.Weather)
                                           .AsNoTracking();
            }

            List<Airport> airportFind2 = await e_airport.ToListAsync();
            List<Logic.Airport> resultAirport = airportFind2.Select(Mapper.MapEToAirport).ToList();
            if (resultAirport.Count < 1)
            {
                //logger.Warn();
                return null;
            }
            return resultAirport;
        }

        public async Task<string> UpdateAirport(Logic.Airport airport)
        {
            Airport e_airport = await dbcontext.Airport.FindAsync(airport.Name);

            if (e_airport == null)
            {
                //logger.Warn("airport not Found")
                return "no such airport";
            }

            if (airport.Name != null)
            {
                e_airport.Name = airport.Name;
            }
            if (airport.Location != null)
            {
                e_airport.Location = airport.Location;
            }
            if (airport.Weather != null)
            {
                e_airport.Weather = airport.Weather;
            }

            await dbcontext.SaveChangesAsync();
            //logger.Info();

            return "update success";
        }

        public async Task<string> DeleteAirport(Logic.Airport airport)
        {
            Airport e_Airport = await dbcontext.Airport.FindAsync(airport.Name);
            if (e_Airport == null)
            {
                //logger.Warn("Airport not found.")
                return "no such customer";
            }
            dbcontext.Remove(dbcontext.Airport.Find(airport.Name));
            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "delete success";
        }

        public async Task<string> CreateFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = Mapper.MapFlightTicketToE(ticket);
            dbcontext.Add(e_ticket);
            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "New Ticket Created!";
        }

        public async Task<List<Logic.FlightTicket>> ReadTicketList(Logic.FlightTicket ticket)
        {
            if (ticket == null)
            {
                List<FlightTicket> ticketFind = await dbcontext.FlightTicket.ToListAsync();

                return ticketFind.Select(Mapper.MapEToFlightTicket).ToList();
            }
            if (ticket.TicketID <= 0)
            {
                IQueryable<FlightTicket> e_ticket = dbcontext.FlightTicket.Select(t => t);

                if (ticket.FlightID > 0)
                {
                    e_ticket = e_ticket.Where(t => t.FlightID == ticket.FlightID)
                                               .AsNoTracking();
                }
                if (ticket.CustomerID > 0)
                {
                    e_ticket = e_ticket.Where(f => f.CustomerID == ticket.CustomerID)
                                               .AsNoTracking();
                }
                if (ticket.Luggage > 0)
                {
                    e_ticket = e_ticket.Where(f => f.Luggage == ticket.Luggage)
                                               .AsNoTracking();
                }
                if (ticket.Price > 0)
                {
                    e_ticket = e_ticket.Where(f => f.Price == ticket.Price)
                                               .AsNoTracking();
                }
                if (ticket.Checkin == true)
                {
                    e_ticket = e_ticket.Where(f => f.Checkin == ticket.Checkin)
                                               .AsNoTracking();
                }

                List<FlightTicket> ticketFind2 = await e_ticket.ToListAsync();
                List<Logic.FlightTicket> resultticket = ticketFind2.Select(Mapper.MapEToFlightTicket).ToList();
                if (resultticket.Count < 1)
                {
                    //logger.Warn();
                    return null;
                }
                return resultticket;
            }
            else
            {
                List<Logic.FlightTicket> ticketFind = new List<Logic.FlightTicket>
                {
                    Mapper.MapEToFlightTicket(dbcontext.FlightTicket.Find(ticket.TicketID))
                };
                //logger.Info();
                return ticketFind;
            }
        }

        public async Task<string> UpdateFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = await dbcontext.FlightTicket.FindAsync(ticket.TicketID);

            if (e_ticket == null)
            {
                //logger.Warn("Airport not Found")
                return "no such Airport";
            }

            if (ticket.CustomerID > 0)
            {
                e_ticket.CustomerID = ticket.CustomerID;
            }
            if (ticket.FlightID > 0)
            {
                e_ticket.FlightID = ticket.FlightID;
            }
            if (ticket.Checkin != e_ticket.Checkin)
            {
                e_ticket.Checkin = ticket.Checkin;
            }
            if (ticket.Luggage > 0)
            {
                e_ticket.Luggage = ticket.Luggage;
            }
            if (ticket.Price > 0)
            {
                e_ticket.Price = ticket.Price;
            }

            await dbcontext.SaveChangesAsync();
            //logger.Info();

            return "update success";
        }

        public async Task<string> DeleteFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = await dbcontext.FlightTicket.FindAsync(ticket.TicketID);
            if (e_ticket == null)
            {
                //logger.Warn("FlightTicket not found.")
                return "no such ticket";
            }
            Flight e_flight = dbcontext.Flight.Find(ticket.FlightID);
            e_flight.SeatAvailable++;
            dbcontext.Remove(dbcontext.FlightTicket.Find(ticket.TicketID));

            await dbcontext.SaveChangesAsync();

            //logger.info();
            return "delete success";
        }

        public async Task<string> CheckSeatAvailible(int flightID, int numTickets)
        {
            Flight e_flight = await dbcontext.Flight.FindAsync(flightID);

            if (e_flight.SeatAvailable - numTickets < 0)
            {
                //logger.info("Seat is not enough")
                return "No";
            }
            else
            {
                e_flight.SeatAvailable = e_flight.SeatAvailable - numTickets;
                await dbcontext.SaveChangesAsync();
                return "Yes";
            }

        }

        public async Task<int> GetTicketId()
        {
            return await dbcontext.FlightTicket.MaxAsync(e => e.FlightTicketID);
        }

        public async Task<int> GetFlightId()
        {
            return await dbcontext.Flight.MaxAsync(e => e.FlightID);
        }

        public async Task<int> GetCustomerId()
        {
            return await dbcontext.Customer.MaxAsync(e => e.CustomerID);
        }

        public async Task<string> GetAirPortName(string name)
        {
            Airport find = await dbcontext.Airport.FindAsync(name);
            if (find == null)
            {
                return null;
            }
            else
            {
                return find.Name;
            }
        }
    }
}
