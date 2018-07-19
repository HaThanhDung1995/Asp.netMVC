using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Entity;
using Interface;
using Model;

namespace Service
{
    public class SupplierService:BaseService,ISupplierService
    {
        private readonly DbSet<Supplier> _dbsuppliers;
        public SupplierService(DataContext dbContext) : base(dbContext)
        {
            _dbsuppliers = Db.Set<Supplier>();
        }

        public List<SupplierModel> ListSupplier()
        {
            var listsupplier = _dbsuppliers.AsNoTracking().ProjectTo<SupplierModel>().ToList();


            return listsupplier;
        }
    }
}
