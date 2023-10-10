using System.Web.Mvc;
using Test.Repository.Repository;
using Test.Repository.Services;
using Unity;
using Unity.Mvc5;

namespace Kirtan_375_Test
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ILogin, LoginService>();

            container.RegisterType<IOrder, OrderService>();

            container.RegisterType<IItems, ItemService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}