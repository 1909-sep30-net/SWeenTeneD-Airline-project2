using System;
using System.Collections.Generic;
using System.Text;

namespace SWeenTeneD_Project2
{
    public class Customer
    {
        //PK
        public int CustomerID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Customer() { }

        public Customer(string fname, string lname, string mail, string pw)
        {
            FirstName = fname;
            LastName = lname;
            Email = mail;
            Password = pw;
        }

        public bool ValidCust(Customer c)
        {
            if (c.FirstName != null && c.LastName != null && c.Email != null && c.Password != null)
                return true;
            else
                return false;
        }
    }
}
