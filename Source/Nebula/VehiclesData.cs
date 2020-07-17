using Bogus;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula
{
    public static class VehiclesData
    {
        public static List<VehicleDto> Bicycles(int count)
        {
            var bicycleMakes = new[] { "BTWIN", "Atlas", "Hercules" };
            var btwinModels = new[] { "RockRider", "RiverSide", "my" };
            var atlasModels = new[] { "Ultimate", "Sting", "Comet", "Flame", "Force", "Rapid" };
            var herculesModels = new[] { "StreetRider", "Dynamite", "TopSpeed", "StreetCat", "Flare" };

            return new Faker<VehicleDto>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.VehicleType, f => VehicleType.Bicycle)
                .RuleFor(o => o.LicenseNumber, f => string.Empty.OrNull(f, .6f))
                .RuleFor(o => o.Make, f => f.PickRandom(bicycleMakes))
                .RuleFor(o => o.Model, (f, v) =>
                {
                    if (v.Make == "BTWIN")
                        return f.PickRandom(btwinModels);
                    else if (v.Make == "Atlas")
                        return f.PickRandom(atlasModels);
                    else
                        return f.PickRandom(herculesModels);
                }).Generate(count);

        }

        public static List<VehicleDto> MotorCycles(int count)
        {
            var motorCycleMakes = new[] { "Bajaj", "HeroHonda", "RoyalEnfield", "Yamaha" };
            var bajajModels = new[] { "Pulsar", "Chetak" };
            var heroHondaModels = new[] { "Splendor", "Deluxe", "Glamour", "Xtreme" };
            var royalEnfieldModels = new[] { "Bullet", "Classic" };
            var yamahaModels = new[] { "FZ" };

            return new Faker<VehicleDto>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.VehicleType, f => VehicleType.MotorCycle)
                .RuleFor(o => o.LicenseNumber, f => f.Vehicle.Vin())
                .RuleFor(o => o.Make, f => f.PickRandom(motorCycleMakes))
                .RuleFor(o => o.Model, (f, v) =>
                {
                    if (v.Make == "Bajaj")
                        return f.PickRandom(bajajModels);
                    else if (v.Make == "HeroHonda")
                        return f.PickRandom(heroHondaModels);
                    else if (v.Make == "RoyalEnfield")
                        return f.PickRandom(royalEnfieldModels);
                    else
                        return f.PickRandom(yamahaModels);
                }).Generate(count);

        }

        public static List<VehicleDto> ThreeWheelers(int count)
        {
            var threeWheelerMakes = new[] { "Bajaj", "TVS", "Mahindra" };
            var bajajModels = new[] { "Maxima", "Compact", "Qute" };
            var tvsModels = new[] { "King" };
            var mahindraModels = new[] { "Treo", "Alfa" };

            return new Faker<VehicleDto>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.VehicleType, f => VehicleType.ThreeWheeler)
                .RuleFor(o => o.LicenseNumber, f => f.Vehicle.Vin())
                .RuleFor(o => o.Make, f => f.PickRandom(threeWheelerMakes))
                .RuleFor(o => o.Model, (f, v) =>
                {
                    if (v.Make == "Bajaj")
                        return f.PickRandom(bajajModels);
                    else if (v.Make == "TVS")
                        return f.PickRandom(tvsModels);
                    else
                        return f.PickRandom(mahindraModels);
                }).Generate(count);

        }

        public static List<VehicleDto> FourWheelers(int count)
        {
            var fourWheelerMakes = new[] { "Hyundai", "Tata", "Honda", "Ford" };
            var hyundaiModels = new[] { "i20", "Verna", "i10"};
            var tataModels = new[] { "Nexon", "Indica", "Altroz", "Hexa" };
            var hondaModels = new[] { "Jazz"};
            var fordModels = new[] { "Figo"};

            return new Faker<VehicleDto>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.VehicleType, f => VehicleType.FourWheeler)
                .RuleFor(o => o.LicenseNumber, f => f.Vehicle.Vin())
                .RuleFor(o => o.Make, f => f.PickRandom(fourWheelerMakes))
                .RuleFor(o => o.Model, (f, v) =>
                {
                    if (v.Make == "Hyundai")
                        return f.PickRandom(hyundaiModels);
                    else if (v.Make == "Tata")
                        return f.PickRandom(tataModels);
                    else if (v.Make == "Honda")
                        return f.PickRandom(hondaModels);
                    else
                        return f.PickRandom(fordModels);
                }).Generate(count);

        }
    }
    public class VehicleDto
    {
        public Guid Id { get; set; }

        public string? LicenseNumber { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        public VehicleType VehicleType { get; set; }
    }

    public enum VehicleType
    {
        Bicycle = 1,
        MotorCycle = 2,
        ThreeWheeler = 3,
        FourWheeler = 4,
    }
}
