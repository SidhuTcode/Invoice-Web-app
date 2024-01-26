using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "You are missing business Name?")]

        public string? Name { get; set; } = null!;

        [Required(ErrorMessage = "You are missing the address?")]

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        [Required(ErrorMessage = "You are missing city Name?")]

        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "You are missing province or State Name?")]

        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "You are missing ZipCode or Postal Code Name?")]

        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "You are missing your Course Name?")]

        public string? Phone { get; set; }

        [Required(ErrorMessage = "You are missing contact last Name?")]

        public string? ContactLastName { get; set; }

        [Required(ErrorMessage = "You are missing contact first Name?")]

        public string? ContactFirstName { get; set; }

        public string? ContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<Invoices>? Invoices { get; set; }
    }
}
