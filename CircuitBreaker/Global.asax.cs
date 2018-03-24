﻿using System.Web.Http;
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
