using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Database;
using Microsoft.AspNetCore.Authorization;

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

        //Write a if statement in this method, so that if the customer returns null
        //then it you pass that null customer to the ReadCustomerList and it should
        //it return all the customers available.

        //GET: api/Customer/Customer's first name
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IEnumerable<API.Models.APICustomer>> GetAllCustomers(int id)
        {
            int maxId = await iRepo.GetCustomerId();
            if (id <= 0 || id > maxId )
            {
                IEnumerable<Logic.Customer> customers = await iRepo.ReadCustomerList(null);
                IEnumerable<API.Models.APICustomer> apiCustomer = customers.Select(c => new API.Models.APICustomer
                {
                    //From APIModel = Logic
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Password = c.Password
                });

                return apiCustomer;
            }
            else
            {
                Logic.Customer Lcus = new Logic.Customer();
                Lcus.CustomerID = id;
                IEnumerable<Logic.Customer> customers = await iRepo.ReadCustomerList(Lcus);
                IEnumerable<API.Models.APICustomer> apiCustomer = customers.Select(c => new API.Models.APICustomer
                {
                    //From APIModel = Logic
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Password = c.Password
                });

                return apiCustomer;
            }
         
        }

        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "GetCustomer")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/Customer

        [HttpPost]
        public async Task<ActionResult> Create([FromBody, Bind("FirstName, LastName, Email, Password")]API.Models.APICustomer customer)
        {

            Logic.Customer cus = new Logic.Customer
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password
            };

            await iRepo.CreateCustomer(cus);

            return CreatedAtRoute("GetCustomer", new { firstname = cus.FirstName }, cus);

        }

        // PUT: api/Customer/First name of customer you want to edit
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] API.Models.APICustomer Acustomer)
        {

            Logic.Customer cus = new Logic.Customer();
            cus.FirstName = id;
            
            IEnumerable<Logic.Customer> Lcustomers = await iRepo.ReadCustomerList(cus);

                //Remember to add try catch or some exception handling
                Logic.Customer newCus = new Logic.Customer
                {
                    CustomerID = Acustomer.CustomerID,
                    FirstName = Acustomer.FirstName,
                    LastName = Acustomer.LastName,
                    Email = Acustomer.Email,
                    Password = Acustomer.Password
                };

                await iRepo.UpdateCustomer(newCus);
                return Ok();
         
        }

        // DELETE: api/customer/CustomerID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Logic.Customer cus = new Logic.Customer();
            cus.CustomerID = id;

            await iRepo.DeleteCustomer(cus);

            return Ok();

        }
    }
}
