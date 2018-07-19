using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountLogin.Models
{
    public class Report
    {
        public string Category { get; internal set; }
        public int Count { get; internal set; }
        public double Sum { get; internal set; }
        public double MinPrice { get; internal set; }
        public double MaxPrice { get; internal set; }
        public double AvgPrice { get; internal set; }
    }
}