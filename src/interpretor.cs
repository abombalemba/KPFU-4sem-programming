using System;
using System.Collections.Generic;

namespace Patterns {
	public class Interpretor {
		public Interpretor() {
			CarInterpretor car;

			car = new CarInterpretor();
			car.Interpret("start engine");
			car.Interpret("start fuel system");
			car.Interpret("start onboard computer");
			car.Interpret("shift 1");
			car.Interpret("shift 2");
			car.Interpret("shift 3");


			car.Interpret("shift 0");
			car.Interpret("stop engine");
			car.Interpret("stop fuel system");
			car.Interpret("stop onboard computer");
		}

		public interface IExpression {
			void Interpret();
		}

		public class StartEngine : IExpression {
			public void Interpret() {
				Console.WriteLine("The engine is started");
			}
		}

		public class StopEngine : IExpression {
			public void Interpret() {
				Console.WriteLine("The engine is stopped");
			}
		}

		public class StartFuelSystem : IExpression {
			public void Interpret() {
				Console.WriteLine("The fuel system is started");
			}
		}

		public class StopFuelSystem : IExpression {
			public void Interpret() {
				Console.WriteLine("The fuel system is stopped");
			}
		}
		public class StartOnboardComputer : IExpression {
			public void Interpret() {
				Console.WriteLine("The onboard computer is started");
			}
		}

		public class StopOnboardComputer : IExpression {
			public void Interpret() {
				Console.WriteLine("The onboard computer is stopped");
			}
		}

		public class ShiftGear : IExpression {
			private string _gear;

			public ShiftGear(string gear) {
				_gear = gear;
            }

			public void Interpret() {
				Console.WriteLine(string.Format("Switched to {0} gear", _gear));
			}
		}

		public class CarInterpretor {
			private Dictionary<string, IExpression> _dictionary;

			public CarInterpretor() {
				_dictionary = new Dictionary<string, IExpression> {
					{"start engine", new StartEngine() },
					{"stop engine", new StopEngine() },
					{"start fuel system", new StartFuelSystem() },
					{"stop fuel system", new StopFuelSystem() },
					{"start onboard computer", new StartOnboardComputer() },
					{"stop onboard computer", new StopOnboardComputer() },
				};
            }

			public void Interpret(string command) {
				var parts = command.Split(" ");

				if (parts.Length < 2) {
					return;
                }

				if (parts[0] == "shift") {
					ShiftGear shiftGear = new ShiftGear(parts[1]);
					shiftGear.Interpret();
				} else if (_dictionary.ContainsKey(command)) {
					_dictionary[command].Interpret();
                } else {
					Console.WriteLine("Unknown command");
                }
            }
		}
	}
}