using System;
using System.Collections.Generic;
using System.Threading;
using Dto;

namespace FinanceService
{
	public enum ServiceHealth
	{
		Alive,
		Slow,
		Crashed
	}

	public class ZooService : IZooService
	{
		public static ServiceHealth Health = ServiceHealth.Alive;

		public IEnumerable<Animal> ListAnimals()
		{
			CheckHealth();

			return new List<Animal> {
				new Animal { Species = "Dog", Name = "Fido" },
				new Animal { Species = "Cat", Name = "Pelle" }
			};
		}

		private void CheckHealth()
		{
			switch (Health)
			{
				case ServiceHealth.Alive:
					break;
				case ServiceHealth.Slow:
					Thread.Sleep(30 * 1000);
					break;
				case ServiceHealth.Crashed:
					throw new NotImplementedException("Oops!");
				default:
					throw new ArgumentException($"Status '{Health}' not allowed");
			}
		}
	}
}
