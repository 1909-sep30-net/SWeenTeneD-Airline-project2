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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightTicket/5
        [HttpGet("{id}", Name = "GetFlightTicket")]
        public IEnumerable<API.Models.APIFlightTicket> Get(int id)
        {
            Logic.FlightTicket LTicket = new Logic.FlightTicket();
            LTicket.TicketID = id;
            IEnumerable<Logic.FlightTicket> flightTickets = iRepo.ReadTicketList(LTicket);
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
            if (LTicket == null)
            {
                IEnumerable<Logic.FlightTicket> allFlightTickets = iRepo.ReadTicketList(null);
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

            return apiFlightTicket;
        }

        // POST: api/FlightTicket
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FlightTicket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
