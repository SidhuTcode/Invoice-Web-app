using Invoice.Data.Entities;
using Invoice.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test
{
    public class InvoicingServiceTests
    {
        [Theory]
        [InlineData(1)]

        public void UpdateCustomerIsdeleted_SetsIsDeletedToTrue(int customerId)
        {
            // Arrange 

            var options = new DbContextOptionsBuilder<InvoicingDbContext>()
                .UseInMemoryDatabase(databaseName: "InvoicingTestsDb")
                .Options;
            var invoicingDbcontext = new InvoicingDbContext(options);
            var invoicingService = new InvoicingServices(invoicingDbcontext);

            var customer = new Customer()
            {


                CustomerId = 1,
                Name = "US Postal Service",
                Address1 = "Attn:  Supt. Window Services",
                Address2 = "PO Box 7005",
                City = "Madison",
                ProvinceOrState = "WI",
                ZipOrPostalCode = "53707",
                Phone = "800-555-1205",
                ContactFirstName = "Alberto",
                ContactLastName = "Francesco"

            };
            invoicingDbcontext.Customers.Add(customer);
            invoicingDbcontext.SaveChanges();

            // Act

            customer = invoicingService.GetCustomerById(customerId);
            invoicingService.UpdateCustomerIsdeleted(customer);

            //Assert
            Assert.True(customer.IsDeleted);

        }

    }
}
