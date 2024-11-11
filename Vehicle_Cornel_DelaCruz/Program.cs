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


        }

        class Vehicle 
        { 
            public string VehicleId { get; set; }
            public string Make {  get; set; }
            public string Model { get; set; }
            public float FuelEfficiency { get; set; }

            public Vehicle (string vehicleid, string make, string model, float fuelefficiency) 
            {
                VehicleId = vehicleid;
                Make = make;
                Model = model;
                FuelEfficiency = fuelefficiency;
            }
        }

        class Car : Vehicle
        {
            public bool NumDoors;
            public bool IsAutomatic;

            public Car(string vehicleid, string make, string model, float fuelefficiency, 
                bool numdoors, bool isautomatic) :
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

        

            public Motorcycle(string vehicleid, string make, string model, float fuelefficiency, int enginecc,
            bool issportbike) : base (vehicleid, make, model, fuelefficiency)
            {
                EngineCC = enginecc;
                IsSportBike = issportbike;
            }

            public float CalculateFuelConsumption (float distance)
            {
                //return distance / FuelEfficiency
            }
        }

    }
}
