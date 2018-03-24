using System;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using CircuitBreaker.Controllers;
using FinanceService;
using Polly;

namespace CircuitBreaker
{
	public static class DependencyInjectionExtensions
	{
		public static void RegisterCiruitBreakerTypes(this ContainerBuilder builder)
		{
			builder.RegisterApiControllers(WebApiAssembly());

			builder.RegisterType<ZooService>().As<IZooService>();
			var retryPolicy = Policy
				.Handle<NotImplementedException>()
				.WaitAndRetry(new[]
				{
					TimeSpan.FromSeconds(1),
					TimeSpan.FromSeconds(5),
					TimeSpan.FromSeconds(10)
				}, (exception, timeSpan, retryCount, context) => {
					System.Diagnostics.Debug.WriteLine($"Retry #{retryCount}, timeSpan: {timeSpan}"); 
				});

			builder.RegisterInstance(retryPolicy).As<Policy>();
		}

		private static Assembly WebApiAssembly() => typeof(AnimalController).Assembly;
	}
}