using System.Collections.Generic;
using Dto;

namespace FinanceService
{
    public class ZooService : IZooService
    {
	    public IEnumerable<Animal> ListAnimals()
	    {
		    return new List<Animal>
		    {
			    new Animal { Species = "Dog", Name = "Fido" },
			    new Animal { Species = "Cat", Name = "Pelle" }
		    };
		}
	}
}
