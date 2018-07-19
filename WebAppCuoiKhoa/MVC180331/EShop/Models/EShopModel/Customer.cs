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
        [Required(ErrorMessage = "Không để trống mã")]
        public string Id { get; set; }
        [StringLength(int.MaxValue, MinimumLength=6, ErrorMessage = "Ít nhất 6 ký tự")]
        public string Password { get; set; }
        [Required(ErrorMessage="Không để trống họ và tên")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Không để trống địa chỉ email")]
        [EmailAddress(ErrorMessageResourceName="Email", ErrorMessageResourceType=typeof(CustomerRex))]
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool Activated { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
