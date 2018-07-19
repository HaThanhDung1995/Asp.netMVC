using System.Web.Mvc;
using Demo.Entity;
using Demo.Interface;
using Demo.Service;
using Unity;
using Unity.Mvc5;

namespace Demo.WebApplication
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
            container.RegisterInstance(new DemoContext());

            //Mapping interface vs service
            container.RegisterType<IStudentService, StudentService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}