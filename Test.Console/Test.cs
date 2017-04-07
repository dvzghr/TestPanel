using System.Diagnostics;

namespace Test.Console
{
    class Vehicle   
    {
        public byte Wheels { get; set; }
    }

    class Car: Vehicle
    {
        public string Type { get; set; }
    }

    class GarageGeneric<T> where T : Vehicle
    {
        public T Vehicle { get; set; }
    }

    class GarageNonGeneric
    {
        public Vehicle Vehicle { get; set; }

        public Car Car { get; set; }

        public GarageNonGeneric(Vehicle vehicle, Car car)
        {
            Vehicle = vehicle;
            Car = car;
        }
    }


    static class Test
    {
        public static void Start()
        {
            var veh = new Vehicle { Wheels = 4};
            var car = new Car { Type = "It's a car!"};
            Car castCar = null;
               
            //GENERIC
            var vehGarage = new GarageGeneric<Vehicle>();
            vehGarage.Vehicle = new Vehicle();
            System.Console.WriteLine(vehGarage.Vehicle);
            //castCar = (Car) vehGarage.Vehicle;
            //System.Console.WriteLine(castCar.Type);

            vehGarage.Vehicle = new Car();
            System.Console.WriteLine(vehGarage.Vehicle);
            //castCar = (Car)vehGarage.Vehicle;
            //System.Console.WriteLine(castCar.Type);


            var carGarage = new GarageGeneric<Car>();
            //carGarage.Vehicle = (Car) veh;
            System.Console.WriteLine(carGarage.Vehicle);
            castCar = carGarage.Vehicle;
            System.Console.WriteLine(castCar.Type);

            carGarage.Vehicle = car;
            carGarage.Vehicle.Type = "car";

            //NONGENERIC

            var vehGarage2 = new GarageNonGeneric(veh, car);
            System.Console.WriteLine(vehGarage2.Vehicle);
            //castCar = (Car) vehGarage2.Vehicle;
            //System.Console.WriteLine(castCar.Type);
            System.Console.WriteLine(vehGarage2.Car.Type);
        }

    }
}
