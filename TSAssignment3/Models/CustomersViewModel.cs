using Invoice.Data.Entities;

namespace TSAssignment3.Models
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }

        public string ActivePage { get; set; } = "A-E";
    }
}
