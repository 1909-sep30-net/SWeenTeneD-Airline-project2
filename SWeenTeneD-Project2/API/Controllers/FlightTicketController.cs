using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic;

namespace API.Controllers
{
    [Route("~/api/[controller]")]
    [ApiController]
    public class FlightTicketController : ControllerBase
    {
        private static IRepo iRepo;

        public FlightTicketController(IRepo repo)
        {
            iRepo = repo;
        }

        // GET: api/FlightTicket
        [HttpGet]
        public async Task<IEnumerable<API.Models.APIFlightTicket>> Get()
        {
            IEnumerable<Logic.FlightTicket> allFlightTickets = await iRepo.ReadTicketList(null);
            IEnumerable<API.Models.APIFlightTicket> nullAPI = allFlightTickets.Select(af => new API.Models.APIFlightTicket
            {
                TicketID = af.TicketID,
                FlightID = af.FlightID,
                CustomerID = af.CustomerID,
                Price = af.Price,
                CheckIn = af.Checkin,
                Luggage = af.Luggage
            });
            return nullAPI;
        }

        // GET: api/FlightTicket/5
        [HttpGet("{id}", Name = "GetFlightTicket")]
        public async Task<IEnumerable<API.Models.APIFlightTicket>> Get(int id)
        {
            Logic.FlightTicket LTicket = new Logic.FlightTicket();
            LTicket.TicketID = id;

            //Be careful with int because default for int is 0 not null
            //Read maximum ID from database and pass it as parameter for If
            if (LTicket.TicketID <= 0 || LTicket.TicketID > await iRepo.GetTicketId())
            {
                IEnumerable<Logic.FlightTicket> allFlightTickets = await iRepo.ReadTicketList(null);
                IEnumerable<API.Models.APIFlightTicket> nullAPI = allFlightTickets.Select(af => new API.Models.APIFlightTicket
                {
                    TicketID = af.TicketID,
                    FlightID = af.FlightID,
                    CustomerID = af.CustomerID,
                    Price = af.Price,
                    CheckIn = af.Checkin,
                    Luggage = af.Luggage
                });
                return nullAPI;
            }

            IEnumerable<Logic.FlightTicket> flightTickets = await iRepo.ReadTicketList(LTicket);
            IEnumerable<API.Models.APIFlightTicket> apiFlightTicket = flightTickets.Select(ft => new API.Models.APIFlightTicket
            {
                //APIModel = Logic
                TicketID = ft.TicketID,
                FlightID = ft.FlightID,
                CustomerID = ft.CustomerID,
                Price = ft.Price,
                CheckIn = ft.Checkin,
                Luggage = ft.Luggage

            });

            return apiFlightTicket;
        }



        // POST: api/FlightTicket
        [HttpPost]
        public async Task<ActionResult> Post([FromBody,Bind("FlightID, CustomerID, Price, CheckIn, Luggage")] API.Models.APIFlightTicket flightTicket)
        {
            Logic.FlightTicket flight = new Logic.FlightTicket
            {
                TicketID = flightTicket.TicketID,
                FlightID = flightTicket.FlightID,
                CustomerID = flightTicket.CustomerID,
                Price = flightTicket.Price,
                Checkin = flightTicket.CheckIn,
                Luggage = flightTicket.Luggage
            };

            await iRepo.CheckSeatAvailible(flight.FlightID, 1);

            await iRepo.CreateFlightTicket(flight);

            return CreatedAtRoute("GetFlightTicket", new {id = flight.TicketID}, flight);

        }

        // PUT: api/FlightTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] API.Models.APIFlightTicket AflightTicket)
        {
            Logic.FlightTicket fli = new Logic.FlightTicket();
            fli.TicketID = id;

            IEnumerable<Logic.FlightTicket> LflightTickets = await iRepo.ReadTicketList(fli);

            Logic.FlightTicket newFli = new Logic.FlightTicket
            {
                TicketID = AflightTicket.TicketID,
                FlightID = AflightTicket.FlightID,
                CustomerID = AflightTicket.CustomerID,
                Price = AflightTicket.Price,
                Checkin = AflightTicket.CheckIn,
                Luggage = AflightTicket.Luggage
            };

            await iRepo.UpdateFlightTicket(newFli);
            return Ok();

        }

        //NOT WORKING AT THE MOMENT DUE TO ADDING SEAT++ IN REPO
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Logic.FlightTicket fli = new Logic.FlightTicket();
            fli.TicketID = id;

            await iRepo.DeleteFlightTicket(fli);

            return Ok();
        }
    }
}
