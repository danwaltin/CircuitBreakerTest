using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using CircuitBreaker.Controllers;
using FinanceService;

namespace CircuitBreaker
{
	public static class DependencyInjectionExtensions
	{
		public static void RegisterCiruitBreakerTypes(this ContainerBuilder builder)
		{
			builder.RegisterApiControllers(WebApiAssembly());

			builder.RegisterType<ZooService>().As<IZooService>();
		}
		private static Assembly WebApiAssembly() => typeof(AnimalController).Assembly;
	}
}