using Bogus;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula
{
    public static class VehicleOwnersWithVehiclesData
    {
        public static List<VehicleOwnerDto> VehicleOwners(int count)
        {
            int corporateId = 1;
            int minimumIterations = 0;
            int maximumIterations = 4;
            var bicycles = new Stack<VehicleDto>(VehiclesData.Bicycles(count * maximumIterations));
            var motorCycles = new Stack<VehicleDto>(VehiclesData.MotorCycles(count * maximumIterations));
            var threeeWheelers = new Stack<VehicleDto>(VehiclesData.ThreeWheelers(count * maximumIterations));
            var fourWheelers = new Stack<VehicleDto>(VehiclesData.FourWheelers(count * maximumIterations));

            return new Faker<VehicleOwnerDto>()
                .StrictMode(true)
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName().OrNull(f, .2f))
                .RuleFor(u => u.MiddleName, f => f.Random.String(1).OrNull(f, .8f))
                .RuleFor(u => u.CorporateId, f => corporateId++.ToString())
                .RuleFor(u => u.VehicleDtos, f =>
                {
                    var ownerVehicles = new List<VehicleDto>();
                    var iterations = f.Random.Int(minimumIterations, maximumIterations);
                    for (int iterator = 1; iterator <= iterations; iterator++)
                    {
                        if (f.Random.Bool())
                            ownerVehicles.Add(bicycles.Pop());
                        if (f.Random.Bool())
                            ownerVehicles.Add(motorCycles.Pop());
                        if (f.Random.Bool())
                            ownerVehicles.Add(threeeWheelers.Pop());
                        if (f.Random.Bool())
                            ownerVehicles.Add(fourWheelers.Pop());
                    }
                    return ownerVehicles;
                }
                )
                .Generate(count);

        }
    }

    public class VehicleOwnerDto
    {
        public Guid Id { get; set; }

        public IEnumerable<VehicleDto>? VehicleDtos { get; set; }

        public string? CorporateId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }
    }
}
