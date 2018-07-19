using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.Entity;
using Demo.Model;
using Demo.WebApplication.Models;

namespace Demo.WebApplication
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Mapping student vs StudentModel và ngược lại
                cfg.CreateMap<student, StudentModel>();
                cfg.CreateMap<StudentModel, student>();
                cfg.CreateMap<StudentModel, StudentViewModel>().ReverseMap();
            });
        }
    }
}