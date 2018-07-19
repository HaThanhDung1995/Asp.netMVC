using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF1.Models.MVC5
{
    public class MvcContext:DbContext
    {
        public MvcContext() : base("name=MVC5") {  }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}