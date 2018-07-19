using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Areas.Admin.Models
{
    public class Report
    {
        public string Group { get; set; }

        public int Quantity { get; set; }

        public double Value { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }

        public double AvgPrice { get; set; }
    }
}