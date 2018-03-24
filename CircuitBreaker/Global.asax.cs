using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;

namespace CircuitBreaker
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			SetupDependencyInjection();
		}

		private void SetupDependencyInjection()
		{
			var builder = new ContainerBuilder();

			builder.RegisterCiruitBreakerTypes();

			var container = builder.Build();
			var config = GlobalConfiguration.Configuration;
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

	}
}
