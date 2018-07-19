using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Entity;

namespace Demo.Service
{
    public class BaseService
    {
        //Khai báo db, tất cả các service phải kế thừa BaseService này
        protected DbContext Db { get; }

        public BaseService(DemoContext dbContext)
        {
            Db = dbContext;
        }
    }
}
