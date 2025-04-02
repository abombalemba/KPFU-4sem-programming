using System;

namespace KPFU_4_sem_programming {
    class Program {
        static void Main(string[] args) {
            Car car;

            car = new Car("Lada Aura");
            car.info();

            car = new CarSpoiler(car);
            car.info();

            car = new CarSpareWheel(car);
            car.info();

            car = new Car("Hyundai Accent");
            car.info();

            car = new CarSpareWheel(car);
            car.info();
        }
    }

    public class Car {
        public string Model { get; set; }
        public virtual string[] Upgrades { get; set; }

        public Car(string model) {
            Model = model;
            Upgrades = new string[0];
        }

        public void info() {
            Console.WriteLine("> ", this.Model);

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
        public CarDecorator(Car car) : base(car.Model) {
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
