using Invoice.Data.Entities;
using Invoice.Data.Services;
using Microsoft.AspNetCore.Mvc;
using TSAssignment3.Models;

namespace TSAssignment3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly InvoicingService _invoicingServices;

        public CustomerController(InvoicingService invoicingServices)
        {
            _invoicingServices = invoicingServices;
        }

        [HttpGet("/customers/{filterFrom}-{filterTo}")]

        public IActionResult List(string filterFrom, string filterTo)
        {
            var customers = _invoicingServices.GetCustomersFromTo(filterFrom, filterTo);

            var customerViewModel = new CustomersViewModel()
            {
                Customers = customers,
                ActivePage = $"{filterFrom}-{filterTo}",
            };
            return View(customerViewModel);
        }

        [HttpGet("/customers/add")]
        public IActionResult Add()
        {
            var customer = new Customer();

            var customerViewModel = new CustomerViewModel()
            {
                Customer = customer
            };
            return View(customerViewModel);
        }

        [HttpPost("/customers/add")]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);




            _invoicingServices.AddCustomer(customerViewModel.Customer);


            TempData["Message"] = $"{customerViewModel.Customer.Name} added successfully";
            TempData["ClassName"] = "success";

            return RedirectToAction("List", new { filterFrom = "A", filterTo = "E" });
        }

        [HttpGet("/customers/{customerId:int}/edit")]
        public IActionResult Edit(int customerId)
        {
            var customer = _invoicingServices.GetCustomerById(customerId);

            if (customer == null) return NotFound();

            var customerViewModel = new CustomerViewModel()
            {
                Customer = customer
            };
            return View(customerViewModel);
        }

        [HttpPost("/customers/{customerId:int}/edit")]
        public IActionResult Edit(int customerId, CustomerViewModel customerViewModel)
        {

            var customer = _invoicingServices.GetCustomerById(customerId);


            if (!ModelState.IsValid) return View(customerViewModel);

            _invoicingServices.EditCustomer(customer);

            return RedirectToAction("List", new { filterFrom = "A", filterTo = "E" });
        }

        [HttpGet("/customers/{customerId:int}/delete")]
        public IActionResult Delete(int customerId)
        {
            var customer = _invoicingServices.GetCustomerById(customerId);

            if (customer == null) return NotFound();

            _invoicingServices.UpdateCustomerIsdeleted(customer);

            TempData["Message"] = $"{customer.Name} is deleted ";
            TempData["ClassName"] = "danger";
            TempData["CustomerId"] = customer.CustomerId;

            return RedirectToAction("List", new { filterFrom = "A", filterTo = "E" });


        }

        [HttpGet("/customers/{customerId:int}/undo-delete")]
        public IActionResult UndoDelete(int customerId)
        {
            var customer = _invoicingServices.GetCustomerById(customerId);

            if (customer == null) return NotFound();

            _invoicingServices.UpdateCustomerIsdeleted(customer);

            TempData["Message"] = $"{customer.Name} is restored ";
            TempData["ClassName"] = "success";


            return RedirectToAction("List", new { filterFrom = "A", filterTo = "E" });
        }
        public IActionResult InvoiceDetails(InvoiceViewModel invoiceViewModel)
        {
            return View();
        }
    }
}
