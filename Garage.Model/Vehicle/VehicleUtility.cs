﻿namespace Garage.Model.Vehicle;

// TODO! Implement a more scalable solution.

/// <summary>
/// A utility class used for vehicle constants
/// and description supported by the application.
/// Current usage in creating and filtering vehicles
/// features.
/// 
/// </summary>
public class VehicleUtility
{
    public const string ColorKey = "Color";

    public const string PowerSourceKey = "PowerSource";

    public const string VehicleTypeKey = "VehicleType";

    public const string VehicleWeightKey = "Weight";

    public const string VehicleDimensionKey = "Dimension";

    public const string BoatSteeringMechanismKey = "BoatSteeringMechanism";

    public const string CarBrandKey = "CarBrand";

    public const string WingSpanKey = "WingSpan";

    public const string PassengerCapacityKey = "PassengerCapacity";

    public const string SittingPassengerCapacityKey = "SittingPassengerCapacity";

    public const string StandingPassengerCapacityKey = "StandingPassengerCapacity";

    public const string NoiseLevelKey = "NoiseLevel";

    public const string DefaultCreateValue = "DEFAULT";

    public static Dictionary<string, string> GetCreateVehicleDescriptionMap(
        string vehicleType)
    {
        var creationDescriptionMap = new Dictionary<string, string>()
        {
            { $"{ColorKey}", $"Enter vehicle color or leave empty for unknown [" +
                $"{VehicleColor.GREY.ToUpper()}, " +
                $"{VehicleColor.WHITE.ToUpper()}, " +
                $"{VehicleColor.BLACK.ToUpper()}, " +
                $"{VehicleColor.BLUE.ToUpper()}, " +
                $"{VehicleColor.RED.ToUpper()}, " +
                $"{VehicleColor.MULTI.ToUpper()}, " +
                $"{VehicleColor.UNKNOWN.ToUpper()}]"
            },
            { $"{VehicleWeightKey}", "Enter estimated vehicle weight (Number > 0)"},
            { $"{VehicleDimensionKey}", "Enter estimated vehicle dimensions (x,y,z | x,y,z > 0)"},
        };

        if (vehicleType != VehicleTypeKeeper.E_CAR.ID) {

            creationDescriptionMap[PowerSourceKey] = $"Enter vehicle power source or leave empty for unknown [" +
                $"{PowerSourceKeeper.GASOLINE.ToUpper()}, " +
                $"{PowerSourceKeeper.DIESEL.ToUpper()}, " +
                $"{PowerSourceKeeper.HYDROGEN.ToUpper()}, " +
                $"{PowerSourceKeeper.ELECTRIC.ToUpper()}, " +
                $"{PowerSourceKeeper.HYBRID.ToUpper()}, " +
                $"{PowerSourceKeeper.NONE.ToUpper()}, " +
                $"{PowerSourceKeeper.UNKNOWN.ToUpper()}]";
        }

        if (vehicleType == VehicleTypeKeeper.AIRPLANE.ID)
        {
            creationDescriptionMap[WingSpanKey] = "Enter wingspan (Number > 0)";
            creationDescriptionMap[PassengerCapacityKey] = "Enter passenger capacity (Number > 0)";
        }

        if (vehicleType == VehicleTypeKeeper.BOAT.ID)
        {
            creationDescriptionMap[BoatSteeringMechanismKey] = $"Enter boat steering mechanism or leave empty for unknown [" +
                $"{BoatSteeringMechanism.TILLER.ToUpper()}, " +
                $"{BoatSteeringMechanism.WHEEL.ToUpper()}, " +
                $"{BoatSteeringMechanism.JOYSTICK.ToUpper()}, " +
                $"{BoatSteeringMechanism.OARS.ToUpper()}, " +
                $"{BoatSteeringMechanism.UNKNOWN.ToUpper()}]";
        }

        if (vehicleType == VehicleTypeKeeper.BUS.ID)
        {
            creationDescriptionMap[SittingPassengerCapacityKey] = "Enter sitting passenger capacity (Number > 0)";
            creationDescriptionMap[StandingPassengerCapacityKey] = "Enter standing passenger capacity (Number > 0)";
        }

        if (vehicleType == VehicleTypeKeeper.CAR.ID ||
            vehicleType == VehicleTypeKeeper.E_CAR.ID)
        {
            creationDescriptionMap[CarBrandKey] = $"Enter car brand or leave empty for unknown [" +
                $"{CarBrand.TOYOTA.ToUpper()}, " +
                $"{CarBrand.VOLKSWAGEN.ToUpper()}, " +
                $"{CarBrand.TESLA.ToUpper()}, " +
                $"{CarBrand.FORD.ToUpper()}, " +
                $"{CarBrand.HONDA.ToUpper()}, " +
                $"{CarBrand.HYUNDAI.ToUpper()}, " +
                $"{CarBrand.MERCEDES_BENZ.ToUpper()}, " +
                $"{CarBrand.BMW.ToUpper()}, " +
                $"{CarBrand.VOLVO.ToUpper()}, " +
                $"{CarBrand.SAAB.ToUpper()}, " +
                $"{CarBrand.NONE.ToUpper()}, " +
                $"{CarBrand.UNKNOWN.ToUpper()}]";
        }

        if (vehicleType == VehicleTypeKeeper.MOTORCYCLE.ID)
        {
            creationDescriptionMap[NoiseLevelKey] = "Enter noise level (Number > 0)";
        }

        return creationDescriptionMap;
    }

    public static Dictionary<string, string> GetFilterDescriptionMap()
    {
        Dictionary<string, string> propertDescriptionMap = new()
        {
            { $"{VehicleTypeKey}", $"Select vehicle type or leave empty for any type [" +
                $"{VehicleTypeKeeper.AIRPLANE.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.BOAT.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.BUS.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.CAR.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.E_CAR.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.MOTORCYCLE.Description.ToUpper()}]"
            },
            { $"{ColorKey}", $"Select color or leave empty for any color [" +
                $"{VehicleColor.GREY.ToUpper()}, " +
                $"{VehicleColor.WHITE.ToUpper()}, " +
                $"{VehicleColor.BLACK.ToUpper()}, " +
                $"{VehicleColor.BLUE.ToUpper()}, " +
                $"{VehicleColor.RED.ToUpper()}, " +
                $"{VehicleColor.MULTI.ToUpper()}, " +
                $"{VehicleColor.UNKNOWN.ToUpper()}]"
            },
            { $"{PowerSourceKey}", $"Select power source or leave empty for any source [" +
                $"{PowerSourceKeeper.GASOLINE.ToUpper()}, " +
                $"{PowerSourceKeeper.DIESEL.ToUpper()}, " +
                $"{PowerSourceKeeper.HYDROGEN.ToUpper()}, " +
                $"{PowerSourceKeeper.ELECTRIC.ToUpper()}, " +
                $"{PowerSourceKeeper.HYBRID.ToUpper()}, " +
                $"{PowerSourceKeeper.NONE.ToUpper()}, " +
                $"{PowerSourceKeeper.UNKNOWN.ToUpper()}]"},
            { $"{VehicleWeightKey}", "Enter exact weight (Number > 0) or leave empty for any weights"},
            { $"{VehicleDimensionKey}", "Enter exact dimensions (x, y, z | x, y, z > 0) or leave empty for any dimensions"},
        };
        return propertDescriptionMap;
    }
}
