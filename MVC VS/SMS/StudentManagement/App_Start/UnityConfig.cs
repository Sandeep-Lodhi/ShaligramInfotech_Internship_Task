using StudentManagement.Repositories.Repositories;
using StudentManagement.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StudentManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IAuthInterface, AuthService>();
            container.RegisterType<IStudentInterface, StudentService>();
            container.RegisterType<IUserRoleInterface, UserRoleService>();
            container.RegisterType<IUserInterface, UserService>();
            container.RegisterType<IStandardInterface, StandardService>();
            container.RegisterType<ICountryInterface, CountryService > ();
            container.RegisterType<IStateInterface, StateService>();



            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}