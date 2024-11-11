using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Cornel_DelaCruz
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();
        }

        class Vehicle 
        { 
            public int VehicleId { get; set; }
            public string Make {  get; set; }
            public string Model { get; set; }
            public float FuelEfficiency { get; set; }

            public Vehicle (int vehicleid, string make, string model, float fuelefficiency) 
            {
                VehicleId = vehicleid;
                Make = make;
                Model = model;
                FuelEfficiency = fuelefficiency;
            }
        }

        class Car : Vehicle
        {
            public int NumDoors;
            public bool IsAutomatic;

            public Car(int vehicleid, string make, string model, float fuelefficiency, 
                int numdoors, bool isautomatic) :
                base(vehicleid, make, model, fuelefficiency)
            {
                NumDoors = numdoors;
                IsAutomatic = isautomatic;
            }

            public float CalculateFuelConsumption (float distance) 
            {
                return distance / FuelEfficiency;
            }
        }

        class Motorcycle : Vehicle
        {
            public int EngineCC { get; set; }
            public bool IsSportBike { get; set; }

        

            public Motorcycle(int vehicleid, string make, string model, float fuelefficiency, int enginecc,
            bool issportbike) : base (vehicleid, make, model, fuelefficiency)
            {
                EngineCC = enginecc;
                IsSportBike = issportbike;
            }

            public float CalculateFuelConsumption (float distance)
            {
                float fuelconsumption = distance / FuelEfficiency; 
                if (IsSportBike)
                {
                    fuelconsumption *= 1.1f;
                }

                return fuelconsumption;
            }
        }
        class Truck : Vehicle
        {
            public float CargoCapacity { get; set; }
            public bool IsHeavyDuty { get; set; }

            public Truck(int vehicleid, string make, string model, float fuelefficiency, float cargocapacity, bool isheavyduty) : base (vehicleid, make, model, fuelefficiency)
            {
                CargoCapacity = cargocapacity;
                IsHeavyDuty = isheavyduty;
            }

            public float CalculateFuelConsumption(float distance, float cargoWeight)
            {
                float cargoFactor = cargoWeight / CargoCapacity;
                float heavyDutyFactor = IsHeavyDuty ? 1.2f : 1.0f;

                float fuelConsumption = (distance / FuelEfficiency) * cargoFactor * heavyDutyFactor;
                return fuelConsumption;
            }  
        }

    }
}
