using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyController2.Models
{
    public class Mail
    {
        public String From { get; set; }
        public String To { get; set; }
        public String Subject { get; set; }
        public String Body { get; set; }
    }
}