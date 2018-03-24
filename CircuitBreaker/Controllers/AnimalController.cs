using System.Collections.Generic;
using System.Web.Http;
using Dto;
using FinanceService;
using Polly;

namespace CircuitBreaker.Controllers
{
	public class AnimalController : ApiController
	{
		private readonly IZooService _zooService;
		private readonly Policy _policy;

		public AnimalController(IZooService zooService, Policy policy)
		{
			_zooService = zooService;
			_policy = policy;
		}

		public IEnumerable<Animal> Get()
		{
			return _policy.Execute(() => _zooService.ListAnimals());
		}
	}
}