﻿using System;
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

        // GET: api/Airport
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Airport/Airport's name
        [HttpGet("{name}", Name = "GetAirport")]
        public async Task<IEnumerable<API.Models.APIAirport>>GetByName(string name)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] API.Models.APIAirport Aairport)
        {
            Logic.Airport air = new Logic.Airport();
            air.Name = id;

            IEnumerable<Logic.Airport> Lairports = await iRepo.ReadAirportList(air);

            //Need exception handling here, maybe implement in repo?
            Logic.Airport newAir = new Logic.Airport
            {
                Name = Aairport.Name,
                Location = Aairport.Location,
                Weather = Aairport.Weather
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

            //IEnumerable<Logic.Airport> Lairports = iRepo.ReadAirportList(air);
            await iRepo.DeleteAirport(air);

            return Ok();
        }
    }
}
