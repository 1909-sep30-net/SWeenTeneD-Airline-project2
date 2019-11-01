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
        

        public string CreateCustomer(Logic.Customer customer)
        {
            Customer e_customer = Mapper.MapCustomerToE(customer);
            dbcontext.Add(e_customer);
            dbcontext.SaveChanges();
            //logger.Info();

            return $"{customer.FirstName} {customer.LastName} is created.";
        }


<<<<<<< HEAD
        public List<Logic.Customer> ReadCustomerList(Logic.Customer customer)
        {
            IQueryable<Customer> q_cusotmer = null;

            if (customer.FirstName != null) {
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

            List<Logic.Customer> customerFind = q_cusotmer.Select(Mapper.MapEToCustomer).ToList();
            if (customerFind == null )
            {
                return null;
                //logger.Warn();
            }
            return customerFind;
            //logger.Info();
=======
        //public IEnumerable<Customer> ReadCustomerList(Logic.Customer customer)
        //{
        //    IQueryable<Customer> cusotmerFind = dbcontext.Customer.Where(c => c.Info == info)
        //                                       .AsNotracking();
        //    if (IQ<customer> == null)
        //    {
        //        return null;
        //        logger.Warn();
        //    }
        //    return IQ<customer>.Select(Mapper.Customer);
        //    logger.Info();
>>>>>>> 5e14af370df1f5255baedac40ab53805449c218c

        //}

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



        /*public CreateFlight( L.Flight )
         * {
         * 
         *     E.Flight = Map.Mapper(L.Flight)
         *     DB.Add(E.Flight);    
         *     dbContext.SaveChange();
         *     logger.Info();
         * }
         */

        /*public IEnumerable<Flight> ReadFlightList( info )
         * {
         *     create IQ<Flight> = DB.E.Flight.Where(f => f.Info == info)
         *                                        .AsNotracking();
         *     if ( IQ<Flight> == null ) 
         *     {
         *         return null;
         *         logger.Warn();
         *     }
         *     return IQ<Flight>.Select(Mapper.Flight);
         *     logger.Info();
         * }
         * 
         */

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
