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
    public class AirportController : ControllerBase
    {
        private static IRepo iRepo;
        public AirportController(IRepo repo)
        {
            iRepo = repo; 
        }

        // GET: api/airport
        [HttpGet]
        public async Task<IEnumerable<API.Models.APIAirport>> Get()
        {
            IEnumerable<Logic.Airport> airports = await iRepo.ReadAirportList(null);
            IEnumerable<API.Models.APIAirport> apiAirport = airports.Select(a => new API.Models.APIAirport
            {
                //APIModel = Logic
                Name = a.Name,
                Location = a.Location,
                Weather = a.Weather

            });

            return apiAirport;
        }

        // GET: api/Airport/Airport's name
        [HttpGet("{name}", Name = "GetAirport")]

        public async Task<IEnumerable<API.Models.APIAirport>> GetByName(string name)
        {
            string find = await iRepo.GetAirPortName(name);

            if (find == null)
            {
                Logic.Airport LAir = new Logic.Airport();
                LAir.Name = name;
                IEnumerable<Logic.Airport> airports = await iRepo.ReadAirportList(null);
                IEnumerable<API.Models.APIAirport> apiAirport = airports.Select(a => new API.Models.APIAirport
                {
                    //APIModel = Logic
                    Name = a.Name,
                    Location = a.Location,
                    Weather = a.Weather

                });

                return apiAirport;
            }
            else
            {
                Logic.Airport LAir = new Logic.Airport();
                LAir.Name = name;
                IEnumerable<Logic.Airport> airports = await iRepo.ReadAirportList(LAir);
                IEnumerable<API.Models.APIAirport> apiAirport = airports.Select(a => new API.Models.APIAirport
                {
                    //APIModel = Logic
                    Name = a.Name,
                    Location = a.Location,
                    Weather = a.Weather

                });

                return apiAirport;
            }
        }

        // POST: api/Airport
        [HttpPost]
        public async Task<ActionResult> Post([FromBody, Bind("Name, Location, Weather")] API.Models.APIAirport airport)
        {
            Logic.Airport air = new Logic.Airport
            {
                Name = airport.Name,
                Location = airport.Location,
                Weather = airport.Weather
            };

            await iRepo.CreateAirport(air);

            return CreatedAtRoute("GetAirport", new {name = air.Name}, air);
        }

        // PUT: api/Airport/Name of airport you want to edit
        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] API.Models.APIAirport airport)
        {
            Logic.Airport air = new Logic.Airport();
            air.Name = airport.Name;

            IEnumerable<Logic.Airport> Lairports = await iRepo.ReadAirportList(air);

            //Need exception handling here, maybe implement in repo?
            Logic.Airport newAir = new Logic.Airport
            {
                Name = airport.Name,
                Location = airport.Location,
                Weather = airport.Weather
            };

            await iRepo.UpdateAirport(newAir);
            return Ok();
        }

        // DELETE: api/airport/AirportName
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            Logic.Airport air = new Logic.Airport();
            air.Name = name;

            await iRepo.DeleteAirport(air);

            return Ok();
        }
    }
}
