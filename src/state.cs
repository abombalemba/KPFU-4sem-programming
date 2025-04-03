using System;

namespace Patterns {
	public class State {
		public State() {
			Car car;

			car = new Car();
			Console.WriteLine(car.GetState());

			car.Start();
			car.Start();

			car.Stop();
			car.Park();
			
			car.Start();
			car.Stop();
			car.Park();
		}

		public interface ICarState {
			void Start(Car car);
			void Stop(Car car);
			void Park(Car car);
		}

		public class StartedState : ICarState {
			public void Start(Car car) {
				if (car.GetState() is not StartedState) {
					car.SetState(new StartedState());
					Console.WriteLine("The car is started1");
				} else {
					Console.WriteLine("The car is already started");
				}
			}

			public void Stop(Car car) {
				car.SetState(new StoppedState());
				Console.WriteLine("The car is stopped1");
			}

			public void Park(Car car) {
				car.SetState(new ParkedState());
				Console.WriteLine("The car is parked1");
			}
		}

		public class StoppedState : ICarState {
			public void Start(Car car) {
				car.SetState(new StartedState());
				Console.WriteLine("The car is started2");
			}

			public void Stop(Car car) {
				if (car.GetState() is not StoppedState) {
					car.SetState(new StoppedState());
					Console.WriteLine("The car is stopped2");
				} else {
					Console.WriteLine("The car is already stopped");
				}
			}

			public void Park(Car car) {
				car.SetState(new ParkedState());
				Console.WriteLine("The car is parked2");
			}
		}

		public class ParkedState : ICarState {
			public void Start(Car car) {
				car.SetState(new StartedState());
				Console.WriteLine("The car is started3");
			}

			public void Stop(Car car) {
				car.SetState(new StoppedState());
				Console.WriteLine("The car is stopped3");
			}

			public void Park(Car car) {
				if (car.GetState() is not ParkedState) {
					car.SetState(new ParkedState());
					Console.WriteLine("The car is parked3");
				} else {
					Console.WriteLine("The car is already parked");
				}
			}
		}
		public class Car {
			private ICarState _state;

			public Car() {
				_state = new StoppedState();
            }

			public ICarState GetState() {
				return _state;
            }

			public void SetState(ICarState state) {
				_state = state;
            }

			public void Start() {
				_state.Start(this);
			}

			public void Stop() {
				_state.Stop(this);
			}

			public void Park() {
				_state.Park(this);
			}
		}
	}
}