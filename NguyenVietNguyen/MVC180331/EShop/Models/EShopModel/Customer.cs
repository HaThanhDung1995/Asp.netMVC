namespace EShop.Models
{
    using EShop.i18n;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
        [Required(ErrorMessageResourceName = "Id0", ErrorMessageResourceType = typeof(CustomerRex))]
        public string Id { get; set; }
        [Required(ErrorMessageResourceName = "Password0", ErrorMessageResourceType = typeof(CustomerRex))]
        [StringLength(int.MaxValue, MinimumLength=8, ErrorMessageResourceName = "Passwordmin", ErrorMessageResourceType = typeof(CustomerRex))]
        public string Password { get; set; }
        [Required(ErrorMessageResourceName = "Fullname0", ErrorMessageResourceType = typeof(CustomerRex))]
        public string Fullname { get; set; }
        [Required(ErrorMessageResourceName = "Email0", ErrorMessageResourceType = typeof(CustomerRex))]
        [EmailAddress(ErrorMessageResourceName="Email", ErrorMessageResourceType=typeof(CustomerRex))]
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool Activated { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
