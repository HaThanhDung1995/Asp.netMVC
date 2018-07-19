using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinQ.Models
{
    public class ReportInfo
    {
        public int Group { get; set; }

        public int Count { get; set; }

        public int Sum { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public double Avg { get; set; }
    }
}