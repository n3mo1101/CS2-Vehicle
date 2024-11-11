using System;

namespace Vehicle_Version_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Car car = new Car(1, "Toyota", "Camry", 15.0F, 4, true);
                Motorcycle motorcycle = new Motorcycle(2, "Yamaha", "R1", 20.0F, 1000, true);
                Truck truck = new Truck(3, "Ford", "F-150", 8.0F, 5.0F, true);

                float distance = 150.0F; 
                float cargoWeight = 3.0F;

                Console.WriteLine("Fuel Consumption Calculation:");

                Console.WriteLine($"Car (ID: {car.VehicleId}, Model: {car.Make} {car.Model}) for {distance} km: {car.CalculateFuelConsumption(distance):F2} liters");
                Console.WriteLine($"Motorcycle (ID: {motorcycle.VehicleId}, Model: {motorcycle.Make} {motorcycle.Model}) for {distance} km: {motorcycle.CalculateFuelConsumption(distance):F2} liters");
                Console.WriteLine($"Truck (ID: {truck.VehicleId}, Model: {truck.Make} {truck.Model}) for {distance} km with {cargoWeight} tons cargo: {truck.CalculateFuelConsumption(distance, cargoWeight):F2} liters");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Argument Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.ReadKey();
        }
    }

    class Vehicle 
    { 
        private int _vehicleId;
        private float _fuelEfficiency;

        public int VehicleId
        {
            get => _vehicleId;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("Error: Vehicle ID cannot be negative");
                _vehicleId = value;
            }
        }

        public string Make { get; protected set; }
        public string Model { get; protected set; }

        public float FuelEfficiency
        {
            get => _fuelEfficiency;
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("Error: Fuel efficiency cannot be negative.");
                _fuelEfficiency = value;
            }
        }

        public Vehicle(int vehicleId, string make, string model, float fuelEfficiency)
        {
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            FuelEfficiency = fuelEfficiency;
        }
    }

    class Car : Vehicle
    {
        private int _numDoors;
        private bool _isAutomatic;

        public int NumDoors
        {
            get => _numDoors;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error: Number of doors cannot be negative");
                _numDoors = value;
            }
        }

        public bool IsAutomatic
        {
            get => _isAutomatic;
            set => _isAutomatic = value;
        }

        public Car(int vehicleId, string make, string model, float fuelEfficiency, int numDoors, bool isAutomatic) 
            : base(vehicleId, make, model, fuelEfficiency)
        {
            NumDoors = numDoors;
            IsAutomatic = isAutomatic;
        }

        public float CalculateFuelConsumption(float distance) 
        {
            if (distance < 0)
            throw new ArgumentException("Error: Distance cannot be negative.");
            
            return distance / FuelEfficiency;
        }
    }

    class Motorcycle : Vehicle
    {
        private int _engineCC;
        private bool _isSportBike;

        public int EngineCC
        {
            get => _engineCC;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error: Engine Capacity(CC) cannot be negative");
                _engineCC = value;
            }
        }

        public bool IsSportBike
        {
            get => _isSportBike;
            set => _isSportBike = value;
        }

        public Motorcycle(int vehicleId, string make, string model, float fuelEfficiency, int engineCC, bool isSportBike) 
            : base(vehicleId, make, model, fuelEfficiency)
        {
            EngineCC = engineCC;
            IsSportBike = isSportBike;
        }

        public float CalculateFuelConsumption(float distance)
        {
            if (distance < 0)
                throw new ArgumentException("Error: Distance cannot be negative.");

            float fuelConsumption = distance / FuelEfficiency;
            if (IsSportBike)
            {
                fuelConsumption *= 1.1f;
            }

            return fuelConsumption;
        }
    }

    class Truck : Vehicle
    {
        private float _cargoCapacity;
        private bool _isHeavyDuty;

        public float CargoCapacity
        {
            get => _cargoCapacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error: Cargo capacity cannot be negative");
                _cargoCapacity = value;
            }
        }

        public bool IsHeavyDuty
        {
            get => _isHeavyDuty;
            set => _isHeavyDuty = value;
        }

        public Truck(int vehicleId, string make, string model, float fuelEfficiency, float cargoCapacity, bool isHeavyDuty) 
            : base(vehicleId, make, model, fuelEfficiency)
        {
            CargoCapacity = cargoCapacity;
            IsHeavyDuty = isHeavyDuty;
        }

        public float CalculateFuelConsumption(float distance, float cargoWeight)
        {
            if (distance < 0)
                throw new ArgumentException("Error: Distance cannot be negative.");

            if (cargoWeight > CargoCapacity)
                throw new ArgumentException("Error: Cargo weight exceeds the truck's cargo capacity.");

            float cargoFactor = cargoWeight / CargoCapacity;
            float heavyDutyFactor = IsHeavyDuty ? 1.2f : 1.0f;

            float fuelConsumption = (distance / FuelEfficiency) * cargoFactor * heavyDutyFactor;
            return fuelConsumption;
        }
    }
}
