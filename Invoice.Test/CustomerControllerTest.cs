using Invoice.Data.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TSAssignment3.Controllers;
using TSAssignment3.Models;

namespace Invoice.Test
{
    public class CustomerControllerTest
    {
        private readonly Mock<InvoicingService> _mockInvoicingService = new Mock<InvoicingService>();

        private readonly Mock<ITempDataDictionary> _tempData = new Mock<ITempDataDictionary>();

        [Fact]
        public void Add_GET_ReturnsViewResult()
        {
            // Arrange 

            var controller = new CustomerController(_mockInvoicingService.Object);
            // Act

            var result = controller.Add();

            //Assert

            Assert.IsType<ViewResult>(result);
        }

        [Fact]

        public void List_GET_ReturnsCustomersViewModel()
        {
            // Arrange 
            var customers = new List<Customer>
            {
                new Customer {CustomerId = 1 , Name = "Alex" , IsDeleted = false},
                new Customer {CustomerId = 2 , Name = "Binder" , IsDeleted = false},

            };

            _mockInvoicingService.Setup(invoicingService => invoicingService.GetCustomersFromTo(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(customers);

            var contoller = new CustomerController(_mockInvoicingService.Object);
            // Act

            var result = contoller.List("A", "B") as ViewResult;
            var viewModel = result?.Model as CustomersViewModel;

            //Assert

            Assert.NotNull(viewModel);
            Assert.Equal(customers, viewModel?.Customers);

        }

        [Fact]

        public void Edit_GET_ReturnsNotFoundResult_WhenCustomerDoesNotExist()
        {
            // Arrange


            _mockInvoicingService.Setup(invoicingService => invoicingService.GetCustomerById(It.IsAny<int>())).
                Returns((Customer)null);

            var controller = new CustomerController(_mockInvoicingService.Object);
            // Act

            var result = controller.Edit(1);
            //Assert

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]

        public void Delete_GET_ReturnsRedirectToActionResult()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "Alex", IsDeleted = false };

            _mockInvoicingService.Setup(invoicingService => invoicingService.GetCustomerById(1))
                .Returns(customer);

            _mockInvoicingService.Setup(invoicingService => invoicingService.UpdateCustomerIsdeleted(customer))
                .Verifiable();
            var controller = new CustomerController(_mockInvoicingService.Object)
            {
                TempData = _tempData.Object
            };
            // Act

            var result = controller.Delete(1);
            //Assert

            Assert.IsType<RedirectToActionResult>(result);

        }

        [Fact]
        public void UndoDelete_GET_ReturnsRedirectToActionResult()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "Alex", IsDeleted = false };

            _mockInvoicingService.Setup(invoicingService => invoicingService.GetCustomerById(1))
                .Returns(customer);

            _mockInvoicingService.Setup(invoicingService => invoicingService.UpdateCustomerIsdeleted(customer))
                .Verifiable();
            var controller = new CustomerController(_mockInvoicingService.Object)
            {
                TempData = _tempData.Object
            };
            // Act

            var result = controller.UndoDelete(1);
            //Assert

            Assert.IsType<RedirectToActionResult>(result);

        }
    }
}