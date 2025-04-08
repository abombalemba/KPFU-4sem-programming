using System;

namespace Patterns {
    public class Decorator {
        public Decorator() {
            Car car;

            car = new Car();
            car.info();

            car = new CarSpoiler(car);
            car.info();

            car = new CarSpareWheel(car);
            car.info();

            car = new Car();
            car.info();

            car = new CarSpareWheel(car);
            car.info();
        }

        public class Car {
            public virtual string[] Upgrades { get; set; }

            public Car() {
                Upgrades = new string[0];
            }

            public void info() {
                if (this.Upgrades.Length > 0) {
                    Console.WriteLine("Upgrades:");

                    foreach (string upgrade in this.Upgrades) {
                        Console.WriteLine(">> " + upgrade);
                    }
                } else {
                    Console.WriteLine("Upgrades are not exist");
                }

                Console.Write("\n\n\n");
            }
        }

        public abstract class CarDecorator : Car {
            protected Car _car;
            public CarDecorator(Car car) : base() {
                _car = car;
            }

            protected abstract string[] GetNewUpgrades();

            public override string[] Upgrades {
                get {
                    return CombineUpgrades(_car.Upgrades, GetNewUpgrades());
                }
            }

            private string[] CombineUpgrades(string[] existnigUpgrades, string[] newUpgrades) {
                string[] combined = new string[existnigUpgrades.Length + newUpgrades.Length];

                existnigUpgrades.CopyTo(combined, 0);
                newUpgrades.CopyTo(combined, existnigUpgrades.Length);

                return combined;
            }
        }

        public class CarSpoiler : CarDecorator {
            public CarSpoiler(Car car) : base(car) { }

            protected override string[] GetNewUpgrades() {
                return new string[] { "Spoiler" };
            }
        }

        public class CarSpareWheel : CarDecorator {
            public CarSpareWheel(Car car) : base(car) { }

            protected override string[] GetNewUpgrades() {
                return new string[] { "SpareWheel" };
            }
        }
    }
}