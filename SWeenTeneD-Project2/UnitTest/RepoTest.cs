using System;
using Logic;
using Xunit;
using Database;
using Moq;
using System.Collections.Generic;

namespace UnitTest
{
    public class RepoTest
    {
        private Mock<IRepo> repo = new Mock<IRepo>();
        private readonly Logic.Customer customer
            = new Logic.Customer(1,"tri", "nguyen", "Tri@Broke.Everything", "TriBrokeEverything");

        [Fact]
        public void MockCreateCustomer()
        {           
            string message = "tri nguyen is created.";
            repo.Setup(x => x.CreateCustomer(customer)).Returns("tri nguyen is created.");

            Assert.Equal(message, repo.Object.CreateCustomer(customer));
        }

        [Fact]
        public void MockReadCustomer()
        {
            Logic.Customer tri = new Logic.Customer
            {
                CustomerID = 1,
                FirstName = "tri",
                LastName = "nguyen",
                Email = "Tri@Broke.Everything",
                Password = "TriBrokeEverything"
            };
            List<Logic.Customer> customers = new List<Logic.Customer>
            {
                tri
            };

            repo.Setup(x => x.ReadCustomerList(customer)).Returns(customers);

            Assert.Equal(customers, repo.Object.ReadCustomerList(customer));
        }

        [Fact]
        public void MockUpdateCustomer()
        {
            repo.Setup(x => x.UpdateCustomer(customer)).Returns("success");
            Assert.Equal("success",repo.Object.UpdateCustomer(customer));
        }

        [Fact]
        public void MockDeleteCustomer()
        {
            repo.Setup(x => x.DeleteCustomer(customer)).Returns("success");
            Assert.Equal("success", repo.Object.DeleteCustomer(customer));
        }
    }
}
