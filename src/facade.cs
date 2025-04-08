using System;

namespace Patterns {
	public class Facade {
		public Facade() {
			CarFacade car;

			car = new CarFacade();

			car.Drive();
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

			public void StartFuelSystem() {
				Console.WriteLine("The fuel system is started");
			}

			public void StopFuelSystem() {
				Console.WriteLine("The fuel system is stopped");
			}
			
			public void StartOnboardComputer() {
				Console.WriteLine("The onboard computer is started");
			}

			public void StopOnboardComputer() {
				Console.WriteLine("The onboard computer is stopped");
			}
		}

		public class CarFacade : Car {
			private Car _car;

			public CarFacade() {
				_car = new Car();
            }

			public void Drive() {
				_car.StartFuelSystem();
				_car.StartEngine();
				_car.StartOnboardComputer();
				_car.ShiftGear(1);
				_car.ShiftGear(2);
				_car.ShiftGear(3);
				_car.ShiftGear(4);
				_car.ShiftGear(5);
            }

			public void Park() {
				_car.StopFuelSystem();
				_car.StopEngine();
				_car.StopOnboardComputer();
				_car.ShiftGear(0);
            }
        }
	}
}