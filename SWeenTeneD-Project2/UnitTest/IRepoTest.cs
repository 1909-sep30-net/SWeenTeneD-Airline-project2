using System;
using Logic;
using Xunit;
using Database;
using Moq;
using System.Collections.Generic;

namespace UnitTest
{
    public class IRepoTest
    {
        private Mock<IRepo> repo = new Mock<IRepo>();
        private readonly Logic.Customer customer
            = new Logic.Customer(1,"tri", "nguyen", "Tri@Broke.Everything", "TriBrokeEverything");

        [Fact]
        public void MockCreateCustomer()
        {           
        }

        [Fact]
        public void MockReadCustomer()
        {
        }

        [Fact]
        public void MockUpdateCustomer()
        {
        }

        [Fact]
        public void MockDeleteCustomer()
        {
        }
    }
}
