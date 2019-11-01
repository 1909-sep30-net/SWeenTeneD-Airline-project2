using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IRepo
    {
        public string CreateCustomer(Customer customer);
        public List<Customer> ReadCustomerList(Customer customer);
        public string UpdateCustomer(Customer customer);
        public string DeleteCustomer(Customer customer);
    }
}
