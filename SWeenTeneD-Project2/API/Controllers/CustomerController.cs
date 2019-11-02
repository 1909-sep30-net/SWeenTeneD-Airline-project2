using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Database;

namespace API.Controllers
{
   
    [Route("~/api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //REPO goes here
        private static IRepo iRepo;

        public CustomerController(IRepo repo)
        {
            iRepo = repo;
        }
        //private readonly CustomerL

        // GET: api/Customer
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "Customer", "GET GET" };
        //}

        [HttpGet("{firstname}", Name = "GetCustomer")]
        public IEnumerable<API.Models.APICustomer> GetAllCustomers(string firstname)
        {
            Logic.Customer Lcus = new Logic.Customer();
            Lcus.FirstName = firstname;
            IEnumerable<Logic.Customer> customers = iRepo.ReadCustomerList(Lcus);
            IEnumerable<API.Models.APICustomer> apiCustomer = customers.Select(c => new API.Models.APICustomer
            {
                //From APIModel = Logic
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Password = c.Password

        //[HttpGet("{firstname}", Name = "GetCustomer")]
        //public List<API.Models.APICustomer> GetCustomer(string firstname)
        //{
        //    Logic.Customer Lcus = new Logic.Customer();
        //    Lcus.FirstName = firstname;

            });

            return apiCustomer;
        }



        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "GetCustomer")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/Customer
       //[HttpPost]
       // public void Post([FromBody] string value)
       // {
       // }

        //POST: api/Customer
        [HttpPost]
        public ActionResult Create([FromBody, Bind("FirstName, LastName, Email, Password")]API.Models.APICustomer customer)
        {

            Logic.Customer cus = new Logic.Customer
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password
            };
          
           iRepo.CreateCustomer(cus);

            return CreatedAtRoute("GetCustomer", new { FirstName = cus.FirstName }, customer);

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
