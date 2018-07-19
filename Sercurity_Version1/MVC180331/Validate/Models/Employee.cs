using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validate.Attrs;

namespace Validate.Models
{
    public class Employee
    {
        [StringLength(int.MaxValue, MinimumLength=5, ErrorMessage="Ít nhất 5 ký tự!")]
        public string Name { get; set; }
        [Required(ErrorMessage="Không để trống tuổi")]
        [Range(16, 56, ErrorMessage="Từ 16 đến 65!")]
        [EvenNumber(ErrorMessage="Phải là số chẵn!")]
        public int Age { get; set; }
    }
}