using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Database;

namespace API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private static Repo repo;
        //REPO goes here

        //private readonly CustomerL

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Customer", "GET GET" };
        }


        //[HttpGet]
        //public IActionResult GetAllCustomers(info){
        //     IEnumerable<Logic.Customer> customers = Repo.ReadCustomerList(info);
        //     IEnumerable<API.Models.APICustomer> apiCustomer = customers.Select( c=> new API.Models.APICustomer
        //     {
        //         //From APIModel = Logic
        //         CustomerID = c.CustomerID,
        //         FirstName = c.FirstName,
        //       LastName = c.LastName,
        //         Email = c.Email,
        //         Password = c.Password


        //     });
        //     return apiCustomer;
        //}



        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        
          [HttpPost]
          public ActionResult Create(Logic.Customer customer){

            Logic.Customer cus = new Logic.Customer
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password

            };

            var newID = customer.CustomerID;

            string a = repo.CreateCustomer(cus);

            return CreatedAtRoute("Get", new { Id = newID}, customer);
            //return Ok();

        }

        // PUT: api/Customer/5
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
