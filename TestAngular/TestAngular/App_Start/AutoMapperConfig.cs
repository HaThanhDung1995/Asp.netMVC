using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Model;
using TestAngular.Models;

namespace TestAngular
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Mapping student vs StudentModel và ngược lại
                cfg.CreateMap<Supplier, SupplierModel>();
                cfg.CreateMap<SupplierModel, Supplier>();
                cfg.CreateMap<SupplierModel, SupplierViewModel>().ReverseMap();
            });
        }
    }
}