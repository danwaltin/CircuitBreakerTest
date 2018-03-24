using System.Collections.Generic;
using Dto;

namespace FinanceService
{
	public interface IZooService
	{
		IEnumerable<Animal> ListAnimals();
	}
}
