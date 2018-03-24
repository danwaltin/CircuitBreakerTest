using System.Web.Http;
using FinanceService;

namespace CircuitBreaker.Controllers
{
	public class ServiceHealthController : ApiController
	{
		[HttpGet]
		public ServiceHealth ShowServiceHealth()
		{
			return ZooService.Health;
		}

		[HttpPost]
		public void SetServiceHealth(ServiceHealth health)
		{
			ZooService.Health = health;
		}
	}
}