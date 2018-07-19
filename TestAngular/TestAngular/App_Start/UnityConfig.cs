using System.Web.Mvc;
using Entity;
using Interface;
using Service;
using Unity;
using Unity.Mvc5;

namespace TestAngular
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Mapping entity
            
            container.RegisterInstance(new DataContext());

            //Mapping interface vs service
            container.RegisterType<ISupplierService, SupplierService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}