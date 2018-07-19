using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucMinh.Models
{
    public class SubProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Category { get; set; }

        public int Supplier { get; set; }
    }
}