using EF1.Models.MVC5;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF.Models.MVC5
{
    public class Mvc5DbInitializer: DropCreateDatabaseIfModelChanges<MvcContext>
    {
        protected override void Seed(MvcContext dbc)
        {
            dbc.Types.Add(new EF1.Models.MVC5.Type { Name = "Mobile" });
            dbc.Types.Add(new EF1.Models.MVC5.Type { Name = "Laptop" });
            dbc.Types.Add(new EF1.Models.MVC5.Type { Name = "Camera" });
            dbc.SaveChanges();
        }
    }
}