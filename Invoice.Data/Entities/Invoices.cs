using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Invoices
    {
        [Key]
        public int InvoiceId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceDueDate
        {
            get
            {
                return InvoiceDate?.AddDays(Convert.ToDouble(PaymentTerms?.DueDays));
            }
        }

        public double? PaymentTotal { get; set; } = 0.0;

        public DateTime? PaymentDate { get; set; }

        // FK:
        public int PaymentTermsId { get; set; }

        public PaymentTerms PaymentTerms { get; set; }

        // FK:
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<InvoiceLineItem> InvoiceLineItems { get; set; }

    }
}
