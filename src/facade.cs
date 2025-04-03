using System;

namespace Patterns {
	public class Facade {
		public Facade() {
			CarFacade car;

			car = new CarFacade();
			car.Drive();
			Console.WriteLine();
			car.Park();
		}

		public class Car {
			public void StartEngine() {
				Console.WriteLine("The engine is started");
            }

			public void StopEngine() {
				Console.WriteLine("The engine is stopped");
            }

			public void ShiftGear(int n) {
				Console.WriteLine(string.Format("Switching to {0} gear", n));
            }

			public void StartConditioner() {
				Console.WriteLine("The air conditioner is started");
			}

			public void StopConditioner() {
				Console.WriteLine("The air conditioner is stopped");
			}
		}

		public class CarFacade : Car {
			private Car _car;

			public CarFacade() {
				_car = new Car();
            }

			public void Drive() {
				_car.StartEngine();
				_car.ShiftGear(1);
				_car.StartConditioner();
            }

			public void Park() {
				_car.StopEngine();
				_car.ShiftGear(0);
				_car.StopConditioner();
            }
        }
	}
}