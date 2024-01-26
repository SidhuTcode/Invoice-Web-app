using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Services
{
    public class InvoicingServices : InvoicingService
    {
        private readonly InvoicingDbContext _invoicingDbContext;

        public InvoicingServices(InvoicingDbContext invoicingDbContext)
        {
            _invoicingDbContext = invoicingDbContext;
        }
        public List<Customer> GetCustomersFromTo(string filterFrom = "A", string filterTo = "Z")
        {
            return _invoicingDbContext.Customers
                .Where(customer =>
                string.Compare(customer.Name, filterFrom) >= 0 &&
                string.Compare(customer.Name, filterTo) <= 0 && customer.IsDeleted == false
                )
                .ToList();
        }
        public Customer? GetCustomerById(int customerId)
        {
            return _invoicingDbContext.Customers
                .FirstOrDefault(customers => customers.CustomerId == customerId);
        }
        public void UpdateCustomerIsdeleted(Customer customer)
        {
            customer.IsDeleted = !customer.IsDeleted;

            _invoicingDbContext.SaveChanges();
        }

        public Customer? EditCustomer(Customer customer)
        {

            _invoicingDbContext.Customers.Update(customer);
            _invoicingDbContext.SaveChanges();
            return customer;
        }

        public Customer? AddCustomer(Customer customer)
        {
            _invoicingDbContext.Customers.Add(customer);
            _invoicingDbContext.SaveChanges();
            return customer;
        }

    }
}
