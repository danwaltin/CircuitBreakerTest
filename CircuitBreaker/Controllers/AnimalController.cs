using System.Collections.Generic;
using System.Web.Http;
using Dto;
using FinanceService;

namespace CircuitBreaker.Controllers
{
	public class AnimalController : ApiController
	{
		private readonly IZooService _zooService;

		public AnimalController(IZooService zooService)
		{
			_zooService = zooService;
		}

		public IEnumerable<Animal> Get()
		{
			return _zooService.ListAnimals();
		}
	}
}