using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF1.Models.MVC5
{
    public class Type
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}