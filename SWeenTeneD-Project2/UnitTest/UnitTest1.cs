using SWeenTeneD_Project2;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        [Theory]
        [InlineData("Tri", "Nguyen", "Tri@Broke.Everything", "TriBrokeEverything")]
        public void CheckTrueValidCust(string fname, string lname, string email, string password)
        {
            Customer a = new Customer(fname, lname, email, password);

            Assert.True(a.ValidCust(a), "Customer Valid");
        }

        [Theory]
        [InlineData("Tri", null, "Tri@Broke.Everything", "TriBrokeEverything")]
        public void CheckFalseValidCust(string fname, string lname, string email, string password)
        {
            Customer a = new Customer(fname, lname, email, password);

            Assert.False(a.ValidCust(a), "Customer Not Valid");
        }
    }
}
