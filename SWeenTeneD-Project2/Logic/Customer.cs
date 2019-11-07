using System.ComponentModel.DataAnnotations.Schema;

namespace Logic
{
    public class Customer
    {
        //PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Customer(){}

        public Customer(int customerId, string fname, string lname, string mail, string pw)
        {
            CustomerID = customerId;
            FirstName = fname;
            LastName = lname;
            Email = mail;
            Password = pw;
        }
    }
}
