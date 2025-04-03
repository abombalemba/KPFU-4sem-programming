using System;
using System.Collections.Generic;

namespace Patterns {
	public class Interpretor {
		public Interpretor() {
			CarInterpretor car;

			car = new CarInterpretor();
			car.Interpret("start engine");
			car.Interpret("start conditioner");
			car.Interpret("shift 1");
			car.Interpret("shift 2");
			car.Interpret("shift 3");


			car.Interpret("shift 0");
			car.Interpret("stop conditioner");
			car.Interpret("stop engine");
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

		public class StartCondition : IExpression {
			public void Interpret() {
				Console.WriteLine("The condition is started");
			}
		}

		public class StopCondition : IExpression {
			public void Interpret() {
				Console.WriteLine("The condition is stopped");
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
					{"start conditioner", new StartCondition() },
					{"stop conditioner", new StopCondition() }
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