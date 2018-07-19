using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinQ.Models
{
    public class Report
    {
        public string Category { get; set; }

        public int Count { get; set; }

        public double Value { get; set; }

        public double MinPrice { get; set; }

        public double AvgPrice { get; set; }

        public double MaxPrice { get; set; }
    }
}