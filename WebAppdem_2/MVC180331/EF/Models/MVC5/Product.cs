using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF1.Models.MVC5
{
    public class Item
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int TypeId { get; set; }

        //Navigation Properties
        public virtual Type Type { get; set; }
    }
}