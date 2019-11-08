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
    public class FlightController : ControllerBase
    {
        private static IRepo iRepo;
        public FlightController(IRepo repo)
        {
            iRepo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<API.Models.APIFlight>> Get()
        {
            IEnumerable<Logic.Flight> allFlights = await iRepo.ReadFlightList(null);
            IEnumerable<API.Models.APIFlight> nullAPI = allFlights.Select(af => new API.Models.APIFlight
            {
                FlightID = af.FlightID,
                Company = af.Company,
                DepartureTime = af.DepartureTime,
                ArrivalTime = af.ArrivalTime,
                Origin = af.Origin,
                Destination = af.Destination,
                SeatAvailable = af.SeatAvailable,
                Price = af.Price
            });
            return nullAPI;
        }

        //Should return a specific flight, if ID does not exist then print all
        // GET: api/Flight/5
        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<IEnumerable<API.Models.APIFlight>> Get(int id)
        {
            Logic.Flight LFlight = new Logic.Flight();
            LFlight.FlightID = id;

            //Will add another method to check max element of FlightID
            if(LFlight.FlightID <= 0 || LFlight.FlightID > await iRepo.GetFlightId())
            {
                IEnumerable<Logic.Flight> allFlights = await iRepo.ReadFlightList(null);
                IEnumerable<API.Models.APIFlight> nullAPI = allFlights.Select(af => new API.Models.APIFlight
                {
                    FlightID = af.FlightID,
                    Company = af.Company,
                    DepartureTime = af.DepartureTime,
                    ArrivalTime = af.ArrivalTime,
                    Origin = af.Origin,
                    Destination = af.Destination,
                    SeatAvailable = af.SeatAvailable,
                    Price = af.Price
                });
                return nullAPI;
            }

            IEnumerable<Logic.Flight> flights = await iRepo.ReadFlightList(LFlight);
            IEnumerable<API.Models.APIFlight> apiFlights = flights.Select(f => new API.Models.APIFlight
            {
                FlightID = f.FlightID,
                Company = f.Company,
                DepartureTime = f.DepartureTime,
                ArrivalTime = f.ArrivalTime,
                Origin = f.Origin,
                Destination = f.Destination,
                SeatAvailable = f.SeatAvailable,
                Price = f.Price
            });

            return apiFlights;
        }


        //Might leave the creation of price for admin, but to get rid of it for customer?
        // POST: api/Flight
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("Company, DepartureTime, ArrivalTime, Origin, Destination, SeatAvailable, Price")] API.Models.APIFlight flight)
        {
            Logic.Flight fli = new Logic.Flight
            {
                FlightID = flight.FlightID,
                Company = flight.Company,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Origin = flight.Origin,
                Destination = flight.Destination,
                SeatAvailable = flight.SeatAvailable,
                Price = flight.Price
            };
            
            await iRepo.CreateFlight(fli);

            return CreatedAtRoute("GetFlight", new {id = fli.FlightID}, fli);
        }

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] API.Models.APIFlight AFlight)
        {
            Logic.Flight fli = new Logic.Flight();
            fli.FlightID = id;

            IEnumerable<Logic.Flight> Lflights = await iRepo.ReadFlightList(fli);

            Logic.Flight newFli = new Logic.Flight
            {
                FlightID = AFlight.FlightID,
                Company = AFlight.Company,
                DepartureTime = AFlight.DepartureTime,
                ArrivalTime = AFlight.ArrivalTime,
                Origin = AFlight.Origin,
                Destination = AFlight.Destination,
                SeatAvailable = AFlight.SeatAvailable,
                Price = AFlight.Price
            };

            await iRepo.UpdateFlight(newFli);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Logic.Flight fli = new Logic.Flight();
            fli.FlightID = id;

            await iRepo.DeleteFlight(fli);

            return Ok();
        }
    }
}
