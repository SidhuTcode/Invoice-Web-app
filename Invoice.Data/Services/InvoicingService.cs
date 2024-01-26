using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Services
{
    public interface InvoicingService
    {
        public List<Customer>? GetCustomersFromTo(string filterFrom = "A", string filterTo = "Z");

        public Customer? GetCustomerById(int customerId);

        public void UpdateCustomerIsdeleted(Customer customer);

        public Customer? EditCustomer(Customer customer);

        public Customer? AddCustomer(Customer customer);
    }
}
