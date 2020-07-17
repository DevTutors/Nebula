using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nebula
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating Data.");

            //Set Serializer options.
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;

            string basePath = AppDomain.CurrentDomain.BaseDirectory ?? string.Empty;

            var vehicleOwners = VehicleOwnersWithVehiclesData.VehicleOwners(1500);
            File.WriteAllText(
                basePath + "VehicleOwners.json",
                JsonSerializer.Serialize<List<VehicleOwnerDto>>(vehicleOwners, jsonSerializerOptions));

            var bicycles = VehiclesData.Bicycles(1000);
            File.WriteAllText(
                basePath + "Bicycles.json",
                JsonSerializer.Serialize<List<VehicleDto>>(bicycles, jsonSerializerOptions));

            var motorCycles = VehiclesData.MotorCycles(1000);
            File.WriteAllText(
                basePath + "MotorCycles.json",
                JsonSerializer.Serialize<List<VehicleDto>>(motorCycles, jsonSerializerOptions));

            var threeWheelers = VehiclesData.ThreeWheelers(1000);
            File.WriteAllText(
                basePath + "ThreeWheelers.json",
                JsonSerializer.Serialize<List<VehicleDto>>(threeWheelers, jsonSerializerOptions));

            var fourWheelers = VehiclesData.FourWheelers(1000);
            File.WriteAllText(
                basePath + "FourWheelers.json",
                JsonSerializer.Serialize<List<VehicleDto>>(fourWheelers, jsonSerializerOptions));

            Console.WriteLine("Data Generation Complete.");
        }
    }
}
