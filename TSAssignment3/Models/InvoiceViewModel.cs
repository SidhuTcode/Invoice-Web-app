using Invoice.Data.Entities;

namespace TSAssignment3.Models
{
    public class InvoiceViewModel
    {
        public Invoices? Invoice { get; set; }
        public List<InvoiceLineItem>? LineItems { get; set; }

    }
}
