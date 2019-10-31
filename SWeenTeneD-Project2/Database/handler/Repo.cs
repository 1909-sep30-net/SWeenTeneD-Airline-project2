using System;
using System.Collections.Generic;
using System.Text;
using Logic;
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
        //Add logger;

        /*public CreateCustomer( Logic.Customer customer )
         * {
         * 
         *     Entity.Customer e_customer = Mapper.MapCustomer(customer);
         *     dbContext.Add(e_customer);
         *     dbContext.SaveChange();
         *     logger.Info();
         * }
         */

        /*public IEnumerable<Customer> ReadCustomerList( info )
         * {
         *     create IQ<customer> = DB.E.Customer.Where(c => c.Info == info)
         *                                        .AsNotracking();
         *     if ( IQ<customer> == null ) 
         *     {
         *         return null;
         *         logger.Warn();
         *     }
         *     return IQ<customer>.Select(Mapper.Customer);
         *     logger.Info();
         * }
         * 
         */

        /*
         * 
         * 
         */

        /*public string UpdateCustomer ( info )
         * {
         *     var customer = DB.E.Customer(c => c.Info == info);
         *     if ( customer == null )
         *     {
         *         return "no such customer";
         *     }
         *     customer.infotochange = newInfo; may have multiple info
         *     logger.Info();
         *     DB.savechanges();
         *     logger.Info();
         *     
         *     return "update success"
         * }
         */

        /*public string DeleteCustomer ( info )
         * {
         *     E.Cusotmer = DB.Customer.Where(c => c.Info == info);
         *     if ( E.Cusotmer == null )
         *     {
         *        return "no such customer";
         *     }
         *     DB.Remove(context.Customer.Info(c => c.Info == info));
         *     DB.SaveChanges();
         *     logger.Info();
         *     
         *     return "delete success"
         * }
         */


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
