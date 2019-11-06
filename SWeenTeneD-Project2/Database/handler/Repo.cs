using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Logic;
using Microsoft.EntityFrameworkCore;
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

        public string CreateCustomer(Logic.Customer customer)
        {
            Customer e_customer = Mapper.MapCustomerToE(customer);
            dbcontext.Add(e_customer);
            dbcontext.SaveChanges();
            //logger.Info();

            return $"{customer.FirstName} {customer.LastName} is created.";
        }


        public List<Logic.Customer> ReadCustomerList(Logic.Customer customer)
        {
            if (customer.CustomerID <= 0 && customer.FirstName == null)
            {
                return dbcontext.Customer.Select(Mapper.MapEToCustomer).ToList();
            }

            if (customer.CustomerID <= 0)
            {
                IQueryable<Customer> q_cusotmer = null;
                if (customer.FirstName != null)
                {
                    q_cusotmer = dbcontext.Customer.Where(c => c.FirstName == customer.FirstName)
                                        .AsNoTracking();
                }
                if (customer.LastName != null)
                {
                    q_cusotmer = dbcontext.Customer.Where(c => c.LastName == customer.LastName)
                        .AsNoTracking();
                }
                if (customer.Email != null)
                {
                    q_cusotmer = dbcontext.Customer.Where(c => c.Email == customer.Email)
                        .AsNoTracking();
                }

                IEnumerable<Logic.Customer> customerFind = q_cusotmer.Select(Mapper.MapEToCustomer);
                if (customerFind.ToList().Count < 1)
                {
                    //logger.Warn();
                    return null;
                }
                return customerFind.ToList();
            }
            else
            {
                List<Logic.Customer> customerFind = new List<Logic.Customer>();
                customerFind.Add(Mapper.MapEToCustomer(dbcontext.Customer.Find(customer.CustomerID)));
                
                //logger.Info();
                return customerFind;
            }
            
        }

        public string UpdateCustomer(Logic.Customer customer)
          {
            Customer e_customer = dbcontext.Customer.Find(customer.CustomerID);

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
            
            dbcontext.SaveChanges();
            //logger.Info();

            return "update success";
          }


        public string DeleteCustomer(Logic.Customer customer)
        {
            Customer e_customer = dbcontext.Customer.Find(customer.CustomerID);
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

        public string CreateFlight(Logic.Flight flight)
        {

            Flight e_flight = Mapper.MapFlightToE(flight);
            dbcontext.Add(e_flight);
            dbcontext.SaveChanges();

            //logger.info();
            return "New Flight Created!";
        }

        public List<Logic.Flight> ReadFlightList(Logic.Flight flight)
        {
            if ( flight == null )
            {
                return dbcontext.Flight.Select(Mapper.MapEtoFlight).ToList();
            }
            if (flight.FlightID <= 0)
            {
                IQueryable<Flight> e_flight = null;

                if (flight.Company != null)
                {
                    e_flight = dbcontext.Flight.Where(f => f.Company == flight.Company)
                                               .AsNoTracking();
                }
                if (flight.Origin != null)
                {
                    e_flight = dbcontext.Flight.Where(e => e.Origin == flight.Origin)
                                            .AsNoTracking();
                }
                if (flight.Destination != null)
                {
                    e_flight = dbcontext.Flight.Where(e => e.Destination == flight.Destination)
                                            .AsNoTracking();

                }
                if (flight.SeatAvailable > 0)
                {
                    e_flight = dbcontext.Flight.Where(f => f.SeatAvailable > flight.SeatAvailable)
                                               .AsNoTracking();
                }

                List<Logic.Flight> flightFind = e_flight.Select(Mapper.MapEtoFlight).ToList();
                if ( flightFind.Count < 1 )
                {
                    //logger.Warn();
                    return null;                  
                }
                return flightFind;
            }
            else 
            {
                List<Logic.Flight> flightFind = new List<Logic.Flight>
                {
                    Mapper.MapEtoFlight(dbcontext.Flight.Find(flight.FlightID))
                };
                //logger.Info();
                return flightFind;
            }
        }

        public string UpdateFlight(Logic.Flight flight)
        {
            Flight e_flight = dbcontext.Flight.Find(flight.FlightID);

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

            dbcontext.SaveChanges();
            //logger.Info();

            return "update success";
        }


        public string DeleteFlight(Logic.Flight flight)
        {
            Flight e_flight = dbcontext.Flight.Find(flight.FlightID);
            if (e_flight == null)
            {
                //logger.Warn("Flight not found.")
                return "no such customer";
            }

            dbcontext.Remove(dbcontext.Flight.Find(flight.FlightID));
            dbcontext.SaveChanges();

            //logger.info();
            return "delete success";
        }

        public string CreateAirport(Logic.Airport airport)
        {
            Airport e_airport = Mapper.MapAirportToE(airport);
            dbcontext.Add(e_airport);
            dbcontext.SaveChanges();

            //logger.info();
            return "New Flight Created!";
        }


        public List<Logic.Airport> ReadAirportList(Logic.Airport airport)
        {
            if (airport == null)
            {
                return dbcontext.Airport.Select(Mapper.MapEToAirport).ToList();
            }
                IQueryable<Airport> e_airport = null;

                if (airport.Name != null)
                {
                    e_airport = dbcontext.Airport.Where(a => a.Name == airport.Name)
                                               .AsNoTracking();
                }
                if (airport.Location != null)
                {
                    e_airport = dbcontext.Airport.Where(f => f.Location == airport.Location)
                                               .AsNoTracking();
                }
                if (airport.Weather != null)
                {
                    e_airport = dbcontext.Airport.Where(f => f.Weather == airport.Weather)
                                               .AsNoTracking();
                }

                return e_airport.Select(Mapper.MapEToAirport).ToList();        
        }

        public string UpdateAirport(Logic.Airport airport)
        {
            Airport e_airport = dbcontext.Airport.Find(airport.Name);

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

            dbcontext.SaveChanges();
            //logger.Info();

            return "update success";
        }

        public string DeleteAirport(Logic.Airport airport)
        {
            Airport e_Airport = dbcontext.Airport.Find(airport.Name);
            if (e_Airport == null)
            {
                //logger.Warn("Airport not found.")
                return "no such customer";
            }
            dbcontext.Remove(dbcontext.Airport.Find(airport.Name));
            dbcontext.SaveChanges();

            //logger.info();
            return "delete success";
        }

        public string CreateFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = Mapper.MapFlightTicketToE(ticket);
            dbcontext.Add(e_ticket);
            dbcontext.SaveChanges();

            //logger.info();
            return "New Ticket Created!";
        }

        public List<Logic.FlightTicket> ReadTicketList(Logic.FlightTicket ticket)
        {
            if (ticket == null)
            {
                return dbcontext.FlightTicket.Select(Mapper.MapEToFlightTicket).ToList();
            }
            if (ticket.TicketID <= 0)
            {
                IQueryable<FlightTicket> e_ticket = null;

                if (ticket.FlightID > 0)
                {
                    e_ticket = dbcontext.FlightTicket.Where(a => a.FlightID == ticket.FlightID)
                                               .AsNoTracking();
                }
                if (ticket.CustomerID > 0)
                {
                    e_ticket = dbcontext.FlightTicket.Where(f => f.CustomerID == ticket.CustomerID)
                                               .AsNoTracking();
                }
                if (ticket.Luggage > 0)
                {
                    e_ticket = dbcontext.FlightTicket.Where(f => f.Luggage == ticket.Luggage)
                                               .AsNoTracking();
                }
                if (ticket.Price > 0)
                {
                    e_ticket = dbcontext.FlightTicket.Where(f => f.Price == ticket.Price)
                                               .AsNoTracking();
                }
                if (ticket.Checkin == true)
                {
                    e_ticket = dbcontext.FlightTicket.Where(f => f.Checkin == ticket.Checkin)
                                               .AsNoTracking();
                }

                List<Logic.FlightTicket> ticketFind = e_ticket.Select(Mapper.MapEToFlightTicket).ToList();
                if (ticketFind.Count < 1)
                {
                    //logger.Warn();
                    return null;                  
                }
                return ticketFind;
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

        public string UpdateFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = dbcontext.FlightTicket.Find(ticket.TicketID);

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

            dbcontext.SaveChanges();
            //logger.Info();

            return "update success";
        }

        public string DeleteFlightTicket(Logic.FlightTicket ticket)
        {
            FlightTicket e_ticket = dbcontext.FlightTicket.Find(ticket.TicketID);
            if (e_ticket == null)
            {
                //logger.Warn("FlightTicket not found.")
                return "no such ticket";
            }
            Flight e_flight = dbcontext.Flight.Find(ticket.FlightID);
            e_flight.SeatAvailable++;
            dbcontext.Remove(dbcontext.FlightTicket.Find(ticket.TicketID));

            dbcontext.SaveChanges();

            //logger.info();
            return "delete success";
        }

        public string CheckSeatAvailible(int flightID, int numTickets)
        {
            Flight e_flight = dbcontext.Flight.Find(flightID);

            if (e_flight.SeatAvailable - numTickets < 0)
            {
                //logger.info("Seat is not enough")
                return "Sorry the remaining number seat is not enough";
            }
            else
            {
                e_flight.SeatAvailable = e_flight.SeatAvailable = numTickets;
                dbcontext.SaveChanges();
                return "Great! we have enough seat available";
            }

        }

        public int GetTicketId()
        {
            //test comment
            return dbcontext.FlightTicket.Max(e => e.FlightTicketID);
        }

        public int GetFlightId()
        {
            //test comment
            return dbcontext.Flight.Max(e => e.FlightID);
        }
    }
}
