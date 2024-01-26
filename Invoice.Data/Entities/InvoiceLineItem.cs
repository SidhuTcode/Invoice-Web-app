using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }

        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid amount.")]
        public double? Amount { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]

        public string? Description { get; set; }

        // FK:
        public int? InvoiceId { get; set; }

        public Invoices? Invoice { get; set; }
    }
}
