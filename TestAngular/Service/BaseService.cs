using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service
{
    public class BaseService
    {
        protected DbContext Db { get; }

        public BaseService(DataContext dbContext)
        {
            Db = dbContext;
        }
    }
}
