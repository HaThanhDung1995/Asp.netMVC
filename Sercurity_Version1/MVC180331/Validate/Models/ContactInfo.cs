using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validate.Models
{
    public class ContactInfo
    {
        [EmailAddress]
        public String Email { get; set; }
        [Compare("Email")]
        public String ConfirmEmail { get; set; }
        [RegularExpression(@"5\d-[A-Z]\d-((\d{4})|(\d{3}\.\d{2}))")]
        public String Moto { get; set; }
        [CreditCard]
        public String CreditCard { get; set; }
        [StringLength(255)]
        public String Notes { get; set; }
    }
}