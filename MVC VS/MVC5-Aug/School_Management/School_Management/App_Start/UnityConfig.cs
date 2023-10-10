using School_Management.Repository.Repository;
using School_Management.Repository.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace School_Management
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserInterface, UserServices>();
            container.RegisterType<ICountryInterface, CountryServices>();
            container.RegisterType<IStateInterface, StateServices>();
            container.RegisterType<ICityInterface, CityServices>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}