using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazorNHelper.Models
{
    public class Student
    {
        [DisplayName("Mã sinh viên")]
        public String Id { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.MultilineText)]
        public String Notes { get; set; }
    }
}