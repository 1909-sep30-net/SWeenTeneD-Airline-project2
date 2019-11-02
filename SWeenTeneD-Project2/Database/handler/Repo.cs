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
                    return null;
                    //logger.Warn();
                }
                return customerFind.ToList();
            }
            else
            {
                List<Logic.Customer> customerFind = new List<Logic.Customer>();
                customerFind.Add(Mapper.MapEToCustomer(dbcontext.Customer.Find(customer.CustomerID)));
                return customerFind;
            }
            //logger.Info();
        }

        public string UpdateCustomer(Logic.Customer customer)
          {


            Customer e_customer
                = dbcontext.Customer.Find(customer.CustomerID);

            if (customer == null)
            {
                return "no such customer";
            }

            if (customer.LastName != null) {
                e_customer.LastName = customer.LastName;
            }
            if (customer.FirstName != null)
            {
                e_customer.LastName = customer.LastName;
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
            if (customer == null)
            {
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
                    e_flight = dbcontext.Flight.Where(f => f.Origin == flight.Origin)
                                               .AsNoTracking();
                }
                if (flight.Destination != null)
                {
                    e_flight = dbcontext.Flight.Where(f => f.Destination == flight.Destination)
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
                    return null;
                    //logger.Warn();
                }
                return flightFind;
            }
            else 
            {
                List<Logic.Flight> flightFind = new List<Logic.Flight>();
                flightFind.Add(Mapper.MapEtoFlight(dbcontext.Flight.Find(flight.FlightID)));
                return flightFind;
            }
            //logger.Info();

        }
         
         

        /*public string UpdateFlight ( info )
         * {
         *     var Flight = DB.E.Flight(f => f.Info == info);
         *     if ( Flight == null )
         *     {
         *         return "no such Flight";
         *     }
         *     Flight.infotochange = newInfo; may have multiple info
         *     logger.Info();
         *     DB.savechanges();
         *     logger.Info();
         *     
         *     return "update success"
         * }
         */

        /*public string DeleteFlight ( info )
         * {
         *     E.Flight = DB.Flight.Where(f => f.Info == info);
         *     if ( E.Flight == null )
         *     {
         *        return "no such Flight";
         *     }
         *     DB.Remove(context.Flight.Info(f => f.Info == info));
         *     DB.SaveChanges();
         *     logger.Info();
         *     
         *     return "delete success"
         * }
         */

        /*public CreateAirport( Logic.Airport )
         * {
         *     E.Airport = Mapper.MapAirport(Airport);
         *     DB.Add(E.Airport);
         *     DB.SaveChange();
         *     logger.Info();
         * }
         */

        /*public IEnumerable<Airport> ReadAirportList( info )
         * {
         *     create IQ<Airport> = DB.E.Airport.Where(a => a.Info == info)
         *                                        .AsNotracking();
         *     if ( IQ<Airport> == null ) 
         *     {
         *         return null;
         *         logger.Warn();
         *     }
         *     return IQ<Airport>.Select(Mapper.Airport);
         *     logger.Info();
         * }
         * 
         */

        /*public string UpdateAirport ( info )
         * {
         *     var Airport = DB.E.Airport(a => a.Info == info);
         *     if ( Airport == null )
         *     {
         *         return "no such Airport";
         *     }
         *     Airport.infotochange = newInfo; may have multiple info
         *     logger.Info();
         *     DB.savechanges();
         *     logger.Info();
         *     
         *     return "update success"
         * }
         */

        /*public string DeleteAirport ( info )
         * {
         *     E.Airport = DB.Airport.Where(a => a.Info == info);
         *     if ( E.Airport == null )
         *     {
         *        return "no such Airport";
         *     }
         *     DB.Remove(context.Airport.Info(a => a.Info == info));
         *     DB.SaveChanges();
         *     logger.Info();
         *     
         *     return "delete success"
         * }
         */

        /*public CreateFlightTicket( Logic.FlightTicket)
         * {
         * 
         *     E.FlightTicket= Mapper.MapFlightTicket(FlightTicket);
         *     DB.Add(FlightTicket);
         *     DB.SaveChange();
         *     logger.Info();
         * }
         */

        /*public IEnumerable<FlightTicket> ReadFlightTicketList( info )
         * {
         *     create IQ<FlightTicket> = DB.E.FlightTicket.Where(f => f.Info == info)
         *                                        .AsNotracking();
         *     if ( IQ<FlightTicket> == null ) 
         *     {
         *         return null;
         *         logger.Warn();
         *     }
         *     return IQ<FlightTicket>.Select(Mapper.FlightTicket);
         *     logger.Info();
         * }
         * 
         */

        /*public string UpdateFlightTicket ( info )
         * {
         *     var FlightTicket = DB.E.FlightTicket(f => f.Info == info);
         *     if ( FlightTicket == null )
         *     {
         *         return "no such FlightTicket";
         *     }
         *     FlightTicket.infotochange = newInfo; may have multiple info
         *     logger.Info();
         *     DB.savechanges();
         *     logger.Info();
         *     
         *     return "update success"
         * }
         */

        /*public string DeleteFlightTicket ( info )
         * {
         *     E.FlightTicket = DB.FlightTicket.Where(f => f.Info == info);
         *     if ( E.FlightTicket == null )
         *     {
         *        return "no such FlightTicket";
         *     }
         *     DB.Remove(context.FlightTicket.Info(f=> f.Info == info));
         *     DB.SaveChanges();
         *     logger.Info();
         *     
         *     return "delete success"
         * }
         */
    }
}
